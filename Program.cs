using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcuacionesPrimeraOrden.Procesos;
using EcuacionesPrimeraOrden.Tipos;

namespace EcuacionesPrimeraOrden
{
    class Program
    {

        static void Main(string[] args)
        {
            Ecuación PorResolver;
            Solver Solución;
            int gradoMax;
            double intento;
            double[] arregloValores;

            while (true)
            {
                try
                {
                    Console.Write("Grado máximo (al menos 1): ");
                    gradoMax = int.Parse(Console.ReadLine());
                    if (gradoMax < 1) throw new ArgumentOutOfRangeException();
                    arregloValores = new double[gradoMax + 1];
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            for (int i = gradoMax; i >= 0; i--)
            {
                while (true)
                {
                    try
                    {
                        Console.Write("Coeficiente de grado {0}: ", i);
                        arregloValores[i] = double.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Intento inicial: ");
                    intento = double.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }



            PorResolver = new Ecuación(arregloValores);
            Solución = new Solver(PorResolver);
            Console.WriteLine("\nEcuación: {0}=0", PorResolver.ToString());
            try
            {
                Console.WriteLine("Solución aproximada: {0} ", Solución.Solucionar(intento));
                Console.WriteLine("Encontrada en {0} aproximaci{1}, exactitud ± {2}", Solución.Ciclos, (Solución.Ciclos == 1)?"ón":"ones", Solver.variación);
            }
            catch(Exception ex)
            {
                Console.WriteLine("No se pudo encontrar una solución real en {0} aproximaciones", Solver.maxCiclos.ToString("N0"));
            }
            Console.ReadLine();
        }
    }
}
