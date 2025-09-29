/*
 * UNED III Cuatrimestre
 * 00830 - Programacion avanzada
 * Proyecto 1: Batallas Místicas
 * Estudiante: Oscar Eduardo Cervantes Mora
 * Fecha: 2025-09-28
 * @author ocervantesmora
 */
using Entidades;

namespace LogicaDeNegocio
{
    public class EjecucionBatallaLN
    {
        // Instancias de otras clases LN para poder utilizar las operaciones específicas (como buscar 
        // una criatura o actualizar un jugador) de cada clase.
        private CriaturaLN criaturaLN = new CriaturaLN();
        private JugadorLN jugadorLN = new JugadorLN();
        private RondaLN rondaLN = new RondaLN();
        private EquipoLN equipoLN = new EquipoLN();

        public Ronda[] EjecutarBatalla(Batalla pBatalla)
        {
            // Se obtienen los equipos completos del arreglo de equipos en memoria
            Equipo e1 = equipoLN.BuscarEquipoPorIdYJugador(pBatalla.IdEquipo1, pBatalla.IdJugador1);
            Equipo e2 = equipoLN.BuscarEquipoPorIdYJugador(pBatalla.IdEquipo2, pBatalla.IdJugador2);

            // Se almacenan los IDs de las criaturas en arreglos para iterar fácilmente.
            int[] c1Ids = { e1.IdCriatura1, e1.IdCriatura2, e1.IdCriatura3 };
            int[] c2Ids = { e2.IdCriatura1, e2.IdCriatura2, e2.IdCriatura3 };

            Ronda[] rondas = new Ronda[3]; // Una batalla siempre tiene 3 rondas.
            bool[] c1Usadas = new bool[3]; // Arreglo auxiliar para asegurar que cada criatura se use 1 sola vez.
            bool[] c2Usadas = new bool[3];

            // Ciclo principal: Se ejecutan las 3 rondas
            for (int i = 0; i < 3; i++)
            {
                // Se seleccionan las criaturas de forma aleatoria
                int c1Index = SeleccionarCriaturaIndex(c1Usadas);
                int c2Index = SeleccionarCriaturaIndex(c2Usadas);

                // Se marcan como usadas para las futuras rondas
                c1Usadas[c1Index] = true;
                c2Usadas[c2Index] = true;

                // Se obtienen las estadísticas de combate (Poder y Resistencia)
                // IMPORTANTE: no se usa la criatura base, sino la instancia del inventario de cada jugador porque
                // ahí es donde se guardan las mejoras de cada criatura segun el historial de batallas y rondas
                Inventario inv1 = jugadorLN.BuscarInventarioPorCriatura(pBatalla.IdJugador1, c1Ids[c1Index]);
                Inventario inv2 = jugadorLN.BuscarInventarioPorCriatura(pBatalla.IdJugador2, c2Ids[c2Index]);

                // Se obtiene la metadata de las criaturas base (Nombre, Tipo, Nivel, etc.) ya que no cambian
                Criatura c1Base = criaturaLN.BuscarCriaturaPorId(c1Ids[c1Index]);
                Criatura c2Base = criaturaLN.BuscarCriaturaPorId(c2Ids[c2Index]);

                // Se crean objetos temporales de tipo Criatura con el Poder/Resistencia actualizados
                // para poder combinar el objeto Criatura estándar pero con los stats de combate.
                Criatura c1Combate = new Criatura(c1Base.IdCriatura, c1Base.Nombre, c1Base.Tipo, c1Base.Nivel,
                    inv1.Poder, inv1.Resistencia, c1Base.Costo);
                Criatura c2Combate = new Criatura(c2Base.IdCriatura, c2Base.Nombre, c2Base.Tipo, c2Base.Nivel,
                    inv2.Poder, inv2.Resistencia, c2Base.Costo);

                // Se determina el ganador de la ronda con un método auxiliar
                int ganadorId = DeterminarGanadorRonda(pBatalla.IdJugador1, c1Combate, pBatalla.IdJugador2, c2Combate);


                // Se registra la ronda
                Ronda ronda = new Ronda(
                    i + 1, // Número de ronda automatizado
                    pBatalla.IdBatalla,
                    pBatalla.IdJugador1,
                    c1Combate.IdCriatura,
                    pBatalla.IdJugador2,
                    c2Combate.IdCriatura,
                    ganadorId
                );
                rondas[i] = ronda;

                // Se guarda el resultado de la ronda en el arreglo de rondas
                rondaLN.RegistrarRonda(ronda);

                // Se aplican las ganancias de experiencia y cristales al ganador
                AplicarGananciaRonda(ganadorId, pBatalla.IdJugador1, pBatalla.IdJugador2, c1Combate.IdCriatura, c2Combate.IdCriatura);
            }

            return rondas;
        }

        private int SeleccionarCriaturaIndex(bool[] pUsadas)
        {
            Random rnd = new Random();
            int index;
            // Se utiliza un ciclo do-while para garantizar que el índice seleccionado no esté marcado como 'usado'.
            do
            {
                index = rnd.Next(0, 3); // Genera 0, 1, o 2.
            } while (pUsadas[index]);

            return index;
        }

        private void AplicarGananciaRonda(int pGanadorId, int pJ1Id, int pJ2Id, int pC1Id, int pC2Id)
        {
            // El jugador ganador de la ronda siempre recibe 10 Cristales.
            jugadorLN.IncrementarCristales(pGanadorId, 10);

            int idJugadorGanador;
            int idCriaturaGanadora;

            // Se revisa la criuatura ganadora, con base en el jugador ganador, para mejorar el poder
            if (pGanadorId == pJ1Id)
            {
                idJugadorGanador = pJ1Id;
                idCriaturaGanadora = pC1Id;
            }
            else
            {
                idJugadorGanador = pJ2Id;
                idCriaturaGanadora = pC2Id;
            }

            // La criatura ganadora recibe un aumento de 5 puntos en su poder, en el inventario del jugador
            jugadorLN.AumentarPoderInventario(idJugadorGanador, idCriaturaGanadora, 5);
        }

        public int DeterminarGanadorRonda(int pJ1Id, Criatura pC1, int pJ2Id, Criatura pC2)
        {
            Random rnd = new Random();
            // Se decide el jugador que ataca primero de forma aleatoria
            bool j1AtacaPrimero = rnd.Next(0, 2) == 0;

            // Se utilizan roles en los nombres de variable para mejor entendimiento de la lógica
            Criatura atacanteC = j1AtacaPrimero ? pC1 : pC2;
            Criatura defensorC = j1AtacaPrimero ? pC2 : pC1;
            int atacanteIdJ = j1AtacaPrimero ? pJ1Id : pJ2Id;
            int defensorIdJ = j1AtacaPrimero ? pJ2Id : pJ1Id;

            // Caso 1: El atacante vence la resistencia del defensor
            if (atacanteC.Poder >= defensorC.Resistencia)
            {
                return atacanteIdJ;
            }

            // Caso 2: El defensor contraataca.
            Criatura contraAtacanteC = defensorC; // El defensor se convierte en el contratacante

            if (contraAtacanteC.Poder >= atacanteC.Resistencia)
            {
                return defensorIdJ; // Gana el defensor por contraataque
            }

            // Caso 3: Lógica de 'Remanente'. Se usa para desempate si nadie gana en los casos anteriores
            int remanenteJ1 = pC1.Poder - pC2.Resistencia;
            int remanenteJ2 = pC2.Poder - pC1.Resistencia;

            if (remanenteJ1 > remanenteJ2)
            {
                return pJ1Id;
            }
            else if (remanenteJ2 > remanenteJ1)
            {
                return pJ2Id;
            }

            // Caso 4: Empate tambien en remanente, el ganador se decide aleatoriamente
            return (rnd.Next(0, 2) == 0) ? pJ1Id : pJ2Id;
        }
    }
}