using ProyectoArquitectura.Bloques;
using ProyectoArquitectura.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura.Caches
{
    public class CacheInstrucciones
    {
        public List<BloqueCacheInstrucciones> Bloques;
        //Tipo 0 es para cache de datos
        public CacheInstrucciones()
        {
            this.Bloques = new List<BloqueCacheInstrucciones>();
            for (int i = 0; i < Constantes.Numero_Bloques_Cache; i++)
            {
                this.Bloques.Add(new BloqueCacheInstrucciones(i));
            }
        }
    }
}
