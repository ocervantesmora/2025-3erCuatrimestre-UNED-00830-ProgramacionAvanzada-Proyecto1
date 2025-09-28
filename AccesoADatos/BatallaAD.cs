using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                if (pBatalla.Ganador != 0) JugadorAD.IncrementarBatallasGanadas(pBatalla.Ganador);
                return true;
            }
            return false;
        }

        public static bool ExisteIdBatalla(int pIdBatalla)
        {
            foreach (Batalla batalla in arregloBatallas)
            {
                if (batalla != null && batalla.IdBatalla == pIdBatalla)
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
