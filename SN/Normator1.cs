using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FITS_READER
{
    class Normator1
    {
        public static double[] FitCurve = null;

        public static double[] lambdaRej = null;

        public static double[] fluxRej = null;

        private static int poly_degree;

        private static double[] coeffs;

        private static double flx_max;

        private static double lambda_max;

        private static double lambda_min;

        private static string func_type;

        public static double[] OrderNorm = null;

        private static double stddev;

        public static SN.LinInterpolator linterp;
        
        public static void Norm(double[] lambdas, double[] order, double[] lambda0, 
            double[] inten0, int polynom_degree, double lower, double upper, int iterNum, string funcType)
        {
            func_type = funcType;
            poly_degree = polynom_degree;
            int lambda_count = order.Length;
            OrderNorm = new double[lambda_count];

            linterp = new SN.LinInterpolator(lambda0, inten0);

            FitCurve = new double[lambda_count];

            double[] orders1 = new double[lambda_count];

            flx_max = order.Max();
            for (int j = 0; j < lambda_count; j++)
            {
                orders1[j] = order[j] / flx_max;
            }

            lambda_max = lambdas.Max();
            lambda_min = lambdas.Min();
            
            for (int i = 0; i < lambdas.Length; i++)
            {
                lambdas[i] = (2 * lambdas[i] - 
                    (lambda_max + lambda_min)) / (lambda_max - lambda_min);
            }

            double[] sigmas = new double[lambda_count];

            for (int j = 0; j < sigmas.Length; j++)
            {
                sigmas[j] = orders1[j];
                if (orders1[j] * flx_max > 1)
                {
                    sigmas[j] = Math.Sqrt(orders1[j]);
                    //sigmas[j] = 1;
                }
                else
                {
                    sigmas[j] = 1;
                }
            }

            lambdaRej = new double[lambda_count];

            fluxRej = new double[lambda_count];

            int count_rej = 0;

            FitSVD fitterSVD = null;

            for (int i = 0; i < iterNum; i++)
            {
                
                if(funcType=="chebyshev")
                    fitterSVD = new FitSVD(lambdas, orders1, sigmas, chebyshev, 1e-14);
                if (funcType == "simple")
                    fitterSVD = new FitSVD(lambdas, orders1, sigmas, polynom, 1e-14);
                
                fitterSVD.fit();
                
                coeffs = fitterSVD.FittedCoeffs;

                stddev = 0;
                for (int j = 0; j < lambdas.Length; j++)
                {
                    double sum = 0;
                    //for (int k = 0; k < polynom_degree + 1; k++)
                    //{
                    //    sum += Math.Pow(lambdas[j], k) * coeffs[k];
                    //}
                    if(func_type=="simple")
                        sum = simple_calc(coeffs, lambdas[j]);
                    if (func_type == "chebyshev")
                        sum = chebyshev_calc(coeffs, lambdas[j]);

                    FitCurve[j] = sum;
                    OrderNorm[j] = orders1[j] / FitCurve[j];
                    stddev += Math.Pow(OrderNorm[j] - inten0[j], 2);
                }
                
                stddev = Math.Sqrt(stddev / lambdas.Length);
                int count = 0;

                if (i < iterNum - 1)
                {
                    for (int j = 0; j < lambdas.Length; j++)
                    {
                        if ((OrderNorm[j] - inten0[j]) <= upper * stddev &&
                            (inten0[j] - OrderNorm[j]) <= lower * stddev)
                        {
                            lambdas[count] = lambdas[j];
                            orders1[count] = orders1[j];
                            count++;
                        }
                        else
                        {
                            lambdaRej[count_rej] = 0.5 * (lambdas[j] * (lambda_max - lambda_min)
                                + (lambda_max + lambda_min));
                            fluxRej[count_rej] = orders1[j] * flx_max;
                            count_rej++;
                        }
                    }
                }
                
                Array.Resize(ref lambdas, count);
                Array.Resize(ref orders1, count);
            }
            Array.Resize(ref lambdaRej, count_rej);
            Array.Resize(ref fluxRej, count_rej);
        }

        public static double[] LambdaRejected
        {
            get
            {
                return lambdaRej;
            }
        }

        public static double Continum(double lambda)
        {
            double sum = 0;
            lambda = (2 * lambda -
                    (lambda_max + lambda_min)) / (lambda_max - lambda_min);
            if (func_type == "simple")
                sum = simple_calc(coeffs, lambda);
            if (func_type == "chebyshev")
                sum = chebyshev_calc(coeffs, lambda);

            return sum * flx_max;
        }

        public static double StdDev { get { return stddev; } }

        private static double simple_calc(double[] coeffs, double x)
        {
            double ans = 0;
            for (int i = 0; i < coeffs.Length; i++)
            {
                ans += coeffs[i] * Math.Pow(x, i);
            }
            return ans;
        }

        private static double chebyshev_calc(double[] coeffs, double x)
        {
            double[] ff = new double[poly_degree + 1];
            ff[0] = 1.0;
            if (poly_degree > 0)
                ff[1] = x;
            for (int i = 2; i <= poly_degree; i++)
            {
                ff[i] = 2 * x * ff[i - 1] - ff[i - 2];
            }

            double ans = 0;
            for (int i = 0; i < poly_degree + 1; i++)
            {
                ans += ff[i] * coeffs[i];
            }
            return ans;
        }

        private static double[] polynom(double x)
        {
            double[] ans = new double[poly_degree + 1];
            ans[0] = 1.0;
            for (int i = 1; i < poly_degree + 1; i++) ans[i] = x * ans[i - 1];
            for (int i = 0; i < poly_degree + 1; i++)
                ans[i] *= linterp.InterpUni(0.5 * (x * (lambda_max - lambda_min) + (lambda_max + lambda_min)));
            return ans;
        }

        private static double[] chebyshev(double x)
        {
            double[] ans = new double[poly_degree + 1];
            ans[0] = 1.0;
            if (poly_degree > 0)
                ans[1] = x;
            for (int i = 2; i <= poly_degree; i++)
            {
                ans[i] = 2 * x * ans[i - 1] - ans[i - 2];
            }

            for (int i = 0; i <= poly_degree; i++)
            {
                ans[i] *= linterp.Interp(0.5 * (x * (lambda_max - lambda_min)
                            + (lambda_max + lambda_min)));
            }

            return ans;
        }
    }
}
