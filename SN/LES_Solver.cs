using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SN
{
    public class LES_Solver
    {
        static public double[] SolveWithGaussMethod(double[][] m, double[] l)
        {
            int N = l.Length;

            double[] x = new double[N];

            // Приведение матрицы m к треугольному виду
            for (int s = 0; s <= N - 2; s++)
            {
                double k1 = m[s][s];

                for (int c = s; c <= N - 1; c++)
                {
                    m[s][c] = m[s][c] / k1;
                }

                l[s] = l[s] / k1;
                for (int s1 = s + 1; s1 <= N - 1; s1++)
                {
                    double k2 = m[s1][s];
                    for (int c1 = s; c1 <= N - 1; c1++)
                    {
                        m[s1][c1] = -m[s][c1] * k2 + m[s1][c1];
                    }
                    l[s1] = -l[s] * k2 + l[s1];
                }
            }
            // обратный ход
            x[N - 1] = l[N - 1] / m[N - 1][N - 1];
            for (int i = N - 2; i >= 0; i--)
            {
                double w = 0;
                for (int j = N - 1; j > i; j--)
                {
                    w = w + x[j] * m[i][j];
                }
                x[i] = (l[i] - w);
            }
            return x;
        }

 
    }
}
