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
    public static class RondaAD
    {
        private static Ronda[] arregloRondas = new Ronda[100];
        private static int indiceRondas = 0;

        public static bool RegistrarRonda(Ronda pRonda)
        {
            if (indiceRondas < arregloRondas.Length)
            {
                arregloRondas[indiceRondas] = pRonda;
                indiceRondas++;
                return true;
            }
            return false;
        }

        public static Ronda[] ObtenerTodasLasRondas()
        {
            return arregloRondas;
        }

        public static Ronda[] BuscarRondasPorIdBatalla(int pIdBatalla)
        {
            int contador = 0;
            for (int i = 0; i < indiceRondas; i++)
            {
                if (arregloRondas[i] != null && arregloRondas[i].IdBatalla == pIdBatalla)
                {
                    contador++;
                }
            }

            Ronda[] rondasDeBatalla = new Ronda[contador];
            int indiceNuevo = 0;

            for (int i = 0; i < indiceRondas; i++)
            {
                if (arregloRondas[i] != null && arregloRondas[i].IdBatalla == pIdBatalla)
                {
                    rondasDeBatalla[indiceNuevo] = arregloRondas[i];
                    indiceNuevo++;
                }
            }

            return rondasDeBatalla;
        }
    }
}
