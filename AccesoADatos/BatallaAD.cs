/*
 * UNED III Cuatrimestre
 * 00830 - Programacion avanzada
 * Proyecto 1: Batallas Místicas
 * Estudiante: Oscar Eduardo Cervantes Mora
 * Fecha: 2025-09-28
 * @author ocervantesmora
 */
using Entidades;

namespace AccesoADatos
{
    public static class BatallaAD
    {
        private static Batalla[] arregloBatallas = new Batalla[50];
        private static int indiceBatallas = 0; // Contador de batallas registradas

        public static bool RegistrarBatalla(Batalla pBatalla)
        {
            if (indiceBatallas < arregloBatallas.Length)
            {
                arregloBatallas[indiceBatallas] = pBatalla;
                indiceBatallas++;
                return true;
            }
            return false;
        }

        public static bool ExisteIdBatalla(int pIdBatalla)
        {
            for (int i = 0; i < indiceBatallas; i++)
            {
                if (arregloBatallas[i] != null && arregloBatallas[i].IdBatalla == pIdBatalla)
                {
                    return true;
                }
            }
            return false;
        }

        public static Batalla[] BuscarTodasLasBatallas()
        {
            return arregloBatallas;
        }
    }
}
