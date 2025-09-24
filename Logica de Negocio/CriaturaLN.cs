using AccesoADatos;
using Entidades;

namespace LogicaDeNegocio
{
    public class CriaturaLN
    {
        private CriaturaAD criaturaAD;

        public CriaturaLN()
        {
            criaturaAD = new CriaturaAD();
        }

        public string RegistrarCriatura(int pId, string pNombre, string pTipo, int pNivel, int pPoder, int pResistencia, int pCosto)
        {
            if (criaturaAD.ExisteIDCriatura(pId))
            {
                return "Error: Ya existe una criatura registrada con este ID.";
            }

            if (!ValidarCostoSegunNivel(pNivel, pCosto))
            {
                return "Error: El costo de la criatura no es válido para su nivel.";
            }

            if (!ValidarNivel(pNivel)) 
            {
                return "Error: El nivel seleccionado no es correcto.";
            }

            Criatura nuevaCriatura = new Criatura(pId, pNombre, pTipo, pNivel, pPoder, pResistencia, pCosto);

            if (criaturaAD.RegistrarCriatura(nuevaCriatura))
            {
                return "Criatura registrada con éxito.";
            }
            else return "Error: No se pudo registrar la criatura.";

        }

        private bool ValidarNivel(int pNivel)
        {
            return (pNivel > 0 && pNivel <= 5);
        }

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
            return criaturaAD.ObtenerCriaturas();
        }
    }
}