using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SN
{
    class CrossCor
    {
        double[] x;
        double[] y;
        double[] x_temp;
        double[] y_temp;

        public CrossCor(double[] x, double[] y, double[] x_temp, double[] y_temp)
        {
            this.x = x;
            this.y = y;
            this.x_temp = x_temp;
            this.y_temp = y_temp;
        }

        public double[][] Run(double lb, double rb, double dx, ref System.Windows.Forms.TextBox txtProg)
        {
            int num = (int)((rb - lb) / dx);
            double v0;
            double x0;
            double c = 299792.458;
            double[] x_temp_0 = new double[x_temp.Length];

            double[][] res = new double[2][];
            res[0] = new double[num];
            res[1] = new double[num];

            LinInterpolator li = new LinInterpolator(x_temp, y_temp);

            for (int i = 0; i < num; i++)
            {
                txtProg.Text = ((double)(i + 1) * 100 / num).ToString();
                txtProg.Refresh();
                
                v0 = lb + i * dx;
                res[0][i] = v0;

                double sum = 0;
                double sum_1 = 0;
                double sum_2 = 0;
                double y0;
                for (int j = 0; j < x.Length; j++)
                {
                    x0 = x[j] / (1.0 + v0 / c);
                    y0 = li.InterpUni(x0);
                    sum += y[j] * y0;
                    sum_1 += y[j] * y[j];
                    sum_2 += y0 * y0;
                }

                res[1][i] = sum / Math.Sqrt(sum_1) / Math.Sqrt(sum_2);
            }
            return res;
        }
    }
}
