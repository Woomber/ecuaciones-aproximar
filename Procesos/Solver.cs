using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcuacionesPrimeraOrden.Tipos;

namespace EcuacionesPrimeraOrden.Procesos
{
    class Solver
    {
        Ecuación Resolver, Derivada;
        public int Ciclos;

        public const double variación = 1e-30;
        public const int maxCiclos = 5000000;

        public Solver(Ecuación resolver)
        {
            this.Resolver = resolver;
            this.Derivada = this.Resolver.Derivar();
            this.Ciclos = 0;
        }

        public double Solucionar(double intento = 1)
        {
            this.Ciclos = 0;
            while (Math.Abs(Resolver.Calcular(intento)) > variación)
            {
                intento -= Resolver.Calcular(intento) / Derivada.Calcular(intento);
                if (Ciclos++ > maxCiclos) throw new OverflowException();
            }
            return intento;
        }

        

    }
}
