/*
 * UNED III Cuatrimestre
 * 00830 - Programacion avanzada
 * Proyecto 1: Batallas Místicas
 * Estudiante: Oscar Eduardo Cervantes Mora
 * Fecha: 2025-09-28
 * @author ocervantesmora
 */
namespace Entidades
{
    public class Jugador
    {
        public int IdJugador { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Nivel { get; set; }
        public int Cristales { get; set; }
        public int BatallasGanadas { get; set; }
        public string NivelTexto 
        {
            get
            {
                switch (this.Nivel)
                {
                    case 1: return "Novato";
                    case 2: return "Estudiante";
                    case 3: return "Maestro";
                    case 4: return "Supremo";
                    default: return "Desconocido";
                }
            }
        }
        public Inventario[] InventarioCriaturas { get; set; }
        public int CantidadCriaturas { get; set; }

        public Jugador(int pId, string pNombre, DateTime pFechaNacimiento)
        {
            IdJugador = pId;
            Nombre = pNombre;
            FechaNacimiento = pFechaNacimiento;
            Nivel = 1;
            Cristales = 100;
            BatallasGanadas = 0;

            InventarioCriaturas = new Inventario[30];
            CantidadCriaturas = 0;
        }

        public override string ToString()
        {
            return this.IdJugador + " - " + this.Nombre;
        }
    }
}
