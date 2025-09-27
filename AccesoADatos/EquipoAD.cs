using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public static class EquipoAD
    {
        private static Equipo[] arregloEquipos = new Equipo[40];
        private static int indiceEquipos = 0;

        public static bool RegistrarEquipo(Equipo pEquipo)
        {
            if (indiceEquipos < arregloEquipos.Length)
            {
                arregloEquipos[indiceEquipos] = pEquipo;
                indiceEquipos++;
                return true;
            }
            return false;
        }

        public static bool ExisteIdEquipo(int pIdEquipo)
        {
            foreach (Equipo equipo in arregloEquipos)
            {
                if (equipo != null && equipo.IdEquipo == pIdEquipo)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
