/*
 * UNED III Cuatrimestre
 * 00830 - Programacion avanzada
 * Proyecto 1: Batallas Místicas
 * Estudiante: Oscar Eduardo Cervantes Mora
 * Fecha: 2025-09-28
 * @author ocervantesmora
 */
namespace Entidades
{
    public class Batalla
    {
        public int IdBatalla { get; set; }
        public int IdJugador1 { get; set; }
        public int IdEquipo1 { get; set; }
        public int IdJugador2 { get; set; }
        public int IdEquipo2 { get; set; }
        public int Ganador { get; set; }
        public DateTime Fecha { get; set; }

        // Constructor
        public Batalla(int pIdBatalla, int pIdJugador1, int pIdEquipo1, int pIdJugador2, int pIdEquipo2, int pGanador, DateTime pFecha)
        {
            IdBatalla = pIdBatalla;
            IdJugador1 = pIdJugador1;
            IdEquipo1 = pIdEquipo1;
            IdJugador2 = pIdJugador2;
            IdEquipo2 = pIdEquipo2;
            Ganador = pGanador;
            Fecha = pFecha;
        }

        // Sobrecarga del constructor para la Lógica de Negocio (sin ganador ni fecha inicial) para crear el objeto antes de calcular el ganador
        public Batalla(int pIdBatalla, int pIdJugador1, int pIdEquipo1, int pIdJugador2, int pIdEquipo2)
        {
            IdBatalla = pIdBatalla;
            IdJugador1 = pIdJugador1;
            IdEquipo1 = pIdEquipo1;
            IdJugador2 = pIdJugador2;
            IdEquipo2 = pIdEquipo2;
            Ganador = 0; 
            Fecha = DateTime.Now; 
        }
    }
}
