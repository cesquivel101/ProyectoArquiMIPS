using ProyectoArquitectura.Bloques;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura.Caches
{
    public class Cache
    {
        public List<BloqueCache> Bloques;
        public Cache() {
            this.Bloques = new List<BloqueCache>();
        }
    }
}
