using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcuacionesPrimeraOrden.Tipos
{
    class Ecuación
    {
        public List<double> Coeficientes;

        public Ecuación()
        {
            Coeficientes = new List<double>();
            Coeficientes.Clear();
        }

        /*Recibe los coeficientes del exponente del más bajo grado
        al más alto grado*/
        public Ecuación(double[] coeficientes)
        {
            Coeficientes = new List<double>();
            foreach (double elemento in coeficientes)
            {
                Coeficientes.Add(elemento);
            }
        }

        public Ecuación Derivar()
        {
            Ecuación Derivada = new Ecuación();

            for (int i = 1; i < this.Coeficientes.Count; i++)
            {
                Derivada.Coeficientes.Add(this.Coeficientes[i]);
                Derivada.Coeficientes[i - 1] *= i;
            }
            return Derivada;
        }

        public double Calcular(double incógnita)
        {
            double valor = 0;
            for (int i = 0; i < this.Coeficientes.Count; i++)
            {
                valor += this.Coeficientes[i] * Math.Pow(incógnita, i);
            }
            return valor;
        }
        public override string ToString()
        {
            string cadena = "";
            for (int i = this.Coeficientes.Count - 1; i >= 0; i--)
            {
                if (this.Coeficientes[i] == 0) continue;
                if (i != this.Coeficientes.Count - 1 && this.Coeficientes[i] > 0)
                    cadena += "+";
                if (this.Coeficientes[i] == -1 && i == 0) cadena += "-1";
                else if (this.Coeficientes[i] == -1)
                    cadena += "-";
                else if (this.Coeficientes[i] != 1)
                    cadena += this.Coeficientes[i];
                else if (this.Coeficientes[i] == 1 && i == 0) cadena += "1";
                if (i == 1) cadena += "x";
                else if (i != 0) cadena += "x^" + i;
                cadena += " ";
            }
            return cadena;
        }

    }
}
