using Entidades;

namespace AccesoADatos
{
    public class CriaturaAD
    {
        private Criatura[] arregloCriaturas;
        private int indiceCriaturas;

        public CriaturaAD()
        {
            arregloCriaturas = new Criatura[20];
            indiceCriaturas = 0;
        }

        public bool RegistrarCriatura(Criatura pCriatura)
        {
            if (indiceCriaturas < arregloCriaturas.Length)
            {
                arregloCriaturas[indiceCriaturas] = pCriatura;
                indiceCriaturas++;
                return true;
            }
            else return false;
        }

        public Criatura[] ObtenerCriaturas()
        {
            return arregloCriaturas;
        }

        public bool ExisteIDCriatura(int pId)
        {
            foreach (Criatura criatura in arregloCriaturas)
            {
                if (criatura != null && criatura.IdCriatura == pId) return true;
            }
            return false;
        }

    }
}