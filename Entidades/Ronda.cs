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
    public class Ronda
    {
        public int IdRonda { get; set; }
        public int IdBatalla { get; set; }
        public int IdJugador1 { get; set; }
        public int IdCriatura1 { get; set; }
        public int IdJugador2 { get; set; }
        public int IdCriatura2 { get; set; }
        public int GanadorRonda { get; set; }

        public Ronda(int pIdRonda, int pIdBatalla, int pIdJugador1, int pIdCriatura1, int pIdJugador2, int pIdCriatura2, int pGanadorRonda)
        {
            IdRonda = pIdRonda;
            IdBatalla = pIdBatalla;
            IdJugador1 = pIdJugador1;
            IdCriatura1 = pIdCriatura1;
            IdJugador2 = pIdJugador2;
            IdCriatura2 = pIdCriatura2;
            GanadorRonda = pGanadorRonda;
        }
    }
}
