using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SN
{
    /// <summary>
    /// Basic matrix and vector operations.
    /// </summary>
    public class Basic
    {

        public static void ATrA(ref double[][] a, ref double[][] res)
        {
            if (res.Length != res[0].Length)
            {
                return;
            }
            
            int size = res.Length;
            double sum;
            for (int i = 0; i < size; i++)
            {
                for (int j = i; j < size; j++)
                {
                    sum = 0;
                    for (int k = 0; k < a.Length; k++)
                    {
                        sum = sum + a[k][i] * a[k][j];
                    }
                    res[i][j] = sum;
                    res[j][i] = sum;
                }
            }
        }

        public static void ATrA2(ref double[][] a, ref double[][] res)
        {
            if (res.Length != res[0].Length)
            {
                return;
            }

            int size = res.Length;
            double sum;
            for (int i = 0; i < size; i++)
            {
                for (int j = i; j < size; j++)
                {
                    sum = 0;
                    for (int k = 0; k < a[0].Length; k++)
                    {
                        sum = sum + a[i][k] * a[j][k];
                    }
                    res[i][j] = sum;
                    res[j][i] = sum;
                }
            }
        }

        public static void AMultB(ref double[][] a, ref double[][] b, ref double[][] res)
        {
            int resColCount = res[0].Length;
            int resRowCount = res.Length;
            int bRowCount = b.Length;
            for (int i = 0; i < resRowCount; i++)
                for (int j = 0; j < resColCount; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < bRowCount; k++)
                    {
                        sum = sum + a[i][k] * b[k][j];
                    }
                    res[i][j] = sum;
                }
        }



        public static void AMultB(ref double[][] a, ref double[] b, ref double[] res)
        {
            int resRowCount = res.Length;
            int bRowCount = b.Length;
            for (int i = 0; i < resRowCount; i++)
            {
                double sum = 0;
                for (int k = 0; k < bRowCount; k++)
                {
                    sum = sum + a[i][k] * b[k];
                }
                res[i] = sum;
            }
        }

        public static void ATrMultB(ref double[][] a, ref double[] b, ref double[] res)
        {
            int resRowCount = res.Length;
            int bRowCount = b.Length;
            for (int i = 0; i < resRowCount; i++)
            {
                double sum = 0;
                for (int k = 0; k < bRowCount; k++)
                {
                    sum = sum + a[k][i] * b[k];
                }
                res[i] = sum;
            }
        }

        public static void AMultB(ref double[] a, ref double[] b, ref double res)
        {
            int rowCount = b.Length;
            double sum = 0;
            for (int k = 0; k < rowCount; k++)
            {
                sum = sum + a[k] * b[k];
            }
            res = sum;
        }

        public static double AMultB(ref double[] a, ref double[] b)
        {
            int rowCount = RowCount(ref a);
            double sum = 0;
            for (int k = 0; k < rowCount; k++)
            {
                sum = sum + a[k] * b[k];
            }
            return sum;
        }

        public static void MAmultSC(ref double[][] a, double c)
        {
            int rowCount = RowCount(ref a);
            int colCount = ColCount(ref a);
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    a[i][j] = a[i][j] * c;
                }
            }
        }

        public static void PosrtrMult(ref double[][] a, ref double[] b)
        {
            int aColCount = a[0].Length;
            int aRowCount = a.Length;
            int bRowCount = b.Length;
            if (bRowCount != aRowCount)
            {
                return;
            }

            for (int i = 0; i < aRowCount; i++)
            {
                for (int j = 0; j < aColCount; j++)
                {
                    a[i][j] = b[i] * a[i][j];
                }
            }
        }

        public static void MAminusMB(ref double[][] a, ref double[][] b, ref double[][] res)
        {
            int resRowCount = res.Length;
            int resColCount = res[0].Length;
            for (int i = 0; i < resRowCount; i++)
            {
                for (int j = 0; j < resColCount; j++)
                {
                    res[i][j] = a[i][j] - b[i][j];
                }
            }
        }

        public static void MAplusMB(ref double[][] a, ref double[][] b, ref double[][] res)
        {
            int resRowCount = res.Length;
            int resColCount = res[0].Length;
            for (int i = 0; i < resRowCount; i++)
            {
                for (int j = 0; j < resColCount; j++)
                {
                    res[i][j] = a[i][j] + b[i][j];
                }
            }
        }

        public static void VAminusVB(ref double[] a, ref double[] b, ref double[] res)
        {
            int resRowCount = res.Length;
            for (int i = 0; i < resRowCount; i++)
            {
                res[i] = a[i] - b[i];
            }
        }

        public static double[] VAminusVB(ref double[] a, ref double[] b)
        {
            double[] res = new double[a.Length];
            int resRowCount = res.Length;
            for (int i = 0; i < resRowCount; i++)
            {
                res[i] = a[i] - b[i];
            }
            return res;
        }

        public static void VAplusVB(ref double[] a, ref double[] b, ref double[] res)
        {
            int resRowCount = res.Length;
            for (int i = 0; i < resRowCount; i++)
            {
                res[i] = a[i] + b[i];
            }
        }

        public static void VAminusVCmultMB(ref double[] a, ref double[][] b, ref double[] c, ref double[] res)
        {
            int resRowCount = res.Length;
            int bRowCount = c.Length;
            for (int i = 0; i < resRowCount; i++)
            {
                double sum = 0;
                for (int k = 0; k < bRowCount; k++)
                {
                    sum = sum + b[i][k] * c[k];
                }
                res[i] = a[i] - sum;
            }
        }

        public static void VAplusSCmultVB(ref double[] a, ref double[] b, double c, ref double[] res)
        {
            int rowCount = RowCount(ref a);

            for (int i = 0; i < rowCount; i++)
            {
                res[i] = a[i] + c * b[i];
            }
        }

        public static void VAMultSC(ref double[] a, double c)
        {
            int rowCount = RowCount(ref a);
            for (int i = 0; i < rowCount; i++)
            {
                a[i] = a[i] * c;
            }
        }

        public static int RowCount(ref double[][] a)
        {
            return a.Length;
        }

        public static int RowCount(ref double[] a)
        {
            return a.Length;
        }

        public static int ColCount(ref double[][] a)
        {
            return a[0].Length;
        }

        public static void CopyMatrix(ref double[][] a, ref double[][] res)
        {
            int rowCount = RowCount(ref a);
            int colCount = ColCount(ref a);
            if (rowCount != RowCount(ref res))
            {
                return;
            }
            if (colCount != ColCount(ref res))
            {
                return;
            }

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    res[i][j] = a[i][j];
                }
            }
        }

        public static void CopyVector(ref double[] a, ref double[] res)
        {
            int rowCount = RowCount(ref a);

            if (rowCount != RowCount(ref res))
            {
                return;
            }

            for (int i = 0; i < rowCount; i++)
            {
                res[i] = a[i];
            }
        }

        public static double[][] MatrixConstructor(int rowCount, int colCount)
        {
            double[][] a = new double[rowCount][];
            for (int i = 0; i < rowCount; i++)
            {
                a[i] = new double[colCount];
            }
            return a;
        }

        public static double[] VectorConstructor(int rowCount)
        {
            double[] x = new double[rowCount];
            return x;
        }

        public static void MA_mult_VB_minus_VC(ref double[][] a, ref double[] b, ref double[] c, ref double[] res)
        {
            double b_size = b.Length;
            double res_size = c.Length;
            double sum;
            for (int i = 0; i < res_size; i++)
            {
                sum = 0;
                for (int j = 0; j < b_size; j++)
                {
                    sum += a[i][j] * b[j];
                }
                res[i] = sum - c[i];
            }
        }
    }
}
