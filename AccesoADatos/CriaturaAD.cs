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
    public static class CriaturaAD
    {
        private static Criatura[] arregloCriaturas = new Criatura[20];
        private static int indiceCriaturas = 0;

        public static bool RegistrarCriatura(Criatura pCriatura)
        {
            if (indiceCriaturas < arregloCriaturas.Length)
            {
                arregloCriaturas[indiceCriaturas] = pCriatura;
                indiceCriaturas++;
                return true;
            }
            else return false;
        }

        public static Criatura[] ObtenerCriaturas()
        {
            return arregloCriaturas;
        }

        public static bool ExisteIDCriatura(int pId)
        {
            foreach (Criatura criatura in arregloCriaturas)
            {
                if (criatura != null && criatura.IdCriatura == pId) return true;
            }
            return false;
        }

        public static Criatura BuscarCriaturaPorId(int pId)
        {
            foreach (Criatura criatura in arregloCriaturas)
            {
                if (criatura != null && criatura.IdCriatura == pId)
                {
                    return criatura;
                }
            }
            return null;
        }
    }
}