using AccesoADatos;
using Entidades;
using LogicaDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica_de_Negocio
{
    public class JugadorLN
    {
        private CriaturaLN criaturaLN;
        public JugadorLN()
        {
            criaturaLN = new CriaturaLN();
        }
        public string RegistrarJugador(int pId, string pNombre, DateTime pFechaNacimiento)
        {
            // Validar que el ID del jugador no exista ya
            if (JugadorAD.ExisteIdJugador(pId))
            {
                return "Error: Ya existe un jugador registrado con este ID.";
            }

            if (string.IsNullOrEmpty(pNombre))
            {
                return "Error: El nombre del jugador no puede estar vacío.";
            }

            if (!ValidarEdad(pFechaNacimiento))
            {
                return "Error: El jugador debe tener más de 10 años para registrarse.";
            }

            // Crear una nueva instancia de Jugador.
            // Los valores de Nivel, Cristales y BatallasGanadas se inicializan
            // automáticamente en el constructor de la clase Jugador.
            Jugador nuevoJugador = new Jugador(pId, pNombre, pFechaNacimiento);

            // Registrar el jugador en la capa de Acceso a Datos
            if (JugadorAD.RegistrarJugador(nuevoJugador))
            {
                return "Jugador registrado con éxito.";
            }
            else
            {
                return "Error: No se pudo registrar el jugador. El almacenamiento está lleno.";
            }
        }

        private bool ValidarEdad(DateTime pFechaNacimiento)
        {
            DateTime fechaActual = DateTime.Now;
            int edad = fechaActual.Year - pFechaNacimiento.Year;

            // Ajuste para el caso en que el cumpleaños no ha pasado aún este año
            if (pFechaNacimiento.Date > fechaActual.AddYears(-edad))
            {
                edad--;
            }

            // La validación de negocio
            return edad > 10;
        }

        public Jugador[] ObtenerTodosLosJugadores()
        {
            return JugadorAD.ObtenerJugadores();
        }

        public string ActualizarBatallasGanadas(int pId, int pBatallasGanadas)
        {
            Jugador jugador = JugadorAD.BuscarJugadorPorId(pId);
            if (jugador != null)
            {
                jugador.BatallasGanadas = pBatallasGanadas;
                jugador.Nivel = RecalcularNivel(jugador.BatallasGanadas);
                return "Batallas y nivel del jugador actualizados.";
            }
            else
            {
                return "Error: No se encontró el jugador con ese ID.";
            }
        }

        private int RecalcularNivel(int batallasGanadas)
        {
            // Lógica para recalcular el nivel
            if (batallasGanadas >= 20) return 4;
            if (batallasGanadas >= 10) return 3;
            if (batallasGanadas >= 5) return 2;
            return 1;
        }

        public string AgregarCriaturaAInventario(int pIdJugador, int pIdCriatura, int pPoder, int pResistencia)
        {
            
            Jugador jugador = JugadorAD.BuscarJugadorPorId(pIdJugador);
            Criatura criatura = criaturaLN.BuscarCriaturaPorId(pIdCriatura);

            if (jugador == null)
            {
                return "Error: No se encontró el jugador.";
            }

            if (criatura == null)
            {
                return "Error: No se encontró la criatura.";
            }

            if (CriaturaYaEstaEnInventario(jugador, pIdCriatura))
            {
                return "Error: La criatura ya se encuentra en el inventario del jugador.";
            }


            if (jugador.Cristales < criatura.Costo)
            {
                return "Error: El jugador no tiene suficientes cristales para agregar esta criatura.";
            }

            Inventario nuevoInventario = new Inventario(pIdJugador, pIdCriatura, pPoder, pResistencia);

            jugador.Cristales -= criatura.Costo;

            return JugadorAD.AgregarCriaturaAInventario(pIdJugador, nuevoInventario);
        }

        public bool CriaturaYaEstaEnInventario(Jugador pJugador, int pIdCriatura)
        {

            foreach (var criaturaInventario in pJugador.InventarioCriaturas)
            {
                if (criaturaInventario != null && criaturaInventario.IdCriatura == pIdCriatura)
                {
                    return true; // La criatura ya existe en el inventario
                }
            }
            return false; // La criatura no se encontró
        }

    }
}
