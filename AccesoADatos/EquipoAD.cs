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

        public static Equipo[] BuscarTodosLosEquipos()
        {
            return arregloEquipos;
        }

        public static Equipo BuscarEquipoPorIdYJugador(int pIdEquipo, int pIdJugador)
        {
            foreach (Equipo equipo in arregloEquipos)
            {
                if (equipo != null && equipo.IdEquipo == pIdEquipo && equipo.IdJugador == pIdJugador)
                {
                    return equipo; // Equipo encontrado y pertenece al jugador
                }
            }
            return null;
        }

        public static Equipo[] BuscarEquiposPorJugador(int pIdJugador)
        {
            int contador = 0;
            foreach (Equipo equipo in arregloEquipos)
            {
                if (equipo != null && equipo.IdJugador == pIdJugador)
                {
                    contador++;
                }
            }
            Equipo[] equiposDelJugador = new Equipo[contador];
            int indiceNuevoArreglo = 0;
            foreach (Equipo equipo in arregloEquipos)
            {
                if (equipo != null && equipo.IdJugador == pIdJugador)
                {
                    equiposDelJugador[indiceNuevoArreglo] = equipo;
                    indiceNuevoArreglo++;
                }
            }
            return equiposDelJugador;
        }
    }
}
