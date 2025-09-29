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
    public class BatallaLN
    {

        private JugadorLN jugadorLN = new JugadorLN();
        private EquipoLN equipoLN = new EquipoLN();
        private EjecucionBatallaLN ejecucionBatallaLN = new EjecucionBatallaLN();

        public string RegistrarBatalla(int pIdBatalla, int pIdJugador1, int pIdEquipo1, int pIdJugador2, int pIdEquipo2)
        {
            if (BatallaAD.ExisteIdBatalla(pIdBatalla))
            {
                return "Error: Ya existe una batalla registrada con el ID " + pIdBatalla + ". El ID debe ser único.";
            }

            if (pIdJugador1 == pIdJugador2)
            {
                return "Error: Un jugador no puede batallar contra sí mismo.";
            }

            string errorValidacion = ValidarJugadoresYEquipos(pIdJugador1, pIdEquipo1, pIdJugador2, pIdEquipo2);
            if (!string.IsNullOrEmpty(errorValidacion))
            {
                return errorValidacion;
            }

            // Creación de la entidad Batalla. Se inicializa el ganador en 0 (desconocido).
            Batalla nuevaBatalla = new Batalla(
                pIdBatalla,
                pIdJugador1,
                pIdEquipo1,
                pIdJugador2,
                pIdEquipo2,
                0, // El ganador se actualizará después de la ejecución
                DateTime.Now
            );

            // Se ejecutan las rondas del Combate.
            Ronda[] rondasJugadas = ejecucionBatallaLN.EjecutarBatalla(nuevaBatalla);

            // Se determina el Ganador Final (El mejor de 3 rondas)
            int j1Victorias = 0;
            int j2Victorias = 0;

            // Recorremos el arreglo de rondas
            foreach (Ronda r in rondasJugadas)
            {
                if (r.GanadorRonda == pIdJugador1) j1Victorias++;
                else if (r.GanadorRonda == pIdJugador2) j2Victorias++;
            }

            // Gana el primero que llegue a 2 victorias de ronda.
            int ganadorBatalla = 0;
            if (j1Victorias >= 2) ganadorBatalla = pIdJugador1;
            else if (j2Victorias >= 2) ganadorBatalla = pIdJugador2;


            // Se actualiza la entidad con el resultado final
            nuevaBatalla.Ganador = ganadorBatalla;

            if (ganadorBatalla > 0)
            {
                // Recompensas de Batalla: 30 cristales y se incrementa el contador de victorias.
                jugadorLN.IncrementarCristales(ganadorBatalla, 30);
                jugadorLN.IncrementarBatallasGanadas(ganadorBatalla);
            }

            // Se guarda el registro de la Batalla completa en la Capa AD.
            if (BatallaAD.RegistrarBatalla(nuevaBatalla))
            {
                return $"Batalla registrada con éxito. Ganador (ID): {ganadorBatalla}.";
            }
            else
            {
                // Manejo de error si la capa de Acceso a Datos indica que el almacenamiento falló.
                return "Error: El almacenamiento de batallas está lleno y no se pudo registrar.";
            }
        }

        private string ValidarJugadoresYEquipos(int pIdJ1, int pIdE1, int pIdJ2, int pIdE2)
        {
            // Jugador 1 y Equipo 1
            if (jugadorLN.BuscarJugadorPorId(pIdJ1) == null) return $"Error: Jugador 1 con ID {pIdJ1} no se encuentra registrado.";
            if (equipoLN.BuscarEquipoPorIdYJugador(pIdE1, pIdJ1) == null)  return $"Error: El Equipo 1 con ID {pIdE1} no existe o no pertenece al Jugador 1 (ID {pIdJ1}).";
            
            // Jugador 2 y Equipo 2
            if (jugadorLN.BuscarJugadorPorId(pIdJ2) == null) return $"Error: Jugador 2 con ID {pIdJ2} no se encuentra registrado.";
            if (equipoLN.BuscarEquipoPorIdYJugador(pIdE2, pIdJ2) == null)  return $"Error: El Equipo 2 con ID {pIdE2} no existe o no pertenece al Jugador 2 (ID {pIdJ2}).";

            // Si todo pasa, no hay error
            return null;
        }

        public Batalla[] ObtenerTodasLasBatallas()
        {
            return BatallaAD.BuscarTodasLasBatallas();
        }
    }
}