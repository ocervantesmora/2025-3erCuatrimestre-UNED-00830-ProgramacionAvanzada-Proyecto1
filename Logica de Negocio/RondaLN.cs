/*
 * UNED III Cuatrimestre
 * 00830 - Programacion avanzada
 * Proyecto 1: Batallas Místicas
 * Estudiante: Oscar Eduardo Cervantes Mora
 * Fecha: 2025-09-28
 * @author ocervantesmora
 */
using AccesoADatos;
using Entidades;

namespace LogicaDeNegocio
{
    public class RondaLN
    {
        // Método para registrar una ronda individual de la batalla
        public string RegistrarRonda(Ronda pRonda)
        {
            if (pRonda.IdRonda < 1 || pRonda.IdRonda > 3)   return $"Error de RondaLN: El IdRonda ({pRonda.IdRonda}) debe ser un valor entre 1 y 3.";
            if (!BatallaAD.ExisteIdBatalla(pRonda.IdBatalla))  return $"Error de RondaLN: La Batalla ID {pRonda.IdBatalla} no está registrada.";
            if (RondaAD.RegistrarRonda(pRonda)) return null;
            else return "Error de RondaLN: El almacenamiento de rondas (RondaAD) está lleno.";
        }

        public Ronda[] ObtenerRondasPorIdBatalla(int pIdBatalla)
        {
            return RondaAD.BuscarRondasPorIdBatalla(pIdBatalla);
        }
    }
}