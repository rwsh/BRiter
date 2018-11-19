using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRiter
{
    class TGame
    {
        int N;
        int L;

        double[] X, Y;
        int[] iX, iY;

        double[,] A;

        double v_max = 0;
        double v_min = 0;

        public TGame()
        {
            Calc.Init();

            L = 1000000;
            N = 3;

            X = new double[N];
            Y = new double[N];

            iX = new int[N];
            iY = new int[N];

            X[0] = 1;
            X[1] = 2;
            X[2] = 3;

            Y[0] = 1;
            Y[1] = 2;
            Y[2] = 3;

            FormA();

            Run();

            for (int n = 0; n < N; n++)
            {
                X[n] = iX[n] / (double)L;
                Y[n] = iY[n] / (double)L;
            }

            v_max /= L;
            v_min /= L;

            Console.WriteLine("V = {0}\t{1}", v_max, v_min);

            for (int n = 0; n < N; n++)
            {
                Console.Write("{0}\t", X[n]);
            }
            Console.WriteLine("\n");

            for (int n = 0; n < N; n++)
            {
                Console.Write("{0}\t", Y[n]);
            }
            Console.WriteLine("\n");

        }

        void Run()
        {
            iX[0] = 1;
            iY[0] = 1;

            for (int l = 0; l < L; l++)
            {
                double max = double.MinValue;
                int max_i = 0;

                for (int i = 0; i < N; i++)
                {
                    if (ForMax(i) > max)
                    {
                        max = ForMax(i);
                        max_i = i;
                    }
                }

                double min = double.MaxValue;
                int min_j = 0;

                for (int j = 0; j < N; j++)
                {
                    if (ForMin(j) < min)
                    {
                        min = ForMin(j);
                        min_j = j;
                    }
                }

                iX[max_i]++;
                iY[min_j]++;

                v_max = max;
                v_min = min;
            }
        }

        double ForMax(int i)
        {
            double Res = 0;

            for (int j = 0; j < N; j++)
            {
                Res += A[i, j] * iY[j];
            }

            return Res;
        }

        double ForMin(int j)
        {
            double Res = 0;

            for (int i = 0; i < N; i++)
            {
                Res += A[i, j] * iX[i];
            }

            return Res;
        }

        void FormA()
        {
            A = new double[N, N];

            Console.WriteLine("A\n");

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    A[i, j] = X[i] - Y[j] + Calc.N(0, 3);

                    Console.Write("{0}\t", A[i, j]);
                }
                Console.Write("\n");
            }

            Console.Write("\n");
        }
    }
}
