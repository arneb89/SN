using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SN
{
    class LMS
    {
        //public double[] norm(Spectrum spNorm, Spectrum spObs, int order, int iterNum)
        //{
        //    LinInterpolator li = new LinInterpolator(spNorm.LambdaSet, spNorm.FluxSet);

        //    double[][] matG = new double[spObs.LambdaSet.Length][];

        //    for (int i = 0; i < matG.Length; i++)
        //    {
        //        matG[i] = new double[order + 1];
        //    }

        //    for (int i = 0; i < matG.Length; i++)
        //    {
        //        for (int j = 0; j < matG[i].Length; j++)
        //        {
        //            matG[i][j] = Math.Pow(spObs.LambdaSet[i], j) * li.Interp(spObs.LambdaSet[i]);
        //        }
        //    }
        //}
    }
}
