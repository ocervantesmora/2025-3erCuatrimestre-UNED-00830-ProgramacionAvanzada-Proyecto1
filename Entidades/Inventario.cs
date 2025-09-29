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
    public class Inventario
    {
        public int IdJugador { get; set; }
        public int IdCriatura { get; set; }
        public int Poder { get; set; }
        public int Resistencia { get; set; }

        public Inventario(int pIdJugador, int pIdCriatura, int pPoder, int pResistencia)
        {
            IdJugador = pIdJugador;
            IdCriatura = pIdCriatura;
            Poder = pPoder;
            Resistencia = pResistencia;
        }
    }
}
