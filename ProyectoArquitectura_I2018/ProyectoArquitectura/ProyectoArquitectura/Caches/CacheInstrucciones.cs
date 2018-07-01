using ProyectoArquitectura.Bloques;
using ProyectoArquitectura.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura.Caches
{
    /// <summary>
    /// Clase que simula una cache de instrucciones
    /// </summary>
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

        public void imprimir()
        {
            foreach (BloqueCacheInstrucciones bl in this.Bloques)
            {
                bl.imprimir();
            }
        }
    }
}
