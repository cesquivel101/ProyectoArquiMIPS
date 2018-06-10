using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura
{
    public class Contexto
    {
        public List<int> Registros { get; set; }
        public int PC { get; set; }
        //Esto lo usamos para saber cuando se acaba el hilillo
        //Lo calculamos en el momento en que estamos cargando los hilillos a memoria
        public int PosicionInstruccionFinal { get; set; }
        public Contexto()
        {
            inicializarRegistros(-1);
            this.PC = 0;
        }

        public void inicializarRegistros(int valorInicial)
        {
            for (int i = 0; i < this.Registros.Count; i++)
            {
                this.Registros[i] = valorInicial;
            }
        }
    }
}
