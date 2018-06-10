using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoArquitectura
{
    public class Contexto
    {
        public List<int> Registros { get; set; }
        public int PC { get; set; }
        public int IDHilillo { get; set; }
        //Esto lo usamos para saber cuando se acaba el hilillo
        //Lo calculamos en el momento en que estamos cargando los hilillos a memoria
        public int PosicionInstruccionFinal { get; set; }
        public Contexto()
        {
            inicializarRegistros(-1);
            this.PC = 0;
            this.IDHilillo = -1;
            this.PosicionInstruccionFinal = -1;
        }

        public Contexto(int idHilillo, int posicionInstruccionFinal)
        {
            inicializarRegistros(-1);
            this.PC = 0;
            this.IDHilillo = idHilillo;
            this.PosicionInstruccionFinal = posicionInstruccionFinal;

        }

        public void inicializarRegistros(int valorInicial)
        {
            this.Registros = new List<int>();
            for (int i = 0; i < this.Registros.Count; i++)
            {
                this.Registros.Add(valorInicial);
            }
        }
    }
}
