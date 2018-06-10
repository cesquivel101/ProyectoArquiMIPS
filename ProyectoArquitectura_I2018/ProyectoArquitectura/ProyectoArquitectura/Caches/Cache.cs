using ProyectoArquitectura.Bloques;
using ProyectoArquitectura.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura.Caches
{
    public class Cache
    {
        public List<BloqueCache> Bloques;
        //Tipo 0 es para cache de datos
        public Cache(int numeroDeBloques, int tipo) {
            this.Bloques = new List<BloqueCache>();
            int tamanioBloque = tipo == 0 ? Constantes.Cache_Datos_Tamanio_Bloque : Constantes.Cache_Instrucciones_Tamanio_Bloque;
            for(int i = 0; i < numeroDeBloques;i++)
            {
                this.Bloques.Add(new BloqueCache(i,tamanioBloque));
            }
        }
    }
}
