using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class JugadorAD
    {
        private Jugador[] arregloJugadores;
        private int indiceJugadores;

        public JugadorAD()
        {
            arregloJugadores = new Jugador[20];
            indiceJugadores = 0;
        }

        public bool RegistrarJugador(Jugador pJugador)
        {
            if (indiceJugadores < arregloJugadores.Length)
            {
                arregloJugadores[indiceJugadores] = pJugador;
                indiceJugadores++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Jugador[] ObtenerJugadores()
        {
            return arregloJugadores;
        }

        public bool ExisteIdJugador(int pId)
        {
            foreach (Jugador jugador in arregloJugadores)
            {
                if (jugador != null && jugador.IdJugador == pId)
                {
                    return true;
                }
            }
            return false;
        }

        public Jugador BuscarJugadorPorId(int pId)
        {
            foreach (Jugador jugador in arregloJugadores)
            {
                if (jugador != null && jugador.IdJugador == pId)
                {
                    return jugador;
                }
            }
            return null;
        }
    }
}
