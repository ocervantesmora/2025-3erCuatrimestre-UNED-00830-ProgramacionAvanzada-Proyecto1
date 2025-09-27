using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    namespace Entidades
    {
        public class Equipo
        {
            public int IdEquipo { get; set; }
            public int IdJugador { get; set; }
            public int IdCriatura1 { get; set; }
            public int IdCriatura2 { get; set; }
            public int IdCriatura3 { get; set; }

            public Equipo(int pIdEquipo, int pIdJugador, int pIdCriatura1, int pIdCriatura2, int pIdCriatura3)
            {
                IdEquipo = pIdEquipo;
                IdJugador = pIdJugador;
                IdCriatura1 = pIdCriatura1;
                IdCriatura2 = pIdCriatura2;
                IdCriatura3 = pIdCriatura3;
            }
        }
    }
}
