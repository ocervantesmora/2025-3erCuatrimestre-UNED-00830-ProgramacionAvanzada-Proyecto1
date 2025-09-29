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
    public class CriaturaLN
    {
        // El método principal para registrar una nueva criatura
        public string RegistrarCriatura(int pId, string pNombre, string pTipo, int pNivel, int pPoder, int pResistencia, int pCosto)
        {

            if (CriaturaAD.ExisteIDCriatura(pId)) return "Error: Ya existe una criatura registrada con este ID.";
            if (!ValidarCostoSegunNivel(pNivel, pCosto))  return "Error: El costo de la criatura no es válido para su nivel.";
            if (!ValidarNivel(pNivel)) return "Error: El nivel seleccionado no es correcto.";

            // Si pasa las validaciones, se crea el objeto para registrarlo
            Criatura nuevaCriatura = new Criatura(pId, pNombre, pTipo, pNivel, pPoder, pResistencia, pCosto);


            if (CriaturaAD.RegistrarCriatura(nuevaCriatura)) return "Criatura registrada con éxito.";
            else return "Error: No se pudo registrar la criatura.";

        }

        // Método para validar el rango de nivel (Nivel entre 1 y 5)
        private bool ValidarNivel(int pNivel)
        {
            return (pNivel > 0 && pNivel <= 5);
        }

        // Método para validar que el costo se ajuste al valor esperado para el nivel
        private bool ValidarCostoSegunNivel(int pNivel, int pCosto)
        {
            switch (pNivel)
            {
                case 1:
                    return pCosto < 100;
                case 2:
                    return pCosto >= 100 && pCosto < 300;
                case 3:
                    return pCosto >= 300 && pCosto < 600;
                case 4:
                    return pCosto >= 600 && pCosto < 1200;
                case 5:
                    return pCosto >= 1200;
                default:
                    return false;
            }
        }

        public Criatura[] ObtenerTodasLasCriaturas()
        {
            return CriaturaAD.ObtenerCriaturas();
        }

        public Criatura BuscarCriaturaPorId(int pId)
        {
            return CriaturaAD.BuscarCriaturaPorId(pId);
        }
    }
}