using ProyectoArquitectura.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura.Bloques
{
    public class BloqueCacheDatos
    {
        private const int Valor_Inicializacion_Cache = 0;
        public BloqueDatos Bloque { get; set; }
        public string Estado { get; set; }
        public int Etiqueta { get; set; }
        public string Estado_Posicion { get; set; }

        public BloqueCacheDatos(int etiqueta)
        {

            this.Estado = Constantes.Estado_Invalido;
            this.Etiqueta = etiqueta;
            this.Estado_Posicion = Constantes.Estado_PosicionCache_Libre;
        }

        public void imprimir()
        {
            this.Bloque.imprimir();
        }

    }
}
