using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Inventario
    {
        public int IdJugador { get; set; }
        public int IdCriatura { get; set; }
        public int Poder { get; set; }
        public int Resistencia { get; set; }

        public Inventario(int pIdJugador, int pIdCriatura, int pPoder, int pResistencia)
        {
            IdJugador = pIdJugador;
            IdCriatura = pIdCriatura;
            Poder = pPoder;
            Resistencia = pResistencia;
        }
    }
}
