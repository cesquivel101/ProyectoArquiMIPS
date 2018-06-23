using ProyectoArquitectura.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura.Bloques
{
    public class BloqueCacheInstrucciones
    {
        private const int Valor_Inicializacion_Cache = 0;
        public BloqueInstrucciones Bloque { get; set; }
        public string Estado { get; set; }
        public int Etiqueta { get; set; }

        public BloqueCacheInstrucciones(int etiqueta)
        {
            this.Estado = Constantes.Estado_Invalido;
            this.Etiqueta = etiqueta;
            this.Bloque = new BloqueInstrucciones();
        }

        public void imprimir()
        {
            Console.Write("Estado:" + this.Estado+";");
            Console.Write("Etiqueta:" + this.Etiqueta);
            Console.WriteLine();
            if (this.Bloque != null)
            {
                Bloque.imprimir();
            }
        }
    }
}
