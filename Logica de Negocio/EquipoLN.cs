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
    public class EquipoLN
    {

        private JugadorLN jugadorLN = new JugadorLN();

        // Método para registrar un nuevo equipo
        public string RegistrarEquipo(int pIdEquipo, int pIdJugador, int pIdCriatura1, int pIdCriatura2, int pIdCriatura3)
        {
            if (EquipoAD.ExisteIdEquipo(pIdEquipo))  return "Error: Ya existe un equipo registrado con el ID " + pIdEquipo + ". El ID debe ser único.";

            Jugador jugador = JugadorAD.BuscarJugadorPorId(pIdJugador);

            if (jugador == null)  return "Error: No se encontró el jugador con el ID " + pIdJugador + ".";
 
            // Se agrupan los IDs de las criaturas en un arreglo auxiliar para poder validarlos fácilmente
            int[] idsCriaturas = { pIdCriatura1, pIdCriatura2, pIdCriatura3 };

            foreach (int idCriatura in idsCriaturas) if (!CriaturaPerteneceAInventario(jugador, idCriatura)) return "Error: La criatura con ID " + idCriatura + " no se encuentra en el inventario del jugador " + jugador.Nombre + ".";

            // Si todas las validaciones pasan, se crea el objeto Equipo
            Equipo nuevoEquipo = new Equipo(pIdEquipo, pIdJugador, pIdCriatura1, pIdCriatura2, pIdCriatura3);

            if (EquipoAD.RegistrarEquipo(nuevoEquipo)) return "Equipo registrado con éxito para el jugador " + jugador.Nombre + ".";

            else return "Error: El almacenamiento de equipos está lleno y no se pudo registrar.";
         }

        // Método que verifica que el ID de una criatura esté presente en el InventarioCriaturas del Jugador
        private bool CriaturaPerteneceAInventario(Jugador pJugador, int pIdCriatura)
        {
            foreach (var inventarioItem in pJugador.InventarioCriaturas) if (inventarioItem != null && inventarioItem.IdCriatura == pIdCriatura) return true;
            return false;
        }

        public Equipo[] ObtenerTodosLosEquipos()
        {
            return EquipoAD.BuscarTodosLosEquipos();
        }

        public Equipo BuscarEquipoPorIdYJugador(int pIdEquipo, int pIdJugador)
        {
            return EquipoAD.BuscarEquipoPorIdYJugador(pIdEquipo, pIdJugador);
        }

        public Equipo[] ObtenerEquiposPorIdJugador(int pIdJugador)
        {
            return EquipoAD.BuscarEquiposPorJugador(pIdJugador);
        }
    }
}