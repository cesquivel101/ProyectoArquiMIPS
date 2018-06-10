using ProyectoArquitectura.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura.Bloques
{
    public class BloqueCache : Bloque
    {
        private const int Valor_Inicializacion_Cache = 0;
        public string Estado { get; set; }
        public int Etiqueta { get; set; }

        public BloqueCache(int etiqueta, int tamanioBloque):base(tamanioBloque, Valor_Inicializacion_Cache)
        {

            this.Estado = Constantes.Estado_Invalido;
            this.Etiqueta = etiqueta;
        }
    }
}
