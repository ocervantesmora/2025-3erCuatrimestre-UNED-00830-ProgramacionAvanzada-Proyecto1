using AccesoADatos;
using Entidades.Entidades;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    public class EquipoLN
    {
        private JugadorLN jugadorLN = new JugadorLN();

        public string RegistrarEquipo(int pIdEquipo, int pIdJugador, int pIdCriatura1, int pIdCriatura2, int pIdCriatura3)
        {
            if (EquipoAD.ExisteIdEquipo(pIdEquipo))
            {
                return "Error: Ya existe un equipo registrado con el ID " + pIdEquipo + ". El ID debe ser único.";
            }

            Jugador jugador = JugadorAD.BuscarJugadorPorId(pIdJugador);

            if (jugador == null)
            {
                return "Error: No se encontró el jugador con el ID " + pIdJugador + ".";
            }

            int[] idsCriaturas = { pIdCriatura1, pIdCriatura2, pIdCriatura3 };

            foreach (int idCriatura in idsCriaturas)
            {
                if (!CriaturaPerteneceAInventario(jugador, idCriatura))
                {
                    return "Error: La criatura con ID " + idCriatura + " no se encuentra en el inventario del jugador " + jugador.Nombre + ".";
                }
            }

            Equipo nuevoEquipo = new Equipo(pIdEquipo, pIdJugador, pIdCriatura1, pIdCriatura2, pIdCriatura3);

            if (EquipoAD.RegistrarEquipo(nuevoEquipo))
            {
                return "Equipo registrado con éxito para el jugador " + jugador.Nombre + ".";
            }
            else
            {
                return "Error: El almacenamiento de equipos está lleno y no se pudo registrar.";
            }
        }

        private bool CriaturaPerteneceAInventario(Jugador pJugador, int pIdCriatura)
        {
            foreach (var inventarioItem in pJugador.InventarioCriaturas)
            {
                if (inventarioItem != null && inventarioItem.IdCriatura == pIdCriatura)
                {
                    return true;
                }
            }
            return false;
        }

        public Equipo[] ObtenerTodosLosEquipos()
        {
            return EquipoAD.BuscarTodosLosEquipos();
        }

        public Equipo BuscarEquipoPorIdYJugador(int pIdEquipo, int pIdJugador)
        {
            // Delega la búsqueda a la capa de Acceso a Datos
            return EquipoAD.BuscarEquipoPorIdYJugador(pIdEquipo, pIdJugador);
        }

        public Equipo[] ObtenerEquiposPorIdJugador(int pIdJugador)
        {
            return EquipoAD.BuscarEquiposPorJugador(pIdJugador);
        }
    }
}
