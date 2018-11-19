using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRiter
{
    static class Calc
    {
        public static Random rnd;

        public static void Init()
        {
            rnd = new Random();
        }

        public static double S2(double x)
        {
            return x * x;
        }

        public static double U(double a, double b)
        {
            return a + (b - a) * rnd.NextDouble();
        }

        public static bool B()
        {
            if (rnd.Next(2) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static double Exp(double la)
        {
            return (-1.0 / la) * Math.Log(U(1e-17, 1));
        }

        public static double N(double m, double sigma)
        {
            double r = U(0, 1);
            double phi = U(0, 1);

            double res = Math.Cos(2 * Math.PI * phi) * Math.Sqrt(-2 * Math.Log(r));

            res = sigma * res + m;

            return res;
        }

    }
}
