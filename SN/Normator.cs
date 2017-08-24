using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SN
{
    public class Normator
    {
        // input;
        private double[][] tempSpectrum;
        private double[][] obsSpectrum;
        private int polynomOrder;
        private double weight = 0;
        // output;
        private double[] polyPars;

        public double[][] TempSpectrum
        {
            get
            {
                return this.tempSpectrum;
            }
            set
            {
                this.tempSpectrum = value;
            }
        }

        public double[][] ObsSpectrum
        {
            get
            {
                return this.obsSpectrum;
            }
            set
            {
                this.obsSpectrum = value;
            }
        }

        public int PolynomOrder
        {
            get
            {
                return this.polynomOrder;
            }
            set
            {
                this.polynomOrder = value;
            }
        }

        public void Normalize()
        {
            double bias = 1e30;
            int sections = 20;
            double[] averanges = new double[sections];
            double[] biasCoeff = new double[this.obsSpectrum[0].Length];

            this.polyPars = new double[this.polynomOrder+1];
            Spline31D spline = new Spline31D(this.tempSpectrum[0], this.tempSpectrum[1]);

            double[] x = new double[this.obsSpectrum[0].Length];
            double maxLambda = this.obsSpectrum[0][this.obsSpectrum[0].Length - 1];
            double minLambda = this.obsSpectrum[0][0];
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = (this.obsSpectrum[0][i] - minLambda) / (maxLambda - minLambda);
            }

            double[] b = new double[this.polynomOrder + 1];
            double[][] r = new double[this.polynomOrder + 1][];
            for (int i = 0; i < polynomOrder + 1; i++)
            {
                r[i] = new double[this.polynomOrder + 1];
            }

            double[] syn = new double[this.obsSpectrum[0].Length];
            for (int i = 0; i < syn.Length; i++)
            {
                syn[i] = spline.Interp(this.obsSpectrum[0][i]);
            }

            for (int i = 0; i < averanges.Length; i++)
            {
                double sum = 0;
                double ave;
                int size = syn.Length / averanges.Length;
                for (int j = 0; j < size; j++)
                {
                    sum += syn[j + i * size];
                }
                ave = sum / size;
                averanges[i] = ave;
            }
            for (int i = 0; i < biasCoeff.Length; i++)
            {
                int secNum;
                secNum = i / (syn.Length / averanges.Length);
                if (syn[i] > averanges[secNum])
                {
                    biasCoeff[i] = bias*(syn[i]-averanges[secNum]);
                }
                else
                {
                    biasCoeff[i] = 0;
                }
            }


            for (int l = 0; l < this.polynomOrder + 1; l++)
            {
                double sum = 0;
                for (int i = 0; i < obsSpectrum[0].Length; i++)
                {
                    sum = sum + syn[i] * obsSpectrum[1][i] * Math.Pow(x[i], l) * biasCoeff[i] * biasCoeff[i];
                }
                b[l] = sum;
            }

            for (int l = 0; l < this.polynomOrder + 1; l++)
            {
                for (int k = 0; k <=l; k++)
                {
                    double sum = 0;
                    for (int i = 0; i < obsSpectrum[0].Length; i++)
                    {
                        sum = sum + Math.Pow(syn[i]*biasCoeff[i], 2) * Math.Pow(x[i], l) *
                            Math.Pow(x[i], k);
                    }
                    r[l][k] = sum;
                    r[k][l] = sum;
                }
            }

            this.polyPars = LES_Solver.SolveWithGaussMethod(r, b);
        }

        public void NormalizeLM(double iterNumber)
        {
            Spline31D spline;
            double[] x;
            double maxLambda, minLambda;
            double[] b;
            double[][] r;
            double[] wm;
            double[] syn;
            double[] sigma;
            double[][] G;
            double[] data;
            double[] dw;
            
            this.polyPars = new double[this.polynomOrder + 1];
            
            spline = new Spline31D(this.tempSpectrum[0], this.tempSpectrum[1]);

            x = new double[this.obsSpectrum[0].Length];
            maxLambda = this.obsSpectrum[0][this.obsSpectrum[0].Length - 1];
            minLambda = this.obsSpectrum[0][0];
            
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = (this.obsSpectrum[0][i] - minLambda) / (maxLambda - minLambda) + 1;
            }

            b = new double[this.polynomOrder + 1];
            r = new double[this.polynomOrder + 1][];
            for (int i = 0; i < polynomOrder + 1; i++)
            {
                r[i] = new double[this.polynomOrder + 1];
            }

            wm = new double[this.obsSpectrum[0].Length];
            for (int i = 0; i < wm.Length; i++) wm[i] = 1.0;

            syn = new double[this.obsSpectrum[0].Length];
            for (int i = 0; i < syn.Length; i++)
            {
                syn[i] = spline.Interp(this.obsSpectrum[0][i]);
            }

            sigma = new double[this.obsSpectrum[0].Length];
            for (int i = 0; i < sigma.Length; i++)
            {
                sigma[i] = Math.Sqrt(this.obsSpectrum[1][i]);
            }

            G = new double[this.obsSpectrum[0].Length][];
            for (int i = 0; i < this.obsSpectrum[0].Length; i++)
            {
                G[i] = new double[this.polynomOrder + 1];
            }

            for (int i = 0; i < G.Length; i++)
            {
                for (int j = 0; j < G[0].Length; j++)
                {
                    G[i][j] = Math.Pow(x[i], j) * syn[i] / sigma[i];
                }
            }

            data = new double[this.obsSpectrum[1].Length];
            for (int i = 0; i < data.Length; i++) data[i] = obsSpectrum[1][i] / sigma[i];

            dw = new double[data.Length];
            

            for (int iter = 0; iter < iterNumber; iter++)
            {
                if (iter != 0)
                {
                    Basic.MA_mult_VB_minus_VC(ref G, ref polyPars, ref data, ref wm);
                    for (int i = 0; i < wm.Length; i++) wm[i] = 1.0 / Math.Abs(wm[i]);
                }

                for (int l = 0; l < this.polynomOrder + 1; l++)
                {
                    double sum = 0;
                    for (int i = 0; i < obsSpectrum[0].Length; i++)
                    {
                        sum = sum + G[i][l] * wm[i] * data[i];
                    }
                    b[l] = sum;
                }

                for (int l = 0; l < this.polynomOrder + 1; l++)
                {
                    for (int k = 0; k <= l; k++)
                    {
                        double sum = 0;
                        for (int i = 0; i < obsSpectrum[0].Length; i++)
                        {
                            sum = sum + wm[i] * G[i][l] * G[i][k];
                        }
                        r[l][k] = sum;
                        r[k][l] = sum;
                    }
                }

                this.polyPars = LES_Solver.SolveWithGaussMethod(r, b);
            }
        }

        public double[] GetNormSpectrum()
        {
            double[] normSpectrum = new double[this.obsSpectrum[0].Length];
            for (int i = 0; i < normSpectrum.Length; i++)
            {
                double sum = 0;
                for (int j = 0; j < this.polynomOrder + 1; j++)
                {
                    sum = sum + this.polyPars[j] * Math.Pow(this.obsSpectrum[0][i], j);
                }
                normSpectrum[i] = this.obsSpectrum[1][i] / sum;
            }
            return normSpectrum;
        }

        public double PolynomFit(double lambda)
        {
            double x = (lambda - obsSpectrum[0][0]) /
                (this.obsSpectrum[0][this.obsSpectrum[0].Length - 1] - this.obsSpectrum[0][0]) + 1;
            double sum = 0;
            for (int j = 0; j < this.polynomOrder + 1; j++)
            {
                sum = sum + this.polyPars[j] * Math.Pow(x, j);
            }
            return sum;
        }

        public double[] PolyPars
        {
            get
            {
                return this.polyPars;
            }
        }

        public void SetWeigth(double weight)
        {
            this.weight = weight;
        }

        public double LambdaMin
        {
            get { return this.obsSpectrum[0][0]; }
        }

        public double LambdaMax
        {
            get { return this.obsSpectrum[0][this.obsSpectrum[0].Length - 1]; }
        }
    }
}
