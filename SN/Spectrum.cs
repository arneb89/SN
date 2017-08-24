using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SN
{
    public class Spectrum
    {
        double rvShift;
        double[] lambda;
        double[] flux;

        public Spectrum(double[] lambda, double[] flux)
        {
            this.lambda = lambda;
            this.flux = flux;
            this.rvShift = 0;
        }

        public Spectrum(int size)
        {
            this.lambda = new double[size];
            this.flux = new double[size];
            this.rvShift = 0;
        }

        public double[] LambdaSet
        {
            get { return lambda; }
            set { this.lambda = value; }
        }

        public double[] FluxSet
        {
            get { return flux; }
            set { this.flux = value; }
        }

        public int Size
        {
            get { return this.lambda.Length; }
        }

        public void RVShift(double shift)
        {
            if (shift == 0) return;

            this.rvShift += shift;

            for (int i = 0; i < this.lambda.Length; i++)
            {
                this.lambda[i] += shift * this.lambda[i] / 300000;
            }
        }

        public double RV
        {
            get { return this.rvShift; }
        }
    }
}
