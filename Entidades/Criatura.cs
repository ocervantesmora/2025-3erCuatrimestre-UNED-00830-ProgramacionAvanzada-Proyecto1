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
        public string NivelTexto
        {
            get
            {
                switch(this.Nivel)
                {
                    case 1: return "01 - Iniciado";
                    case 2: return "02 - Aprendiz";
                    case 3: return "03 - Estudiante";
                    case 4: return "04 - Avanzado";
                    case 5: return "05 - Maestro";
                    default: return "Desconocido";
                }
            }
        }


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

        public override string ToString()
        {
            return $"{IdCriatura} - {Nombre}";
        }
    }
}