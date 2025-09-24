using AccesoADatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica_de_Negocio
{
    public class JugadorLN
    {
        private JugadorAD jugadorAD;

        public JugadorLN()
        {
            jugadorAD = new JugadorAD();
        }

        public string RegistrarJugador(int pId, string pNombre, DateTime pFechaNacimiento)
        {
            // Validar que el ID del jugador no exista ya
            if (jugadorAD.ExisteIdJugador(pId))
            {
                return "Error: Ya existe un jugador registrado con este ID.";
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
            if (jugadorAD.RegistrarJugador(nuevoJugador))
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
            return jugadorAD.ObtenerJugadores();
        }

        public string ActualizarBatallasGanadas(int pId, int pBatallasGanadas)
        {
            Jugador jugador = jugadorAD.BuscarJugadorPorId(pId);
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
        
    }
}
