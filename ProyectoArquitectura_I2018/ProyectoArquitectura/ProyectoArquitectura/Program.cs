using System;

namespace ProyectoArquitectura
{
    class Program
    {
        static void Main(string[] args)
        {
            Proceso proc = new Proceso();
            proc.iniciarProceso();
            Console.ReadKey();
        }
    }
}