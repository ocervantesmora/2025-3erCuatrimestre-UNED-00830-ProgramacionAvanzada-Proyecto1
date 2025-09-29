/*
 * UNED III Cuatrimestre
 * 00830 - Programacion avanzada
 * Proyecto 1: Batallas Místicas
 * Estudiante: Oscar Eduardo Cervantes Mora
 * Fecha: 2025-09-28
 * @author ocervantesmora
 */
using AccesoADatos;
using Entidades;

namespace LogicaDeNegocio
{
    public class JugadorLN
    {
        private CriaturaLN criaturaLN;

        public JugadorLN()
        {
            criaturaLN = new CriaturaLN();
        }

        // Método para registrar un nuevo jugador
        public string RegistrarJugador(int pId, string pNombre, DateTime pFechaNacimiento)
        {
            if (JugadorAD.ExisteIdJugador(pId))  return "Error: Ya existe un jugador registrado con este ID.";
            if (string.IsNullOrEmpty(pNombre)) return "Error: El nombre del jugador no puede estar vacío.";
            if (!ValidarEdad(pFechaNacimiento)) return "Error: El jugador debe tener más de 10 años para registrarse.";
 
            // Se crea el objeto Jugador
            Jugador nuevoJugador = new Jugador(pId, pNombre, pFechaNacimiento);

            if (JugadorAD.RegistrarJugador(nuevoJugador)) return "Jugador registrado con éxito.";
            else return "Error: No se pudo registrar el jugador. El almacenamiento está lleno.";
        }

        // Lógica de validación de edad
        private bool ValidarEdad(DateTime pFechaNacimiento)
        {
            DateTime fechaActual = DateTime.Now;
            int edad = fechaActual.Year - pFechaNacimiento.Year;

            return edad > 10;
        }

        public Jugador[] ObtenerTodosLosJugadores()
        {
            return JugadorAD.ObtenerJugadores();
        }

        // Actualiza las batallas ganadas y recalcula el nivel
        public string ActualizarBatallasGanadas(int pId, int pBatallasGanadas)
        {
            // Se lee la entidad para modificarla segun los valores actuales
            Jugador jugador = JugadorAD.BuscarJugadorPorId(pId);
            if (jugador != null)
            {
                jugador.BatallasGanadas = pBatallasGanadas;
                jugador.Nivel = RecalcularNivel(jugador.BatallasGanadas);
                return "Batallas y nivel del jugador actualizados.";
            }
            else  return "Error: No se encontró el jugador con ese ID.";
        }

        // El nivel se basa en el número de victorias
        private int RecalcularNivel(int batallasGanadas)
        {
            if (batallasGanadas >= 20) return 4;
            if (batallasGanadas >= 10) return 3;
            if (batallasGanadas >= 5) return 2;
            return 1;
        }

        // Maneja la compra de criaturas al inventario.
        public string AgregarCriaturaAInventario(int pIdJugador, int pIdCriatura, int pPoder, int pResistencia)
        {
            Jugador jugador = JugadorAD.BuscarJugadorPorId(pIdJugador);
            Criatura criatura = criaturaLN.BuscarCriaturaPorId(pIdCriatura); // Se usa CriaturaLN para obtener el costo

            if (jugador == null || criatura == null)
            {
                if (jugador == null) return "Error: No se encontró el jugador.";
                return "Error: No se encontró la criatura.";
            }

            if (CriaturaYaEstaEnInventario(jugador, pIdCriatura)) return "Error: La criatura ya se encuentra en el inventario del jugador.";

            if (jugador.Cristales < criatura.Costo) return "Error: El jugador no tiene suficientes cristales para agregar esta criatura.";

            // Se crea el objeto Inventario.
            Inventario nuevoInventario = new Inventario(pIdJugador, pIdCriatura, pPoder, pResistencia);

            jugador.Cristales -= criatura.Costo;

            return JugadorAD.AgregarCriaturaAInventario(pIdJugador, nuevoInventario);
        }

        // Método para verificar si una criatura ya está en el inventario
        public bool CriaturaYaEstaEnInventario(Jugador pJugador, int pIdCriatura)
        {
            foreach (var criaturaInventario in pJugador.InventarioCriaturas) if (criaturaInventario != null && criaturaInventario.IdCriatura == pIdCriatura)return true;
            return false;
        }

        public Jugador BuscarJugadorPorId(int pIdJugador)
        {
            return JugadorAD.BuscarJugadorPorId(pIdJugador);
        }

        // Lógica para dar cristales al jugador luego de ganar la batalla o ronda
        public bool IncrementarCristales(int pIdJugador, int pCantidad)
        {
            Jugador jugador = JugadorAD.BuscarJugadorPorId(pIdJugador);

            if (jugador == null || pCantidad <= 0) return false;

            jugador.Cristales += pCantidad;

            return JugadorAD.ActualizarJugador(jugador);
        }

        // Lógica para incrementar las victorias y actualizar el nivel
        public bool IncrementarBatallasGanadas(int pIdJugador)
        {
            Jugador jugador = JugadorAD.BuscarJugadorPorId(pIdJugador);

            if (jugador == null) return false;

            jugador.BatallasGanadas += 1;

            // Se recalcula el nivel
            jugador.Nivel = RecalcularNivel(jugador.BatallasGanadas);

            return JugadorAD.ActualizarJugador(jugador);
        }

        // Busca las stats de una criatura específica dentro del inventario del jugador
        public Inventario BuscarInventarioPorCriatura(int pIdJugador, int pIdCriatura)
        {
            Jugador jugador = JugadorAD.BuscarJugadorPorId(pIdJugador);

            if (jugador == null) return null;

            for (int i = 0; i < jugador.CantidadCriaturas; i++)
            {
                if (jugador.InventarioCriaturas[i] != null && jugador.InventarioCriaturas[i].IdCriatura == pIdCriatura) return jugador.InventarioCriaturas[i];
            }
            return null;
        }

        // Aumenta el poder a una criatura específica en el inventario del jugador
        public bool AumentarPoderInventario(int pIdJugador, int pIdCriatura, int pAumento)
        {
            Jugador jugador = JugadorAD.BuscarJugadorPorId(pIdJugador);
            if (jugador == null) return false;

            Inventario inv = this.BuscarInventarioPorCriatura(pIdJugador, pIdCriatura);

            if (inv == null) return false;

            inv.Poder += pAumento;
            return JugadorAD.ActualizarJugador(jugador);
        }

        public Jugador[] ObtenerTop10JugadoresOrdenados()
        {
            Jugador[] todosLosJugadores = JugadorAD.ObtenerJugadores();

            if (todosLosJugadores == null || todosLosJugadores.Length == 0) return new Jugador[0];

            // Se ordena el arreglo por BatallasGanadas (Bubble Sort con chequeo de nulls).
            for (int i = 0; i < todosLosJugadores.Length - 1; i++)
            {
                for (int j = 0; j < todosLosJugadores.Length - i - 1; j++)
                {
                    Jugador actual = todosLosJugadores[j];
                    Jugador siguiente = todosLosJugadores[j + 1];

                    if (actual == null && siguiente != null ||
                        (actual != null && siguiente != null && actual.BatallasGanadas < siguiente.BatallasGanadas))
                    {
                        Jugador temp = todosLosJugadores[j];
                        todosLosJugadores[j] = todosLosJugadores[j + 1];
                        todosLosJugadores[j + 1] = temp;
                    }
                }
            }

            // Se filtran los nulls después de ordenarlos y se devuelven solo 10
            int jugadoresValidos = 0;
            for (int i = 0; i < todosLosJugadores.Length; i++)  if (todosLosJugadores[i] != null)  jugadoresValidos++;

            int topCount = Math.Min(10, jugadoresValidos);
            Jugador[] top10 = new Jugador[topCount];

            for (int i = 0; i < topCount; i++)  top10[i] = todosLosJugadores[i];

            return top10;
        }
    }
}