namespace Entidades
{
    public class Criatura
    {
        public int IdCriatura { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int Nivel { get; set; }
        public int Poder { get; set; }
        public int Resistencia { get; set; }
        public int Costo { get; set; }


        public Criatura(int pId, string pNombre, string pTipo, int pNivel, int pPoder, int pResistencia, int pCosto)
        {
            IdCriatura = pId;
            Nombre = pNombre;
            Tipo = pTipo;
            Nivel = pNivel;
            Poder = pPoder;
            Resistencia = pResistencia;
            Costo = pCosto;
        }
    }
}