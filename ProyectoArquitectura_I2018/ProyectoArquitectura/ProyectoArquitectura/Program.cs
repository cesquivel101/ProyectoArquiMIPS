﻿using System;
using System.Linq;

namespace ProyectoArquitectura
{
    class Program
    {
        static void Main(string[] args)
        {
            //Proceso proc = new Proceso(args.ToList());
            Proceso proc = new Proceso();
            proc.iniciarProceso();
            Console.ReadKey();
        }
    }
}