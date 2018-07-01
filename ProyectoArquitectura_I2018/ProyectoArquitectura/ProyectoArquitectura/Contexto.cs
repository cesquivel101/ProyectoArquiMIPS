using ProyectoArquitectura.Helpers;
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
        //No estoy seguro de dejar esto o si nos sirve, podemos asumir que si el PC esta en finalizado (algun valor -1 o asi)
        //Podemos usar eso para inferir que se termino el hilillo.
        public int PosicionInstruccionFinal { get; set; }

        //Hay que agregar el timpo total de ejecucion del hilillo ==> en tiempos de ciclo de la maquina//
        //Tener ciclo en el que entro y ciclo en el que salio para calcular el total.
        public int CicloInicial { get; set; }

        public int CicloFinal { get; set; }


        //No estoy seguro si va aca
        public int Quantum { get; set; }

        private int numCiclosEjecutandose;

        public Contexto()
        {
            inicializarRegistros(0);
            this.PC = 0;
            this.IDHilillo = -1;
            this.PosicionInstruccionFinal = -1;
            this.CicloInicial = -1;
            this.CicloFinal = -1;
            this.numCiclosEjecutandose = -1;
        }

        public Contexto(int pc,int idHilillo, int posicionInstruccionFinal)
        {
            inicializarRegistros(0);
            this.PC = pc;
            this.IDHilillo = idHilillo;
            this.PosicionInstruccionFinal = posicionInstruccionFinal;
            this.CicloInicial = -1;
            this.CicloFinal = -1;
            this.numCiclosEjecutandose = -1;
        }

        public void inicializarRegistros(int valorInicial)
        {
            this.Registros = new List<int>();
            for (int i = 0; i < Constantes.Cantidad_Registros; i++)
            {
                this.Registros.Add(valorInicial);
            }
        }

        public void imprimir()
        {
            Console.WriteLine("---------------");
            Console.WriteLine("Contexto");
            Console.WriteLine("\tRegistros:");
            foreach (int registro in this.Registros)
            {
                Console.Write(registro + " ");
            }
            Console.WriteLine();
            Console.WriteLine("\tPC:" + this.PC + "; IDHilillo: " + this.IDHilillo + "; PosInsFinal: " + this.PosicionInstruccionFinal);
            Console.WriteLine("---------------");
        }

        public void impresionFinal()
        {
            Console.WriteLine("\tRegistros:");
            foreach (int registro in this.Registros)
            {
                Console.Write(registro + " ");
            }
            this.numCiclosEjecutandose = this.CicloFinal - this.CicloInicial;
            Console.WriteLine("ID Hilillo: " + this.IDHilillo + "; Ciclos de ejecucion: " + this.numCiclosEjecutandose);

        }
    }
}
