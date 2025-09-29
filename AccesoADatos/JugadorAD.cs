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
    public static class JugadorAD
    {
        private static Jugador[] arregloJugadores = new Jugador[20];
        private static int indiceJugadores = 0;

        public static bool RegistrarJugador(Jugador pJugador)
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

        public static Jugador[] ObtenerJugadores()
        {
            return arregloJugadores;
        }

        public static bool ExisteIdJugador(int pId)
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

        public static Jugador BuscarJugadorPorId(int pId)
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

        public static string AgregarCriaturaAInventario(int pIdJugador, Inventario pCriaturaEnInventario)
        {
            Jugador jugador = BuscarJugadorPorId(pIdJugador);

            if (jugador == null)
            {
                return "Error: No se encontró el jugador con el ID especificado.";
            }

            if (jugador.CantidadCriaturas >= jugador.InventarioCriaturas.Length)
            {
                return "Error: El inventario del jugador está lleno.";
            }

            // Agregar la criatura al inventario del jugador
            jugador.InventarioCriaturas[jugador.CantidadCriaturas] = pCriaturaEnInventario;
            jugador.CantidadCriaturas++;

            return "Criatura agregada al inventario con éxito.";
        }

        public static bool ActualizarJugador(Jugador pJugadorModificado)
        {
            if (pJugadorModificado == null)
            {
                return false;
            }

            for (int i = 0; i < indiceJugadores; i++)
            {
                if (arregloJugadores[i] != null && arregloJugadores[i].IdJugador == pJugadorModificado.IdJugador)
                {
                    arregloJugadores[i] = pJugadorModificado;
                    return true;
                }
            }

            return false;
        }
    }
}
