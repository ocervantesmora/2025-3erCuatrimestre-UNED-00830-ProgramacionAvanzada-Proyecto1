using AccesoADatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    public class BatallaLN
    {
        private JugadorLN jugadorLN = new JugadorLN();
        private EquipoLN equipoLN = new EquipoLN();

        public string RegistrarBatalla(int pIdBatalla, int pIdJugador1, int pIdEquipo1, int pIdJugador2, int pIdEquipo2, int pGanador)
        {
            if (BatallaAD.ExisteIdBatalla(pIdBatalla))
            {
                return "Error: Ya existe una batalla registrada con el ID " + pIdBatalla + ". El ID debe ser único.";
            }

            if (pIdJugador1 == pIdJugador2)
            {
                return "Error: Un jugador no puede batallar contra sí mismo.";
            }

            string errorValidacion = ValidarJugadoresYEquipos(pIdJugador1, pIdEquipo1, pIdJugador2, pIdEquipo2);
            if (!string.IsNullOrEmpty(errorValidacion))
            {
                return errorValidacion;
            }

            Batalla nuevaBatalla = new Batalla(
                pIdBatalla,
                pIdJugador1,
                pIdEquipo1,
                pIdJugador2,
                pIdEquipo2,
                pGanador,
                DateTime.Now
            );

            if (BatallaAD.RegistrarBatalla(nuevaBatalla))
            {
                return $"Batalla registrada con éxito. Ganador (ID): {pGanador}.";
            }
            else
            {
                return "Error: El almacenamiento de batallas está lleno y no se pudo registrar.";
            }
        }

        private string ValidarJugadoresYEquipos(int pIdJ1, int pIdE1, int pIdJ2, int pIdE2)
        {
            // Jugador 1 y Equipo 1
            if (jugadorLN.BuscarJugadorPorId(pIdJ1) == null)
            {
                return $"Error: Jugador 1 con ID {pIdJ1} no se encuentra registrado.";
            }
            if (equipoLN.BuscarEquipoPorIdYJugador(pIdE1, pIdJ1) == null)
            {
                return $"Error: El Equipo 1 con ID {pIdE1} no existe o no pertenece al Jugador 1 (ID {pIdJ1}).";
            }

            // Jugador 2 y Equipo 2
            if (jugadorLN.BuscarJugadorPorId(pIdJ2) == null)
            {
                return $"Error: Jugador 2 con ID {pIdJ2} no se encuentra registrado.";
            }
            if (equipoLN.BuscarEquipoPorIdYJugador(pIdE2, pIdJ2) == null)
            {
                return $"Error: El Equipo 2 con ID {pIdE2} no existe o no pertenece al Jugador 2 (ID {pIdJ2}).";
            }

            return null;
        }

        public Batalla[] ObtenerTodasLasBatallas()
        {
            return BatallaAD.BuscarTodasLasBatallas();
        }
    }
}
