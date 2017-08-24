using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SN
{
    class SuperNormator:Normator
    {
        public SuperNormator(double[][] obsSpectrum, double[][] tempSpectrum, int order)
        {
            this.ObsSpectrum = obsSpectrum;
            this.TempSpectrum = tempSpectrum;
        }

        public void StartFitting(int order, int nIter, double lowReject, double highReject)
        {
            this.PolynomOrder = order;
            this.Normalize();
            for (int i = 0; i < nIter; i++)
            {                
                bool[] excludeMask = new bool[this.ObsSpectrum[0].Length];
                for (int j = 0; j < this.ObsSpectrum[0].Length; j++)
                {
                    excludeMask[j] = false;
                }
                // computing of the standart deviation;
                double sigma;
                double sum = 0;
                for (int j = 0; j < this.ObsSpectrum.Length; j++)
                {
                    sum += Math.Pow(this.TempSpectrum[1][j] -
                        this.ObsSpectrum[1][j] / this.PolynomFit(this.ObsSpectrum[0][j]), 2);
                }
                sigma = Math.Sqrt(sum / this.ObsSpectrum[0].Length);

                // building of the rejection mask;
                for (int j = 0; j < excludeMask.Length; j++)
                {
                    double dev = this.ObsSpectrum[1][j] / this.PolynomFit(this.ObsSpectrum[0][j])
                        - this.TempSpectrum[1][j];
                    if (dev < -lowReject) excludeMask[j] = true;
                    if (dev > highReject) excludeMask[j] = true;
                }

                // building of the new spectrum;
                int size = 0;
                for (int j = 0; j < excludeMask.Length; j++)
                {
                    if (!excludeMask[j]) size++;
                }

               

                double[][] newSpectrum = new double[2][];
                newSpectrum[0] = new double[size];
                newSpectrum[1] = new double[size];

                {
                    int k = 0;
                    for (int j = 0; j < excludeMask.Length; j++)
                    {
                        if (!excludeMask[j])
                        {
                            newSpectrum[0][k] = this.ObsSpectrum[0][j];
                            newSpectrum[1][k] = this.ObsSpectrum[1][j];
                            k++;
                        }
                    }
                }
                this.ObsSpectrum = newSpectrum;
                this.Normalize();
            }
        }
    }
}
