using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura
{
    public class InformacionDeEjecucion
    {
        public string Estado { get; set; }
        public string CacheEnUso { get; set; }
        public int IDHilillo { get; set; }
        public bool MasViejo { get; set; }
        // NO se si esto va aca
        public int Quantum { get; set; }
    }
}
