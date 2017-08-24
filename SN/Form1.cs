using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using NPlot;

namespace SN
{
    public partial class Form1 : Form
    {
        NumberFormatInfo numFormInf;

        Spectrum tempSpectrum;

        Spectrum temCutSpectrum;

        Spectrum obsSpectrum;

        Spectrum normSpectrum;
        Spectrum contSpectrum;
        Spectrum rejectSpectrum;

        Mask cutMask = new Mask();
        
        double cropLambdaMin, cropLambdaMax;

        public Form1()
        {
            InitializeComponent();            
            plotTemplateSpectrum.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.HorizontalDrag());
            plotTemplateSpectrum.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.VerticalDrag());
            plotTemplateSpectrum.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.AxisDrag(true));
            plotTemplateSpectrum.MouseDoubleClick+=new MouseEventHandler(plotTemplateSpectrum_MouseDoubleClick);

            lbRanges.SelectedIndexChanged += new EventHandler(lbRanges_SelectedIndexChanged);

            this.numFormInf = new NumberFormatInfo();
            numFormInf.CurrencyDecimalSeparator = ".";
        }

        void lbRanges_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DrawNormSpecGraph();
            this.DrawObsSpecGraph();
        }

        private void btnLoadTemplateSpectrum_Click(object sender, EventArgs e)
        {
            string path;
            StreamReader sr;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                sr = new StreamReader(path);
            }
            else
            {
                return;
            }

            System.Globalization.CultureInfo usCulture = new System.Globalization.CultureInfo("en-US");
            System.Globalization.NumberFormatInfo dbNumberFormat = usCulture.NumberFormat;
            dbNumberFormat.NumberDecimalSeparator = ".";

            int size=0;
            
            string str;

            str = sr.ReadLine();
            while (str != null && str != "")
            {
                size++;
                str = sr.ReadLine();
            }
            sr.Close();

            sr = new StreamReader(path);
            
            string[] strMas;

            string[] stringSeparators = new string[] { " ", "\t" };

            this.tempSpectrum = new Spectrum(size);

            for (int i = 0; i < size; i++)
            {
                str = sr.ReadLine();
                strMas = str.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                this.tempSpectrum.LambdaSet[i] = double.Parse(strMas[0].Replace(",", "."), dbNumberFormat);
                this.tempSpectrum.FluxSet[i] = double.Parse(strMas[1].Replace(",", "."), dbNumberFormat);
            }

            sr.Close();
        }

        private void btnLoadObservedSpectrum_Click(object sender, EventArgs e)
        {
            string path;
            StreamReader sr;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                sr = new StreamReader(path);
            }
            else
            {
                return;
            }

            string str;

            int size = 0;
            StreamReader sr_analyse = new StreamReader(path);
            str = sr_analyse.ReadLine();
            while (str != null)
            {
                size++;
                str = sr_analyse.ReadLine();
            }
            sr_analyse.Close();

            string[] strMas;

            string[] stringSeparators = new string[] { " ", "\t" };

            double[] lambda, flux;

            lambda = new double[size];
            flux = new double[size];

            for (int i = 0; i < size; i++)
            {
                str = sr.ReadLine();
                strMas = str.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                lambda[i] = double.Parse(strMas[0].Replace(".", ","));
                flux[i] = double.Parse(strMas[1].Replace(".", ","));
            }

            this.obsSpectrum = new Spectrum(lambda, flux);

            this.cropLambdaMin = lambda.Min();
            this.cropLambdaMax = lambda.Max();

            sr.Close();

            this.contSpectrum = null;

            this.DrawObsSpecGraph();
        }

        private void btnLoadNormSpectrum_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string path = openFileDialog1.FileName;

            StreamReader sr = new StreamReader(path);

            string str;

            int size = 0;
            StreamReader sr_analyse = new StreamReader(path);
            str = sr_analyse.ReadLine();
            while (str != null)
            {
                size++;
                str = sr_analyse.ReadLine();
            }
            sr_analyse.Close();

            string[] strMas;

            string[] stringSeparators = new string[] { " ", "\t" };

            double[] lambda, flux;

            lambda = new double[size];
            flux = new double[size];

            for (int i = 0; i < size; i++)
            {
                str = sr.ReadLine();
                strMas = str.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                lambda[i] = double.Parse(strMas[0].Replace(".", ","));
                flux[i] = double.Parse(strMas[1].Replace(".", ","));
            }

            this.cropLambdaMin = lambda.Min();
            this.cropLambdaMax = lambda.Max();
            this.normSpectrum = new Spectrum(lambda, flux);

            sr.Close();

            this.DrawNormSpecGraph();
        }

        private void DrawObsSpecGraph()
        {
            plotObsSpectrum.Clear();

            // add masks;
            int num = lbRanges.SelectedIndex;
            for (int i = 0; i < cutMask.Size(); i++)
            {
                NPlot.VerticalLine vl1 = new VerticalLine(this.cutMask.GetLeftBound(i));
                NPlot.VerticalLine vl2 = new VerticalLine(this.cutMask.GetRightBound(i));
                NPlot.FilledRegion fr = new FilledRegion(vl1, vl2);
                fr.Brush = Brushes.Coral;
                if (num == i) fr.Brush = Brushes.Gray;
                plotObsSpectrum.Add(fr);
            }

            // add observed spectrum;
            if (this.obsSpectrum != null)
            {
                LinePlot lp = new LinePlot();
                lp.AbscissaData = this.obsSpectrum.LambdaSet;
                lp.OrdinateData = this.obsSpectrum.FluxSet;
                lp.Pen = new Pen(Color.Black, 1.0f);
                plotObsSpectrum.Add(lp);
            }

            // add continum;
            if (this.contSpectrum != null)
            {
                LinePlot lpCont = new LinePlot(this.contSpectrum.FluxSet, this.contSpectrum.LambdaSet);
                lpCont.Pen = new Pen(Color.Red, 2.0f);
                plotObsSpectrum.Add(lpCont);
            }

            // add rejected points;
            if (this.rejectSpectrum!=null && this.rejectSpectrum.Size > 0)
            {
                PointPlot ppRej = new PointPlot();
                ppRej.AbscissaData = this.rejectSpectrum.LambdaSet;
                ppRej.OrdinateData = this.rejectSpectrum.FluxSet;
                ppRej.Marker = new Marker(Marker.MarkerType.Diamond, 4, Color.Red);
                plotObsSpectrum.Add(ppRej);
            }

            plotObsSpectrum.Title = "Observed spectrum";
            plotObsSpectrum.YAxis1.Label = "Flux";
            plotObsSpectrum.XAxis1.Label = "Lambda";

            plotObsSpectrum.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.HorizontalDrag());
            plotObsSpectrum.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.VerticalDrag());
            plotObsSpectrum.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.AxisDrag(true));

            plotObsSpectrum.Refresh();
        }

        private void DrawNormSpecGraph()
        {
            LinePlot lpTemp = new LinePlot();

            plotTemplateSpectrum.Clear();

            // add masks;
            int num = lbRanges.SelectedIndex;
            for (int i = 0; i < cutMask.Size(); i++)
            {
                NPlot.VerticalLine vl1 = new VerticalLine(this.cutMask.GetLeftBound(i));
                NPlot.VerticalLine vl2 = new VerticalLine(this.cutMask.GetRightBound(i));
                NPlot.FilledRegion fr = new FilledRegion(vl1, vl2);
                fr.Brush = Brushes.Coral;
                if (num == i) fr.Brush = Brushes.Aqua;
                plotTemplateSpectrum.Add(fr);
            }

            // add normalized observed spectrum;
            if (this.normSpectrum != null)
            {
                LinePlot lpObsNorm = new LinePlot();
                lpObsNorm.Color = Color.Red;
                lpObsNorm.AbscissaData = this.normSpectrum.LambdaSet;
                lpObsNorm.OrdinateData = this.normSpectrum.FluxSet;
                plotTemplateSpectrum.Add(lpObsNorm);
            }

            // add normalized template spectrum;
            if (this.temCutSpectrum != null)
            {
                lpTemp.Color = Color.Blue;
                lpTemp.AbscissaData = this.temCutSpectrum.LambdaSet;
                lpTemp.OrdinateData = this.temCutSpectrum.FluxSet;
                plotTemplateSpectrum.Add(lpTemp);
            }

            // add horizontal line;
            NPlot.HorizontalLine hl = new HorizontalLine(1.0, Color.DarkGray);
            plotTemplateSpectrum.Add(hl);
            
            
            plotTemplateSpectrum.XAxis1.WorldMax = this.cropLambdaMax;
            plotTemplateSpectrum.XAxis1.WorldMin = this.cropLambdaMin;
            plotTemplateSpectrum.Title = "Normalized spectrum";
            plotTemplateSpectrum.YAxis1.Label = "Norm. Flux";
            plotTemplateSpectrum.XAxis1.Label = "Wavelength";

            plotTemplateSpectrum.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.HorizontalDrag());
            plotTemplateSpectrum.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.VerticalDrag());
            plotTemplateSpectrum.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.AxisDrag(true));

            plotTemplateSpectrum.Refresh();
            
        }

        //private void DrawContinuum()
        //{
        //    if (this.contSpectrum == null) return;

        //    plotObsSpectrum.Clear();

        //    for (int i = 0; i < cutMask.Size(); i++)
        //    {
        //        NPlot.VerticalLine vl1 = new VerticalLine(this.cutMask.GetLeftBound(i));
        //        NPlot.VerticalLine vl2 = new VerticalLine(this.cutMask.GetRightBound(i));
        //        NPlot.FilledRegion fr = new FilledRegion(vl1, vl2);
        //        fr.Brush = Brushes.Coral;
        //        plotObsSpectrum.Add(fr);
        //    }

        //    LinePlot lpObs = new LinePlot(this.obsSpectrum.FluxSet, this.obsSpectrum.LambdaSet);
        //    lpObs.Pen = new Pen(Color.Black, 1.0f);
        //    plotObsSpectrum.Add(lpObs);

        //    LinePlot lpCont = new LinePlot(this.contSpectrum.FluxSet, this.contSpectrum.LambdaSet);
        //    lpCont.Pen = new Pen(Color.Red, 2.0f);
        //    plotObsSpectrum.Add(lpCont);

        //    if (this.rejectSpectrum.Size > 0)
        //    {
        //        PointPlot ppRej = new PointPlot();
        //        ppRej.AbscissaData = this.rejectSpectrum.LambdaSet;
        //        ppRej.OrdinateData = this.rejectSpectrum.FluxSet;
        //        ppRej.Marker = new Marker(Marker.MarkerType.Diamond, 4, Color.Red);
        //        plotObsSpectrum.Add(ppRej);
        //    }

        //    plotObsSpectrum.Title = "Observed spectrum";
        //    plotObsSpectrum.YAxis1.Label = "Flux";
        //    plotObsSpectrum.XAxis1.Label = "Wavelength";

        //    plotObsSpectrum.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.HorizontalDrag());
        //    plotObsSpectrum.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.VerticalDrag());
        //    plotObsSpectrum.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.AxisDrag(true));

        //    plotObsSpectrum.Refresh();
        //}

        private void btnNormalize_Click(object sender, EventArgs e)
        {
            if (this.tempSpectrum == null)
            {
                MessageBox.Show("Reference spectrum is't loaded...", "Error...");
                return;
            }

            int order;
            int nIter;
            double lowReject, highReject;
            string func_type;

            try
            {
                order = int.Parse(txtPolynomsOrder.Text);
                nIter = int.Parse(txtNIter.Text);
                highReject = double.Parse(txtHighReject.Text.Replace(",", "."), this.numFormInf);
                lowReject = double.Parse(txtLowReject.Text.Replace(",", "."),this.numFormInf);
                func_type = cbFunction.Text.ToLower();
            }
            catch
            {
                MessageBox.Show("Error in input data format...", "Error...");
                return;
            }

            if (cutMask.Size() == 0 && cutMask.IncludeMask)
            {
                return;
            }

            //Normator normator = new Normator();
            //SuperNormator superNormator;

            // trimming of the template spectra;
            double lambdaMin = this.obsSpectrum.LambdaSet.Min();
            double lambdaMax = this.obsSpectrum.LambdaSet.Max();

            int index1_cut = 0, index2_cut = 0;
            for (int i = 0; i < this.tempSpectrum.Size; i++)
            {
                if (this.tempSpectrum.LambdaSet[i] >= lambdaMin)
                {
                    index1_cut = i;
                    for (int j = i; j < this.tempSpectrum.Size; j++)
                    {
                        if (this.tempSpectrum.LambdaSet[j] >= lambdaMax)
                        {
                            index2_cut = j;
                            break;
                        }
                    }
                    break;
                }
            }

            int size = index2_cut - index1_cut + 1;
            double[] tempCuteLambda = new double[size];
            double[] tempCuteFlux = new double[size];
            Array.Copy(this.tempSpectrum.LambdaSet, index1_cut, tempCuteLambda, 0, size);
            Array.Copy(this.tempSpectrum.FluxSet, index1_cut, tempCuteFlux, 0, size);
            this.temCutSpectrum = new Spectrum(tempCuteLambda, tempCuteFlux);
            // end of trimming of the template spectra;

            //
            double[] obsLambda, obsFlux;
            size = 0;
            for (int i = 0; i < this.obsSpectrum.LambdaSet.Length; i++)
            {
                if (!cutMask.InMask(this.obsSpectrum.LambdaSet[i]) && !cutMask.IncludeMask)
                {
                    size++;
                }
                if (cutMask.InMask(this.obsSpectrum.LambdaSet[i]) && cutMask.IncludeMask)
                {
                    size++;
                }
            }
            obsLambda = new double[size];
            obsFlux = new double[size];
            int k = 0;
            for (int i = 0; i < this.obsSpectrum.LambdaSet.Length; i++)
            {
                if (!cutMask.InMask(this.obsSpectrum.LambdaSet[i]) && !cutMask.IncludeMask)
                {
                    obsLambda[k] = this.obsSpectrum.LambdaSet[i];
                    obsFlux[k] = this.obsSpectrum.FluxSet[i];
                    k++;
                }
                if (cutMask.InMask(this.obsSpectrum.LambdaSet[i]) && cutMask.IncludeMask)
                {
                    obsLambda[k] = this.obsSpectrum.LambdaSet[i];
                    obsFlux[k] = this.obsSpectrum.FluxSet[i];
                    k++;
                }
            }
            //

            //if (nIter == 0)
            {
                FITS_READER.Normator1.Norm(obsLambda, obsFlux, tempSpectrum.LambdaSet, tempSpectrum.FluxSet, 
                    order, lowReject, highReject, nIter, func_type);


                //normator.ObsSpectrum = new double[2][] { obsLambda, obsFlux };
                //normator.TempSpectrum = new double[2][] { this.temCutSpectrum.LambdaSet, this.temCutSpectrum.FluxSet };
                //normator.PolynomOrder = order;
                //normator.SetWeigth(highReject);
                //normator.NormalizeLM(nIter);
                //polyPars = normator.PolyPars;
            }
            //else
            //{
            //    superNormator = new SuperNormator(
            //        new double[2][] { obsLambda, obsFlux },
            //        new double[2][] { this.temCutSpectrum.LambdaSet, this.temCutSpectrum.FluxSet },
            //        order);
            //    superNormator.StartFitting(order, nIter, lowReject, highReject);
            //    polyPars = superNormator.PolyPars;
            //}

            double[] contFluxes = new double[this.obsSpectrum.LambdaSet.Length];
            double[] normFluxes = new double[this.obsSpectrum.LambdaSet.Length];

            //for (int i = 0; i < contFluxes.Length; i++)
            //{
            //    //contFluxes[i] = normator.PolynomFit(this.obsSpectrum.LambdaSet[i]);
            //    //normFluxes[i] = this.obsSpectrum.FluxSet[i] / contFluxes[i];
                
            //}

            for (int i = 0; i < contFluxes.Length; i++)
            {
                normFluxes[i] = this.obsSpectrum.FluxSet[i] / 
                    FITS_READER.Normator1.Continum(this.obsSpectrum.LambdaSet[i]);
                contFluxes[i] = this.obsSpectrum.FluxSet[i] / normFluxes[i];
            }

            txtStdDev.Text = FITS_READER.Normator1.StdDev.ToString();
            this.normSpectrum = new Spectrum(this.obsSpectrum.LambdaSet, normFluxes);
            this.contSpectrum = new Spectrum(this.obsSpectrum.LambdaSet, contFluxes);

            this.rejectSpectrum = new Spectrum(FITS_READER.Normator1.LambdaRejected, FITS_READER.Normator1.fluxRej);

            this.DrawObsSpecGraph();
            this.DrawNormSpecGraph();

        }

        /********************************************************************************/

        bool firstBound = true;
        double leftBound, rightBound;

        private void plotTemplateSpectrum_MouseDoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs eA = (MouseEventArgs)e;

            // Calculate data value
            Point here = new Point(eA.X, eA.Y);
            double x = this.plotTemplateSpectrum.PhysicalXAxis1Cache.PhysicalToWorld(here, true);

            if (this.firstBound)
            {
                leftBound = x;
                this.firstBound = false;
            }
            else
            {
                rightBound = x;
                this.firstBound = true;
                if (leftBound > rightBound)
                {
                    double buff;
                    buff = rightBound;
                    rightBound = leftBound;
                    leftBound = buff;
                }
                this.cutMask.AddRange(this.leftBound, this.rightBound);
                this.RefreshMask();
            }
        }

        private void RefreshMask()
        {
            lbRanges.Items.Clear();
            for (int i = 0; i < cutMask.Size(); i++)
            {
                lbRanges.Items.Add(string.Format("RANGE: {0:0000.000} --- {1:0000.000}",
                    this.cutMask.GetLeftBound(i),
                    this.cutMask.GetRightBound(i)));
            }
            this.DrawObsSpecGraph();
            this.DrawNormSpecGraph();
        }

        private void btnAddRange_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDelRange_Click(object sender, EventArgs e)
        {
            int number;
            number = lbRanges.SelectedIndex;
            if (number == -1) return;
            cutMask.DeleteRange(number);
            this.RefreshMask();
        }

        private void btnCCMask_Click(object sender, EventArgs e)
        {
            this.cutMask.Clear();
            this.RefreshMask();
        }

        /********************************************************************************/

        private void btnCrop_Click(object sender, EventArgs e)
        {
            this.cropLambdaMin = double.Parse(txtCropLambdaMin.Text.Replace(".", ","));
            this.cropLambdaMax = double.Parse(txtCropLambdaMax.Text.Replace(".", ","));
            this.DrawNormSpecGraph();
        }

        private void btnShowWholeSpectrum_Click(object sender, EventArgs e)
        {
            this.cropLambdaMin = this.obsSpectrum.LambdaSet.Min();
            this.cropLambdaMax = this.obsSpectrum.LambdaSet.Max();
            this.DrawNormSpecGraph();
        }

        private void btnSaveNormSpectrum_Click(object sender, EventArgs e)
        {
            StreamWriter sw = null;
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sw = new StreamWriter(saveFileDialog1.FileName);
            }
            else
            {
                return;
            }

            if (this.normSpectrum == null) return;

            

            if (this.normSpectrum.LambdaSet[0] <
                this.normSpectrum.LambdaSet[this.normSpectrum.Size - 1])
            {
                for (int i = 0; i < this.normSpectrum.LambdaSet.Length; i++)
                {
                    sw.WriteLine(string.Format(this.numFormInf, "{0:0000.00000}\t{1:0.00000}",
                        this.normSpectrum.LambdaSet[i], this.normSpectrum.FluxSet[i]));
                }
            }
            else
            {
                int ilast = this.normSpectrum.Size - 1;
                for (int i = 0; i < this.normSpectrum.LambdaSet.Length; i++)
                {
                    sw.WriteLine(string.Format(this.numFormInf ,"{0:0000.00000}\t{1:0.00000}",
                        this.normSpectrum.LambdaSet[ilast - i], this.normSpectrum.FluxSet[ilast - i]));
                }
            }

            sw.Flush();
            sw.Close();
        }

        private void rb_IncludeMask_CheckedChanged(object sender, EventArgs e)
        {
            if (cutMask == null) return;
            cutMask.IncludeMask = true;
        }

        private void rb_ExcludeMask_CheckedChanged(object sender, EventArgs e)
        {
            if (cutMask == null) return;
            cutMask.IncludeMask = false;
        }

        private void btn_NormInterp_Click(object sender, EventArgs e)
        {
            if (this.tempSpectrum == null)
            {
                MessageBox.Show("Reference spectrum is't loaded...", "Error...");
                return;
            }

            try
            {

            }
            catch
            {
                MessageBox.Show("Error in input data format...", "Error...");
                return;
            }


            // trimming of the template spectra;
            double lambdaMin = this.obsSpectrum.LambdaSet.Min();
            double lambdaMax = this.obsSpectrum.LambdaSet.Max();

            int index1_cut = 0, index2_cut = 0;
            for (int i = 0; i < this.tempSpectrum.Size; i++)
            {
                if (this.tempSpectrum.LambdaSet[i] >= lambdaMin)
                {
                    index1_cut = i;
                    for (int j = i; j < this.tempSpectrum.Size; j++)
                    {
                        if (this.tempSpectrum.LambdaSet[j] >= lambdaMax)
                        {
                            index2_cut = j;
                            break;
                        }
                    }
                    break;
                }
            }

            int size = index2_cut - index1_cut + 1;
            double[] tempCuteLambda = new double[size];
            double[] tempCuteFlux = new double[size];
            Array.Copy(this.tempSpectrum.LambdaSet, index1_cut, tempCuteLambda, 0, size);
            Array.Copy(this.tempSpectrum.FluxSet, index1_cut, tempCuteFlux, 0, size);
            this.temCutSpectrum = new Spectrum(tempCuteLambda, tempCuteFlux);
            // end of trimming of the template spectra;

            this.cutMask.Sort();

            //
            double[] xx = new double[this.cutMask.Size()];
            double[] yy = new double[this.cutMask.Size()];

            for (int i = 0; i < xx.Length; i++)
            {
                double x1 = 0;
                double y1 = 0;

                double x0 = 0;
                double y0 = 0;

                int size1 = 0;
                for (int j = 0; j < obsSpectrum.LambdaSet.Length; j++)
                {
                    if (cutMask.GetLeftBound(i) <= obsSpectrum.LambdaSet[j] &&
                        cutMask.GetRightBound(i) >= obsSpectrum.LambdaSet[j])
                    {
                        x1 += obsSpectrum.LambdaSet[j];
                        y1 += obsSpectrum.FluxSet[j];
                        size1++;
                    }
                }
                xx[i] = x1 / size1;
                yy[i] = y1 / size1;

                int size0 = 0;
                for (int j = 0; j < temCutSpectrum.LambdaSet.Length; j++)
                {
                    if (cutMask.GetLeftBound(i) <= temCutSpectrum.LambdaSet[j] &&
                        cutMask.GetRightBound(i) >= temCutSpectrum.LambdaSet[j])
                    {
                        x0 += temCutSpectrum.LambdaSet[j];
                        y0 += temCutSpectrum.FluxSet[j];
                        size0++;
                    }
                }
                x0 = x0 / size0;
                y0 = y0 / size0;

                yy[i] = yy[i] / y0;
            }

            Spline31D spline = new Spline31D(xx, yy);

            double[] contFluxes = new double[obsSpectrum.LambdaSet.Length];
            double[] normFluxes = new double[obsSpectrum.LambdaSet.Length];

            for (int i = 0; i < obsSpectrum.LambdaSet.Length; i++)
            {
                contFluxes[i] = spline.Interp(obsSpectrum.LambdaSet[i]);
                normFluxes[i] = obsSpectrum.FluxSet[i] / contFluxes[i];
            }

            this.normSpectrum = new Spectrum(this.obsSpectrum.LambdaSet, normFluxes);
            this.contSpectrum = new Spectrum(this.obsSpectrum.LambdaSet, contFluxes);

            this.DrawObsSpecGraph();
            this.DrawNormSpecGraph();
        }

        private void btnMaskOpen_Click(object sender, EventArgs e)
        {
            string path;
            
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                path = openFileDialog1.FileName;
            }
            else
            {
                return;
            }
            
            this.cutMask = new Mask(path);
            this.RefreshMask();
        }

        private void btnMaskSave_Click(object sender, EventArgs e)
        {
            string path="";
            if (saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                path = saveFileDialog1.FileName;
            }
            this.cutMask.Write(path);
            this.RefreshMask();
        }

        private void btnCCFGo_Click(object sender, EventArgs e)
        {
            double rvlb;
            double rvub;
            double rvStep;
            try
            {
                rvlb = double.Parse(txtRVLB.Text.Replace(",", "."), this.numFormInf);
                rvub = double.Parse(txtRVUB.Text.Replace(",", "."), this.numFormInf);
                rvStep = double.Parse(txtRVStep.Text.Replace(",", "."), this.numFormInf);
            }
            catch
            {
                MessageBox.Show("Incorrect input data format...", "Error...");
                return;
            }


            
            int size = 0;
            for (int i = 0; i < this.normSpectrum.LambdaSet.Length; i++)
            {
                if (!cutMask.InMask(this.normSpectrum.LambdaSet[i]) && !cutMask.IncludeMask)
                {
                    size++;
                }
                if (cutMask.InMask(this.normSpectrum.LambdaSet[i]) && cutMask.IncludeMask)
                {
                    size++;
                }
            }
            Spectrum cutObsSpec = new Spectrum(size);

            int k = 0;
            for (int i = 0; i < this.normSpectrum.LambdaSet.Length; i++)
            {
                if (!cutMask.InMask(this.normSpectrum.LambdaSet[i]) && !cutMask.IncludeMask)
                {
                    cutObsSpec.LambdaSet[k] = this.normSpectrum.LambdaSet[i];
                    cutObsSpec.FluxSet[k] = this.normSpectrum.FluxSet[i];
                    k++;
                }
                if (cutMask.InMask(this.normSpectrum.LambdaSet[i]) && cutMask.IncludeMask)
                {
                    cutObsSpec.LambdaSet[k] = this.normSpectrum.LambdaSet[i];
                    cutObsSpec.FluxSet[k] = this.normSpectrum.FluxSet[i];
                    k++;
                }
            }

            double[] df = new double[cutObsSpec.Size];
            double[] tf = new double[tempSpectrum.Size];
            for (int i = 0; i < df.Length; i++)
                df[i] = -cutObsSpec.FluxSet[i] + 1;
            for (int i = 0; i < tf.Length; i++)
                tf[i] = -tempSpectrum.FluxSet[i] + 1;

            CrossCor cc = new CrossCor(cutObsSpec.LambdaSet, df /*cutObsSpec.FluxSet*/,
                this.tempSpectrum.LambdaSet, /*this.tempSpectrum.FluxSet*/ tf);

            double[][] ccf = cc.Run(rvlb, rvub, rvStep, ref this.txtCCProgress);

            SpectrViewer.PlotForm plotForm = new SpectrViewer.PlotForm();

            plotForm.AddCurve(ccf[0], ccf[1], "CCF");

            plotForm.ShowDialog();

            StreamWriter sw = new StreamWriter("ccf.dat");

            for (int i = 0; i < ccf[0].Length; i++)
            {
                sw.WriteLine("{0}\t{1}", ccf[0][i], ccf[1][i]);
            }
            sw.Close();
            /////////////////////////////////////
            double cc_max, cc_min, cc_half;
            double xx1=0, xx2=0, width;
            bool xx1_found = false, xx2_found = false;

            cc_max = ccf[1].Max();
            cc_min = ccf[1].Min();
            cc_half = cc_min + (cc_max - cc_min) * 0.5;
            
            for (int i = 0; i < ccf[0].Length-1; i++)
            {
                if (((cc_half > ccf[1][i]) && (cc_half <= ccf[1][i + 1])) ||
                    ((cc_half < ccf[1][i]) && (cc_half >= ccf[1][i + 1])))
                {
                    if (!xx1_found)
                    {
                        xx1 = (ccf[0][i] + ccf[0][i + 1]) * 0.5;
                        xx1_found = true;
                    }
                    else
                    {
                        xx2 = (ccf[0][i] + ccf[0][i + 1]) * 0.5;
                        xx2_found = true;
                    }
                }
            }
            width = xx2 - xx1;
            txtCCFRes.Text = "";
            if (xx1_found && xx2_found) txtCCFRes.Text += " W = " + width.ToString();
        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            double rv;
            try
            {
                rv = double.Parse(txtShift.Text);
            }
            catch
            {
                MessageBox.Show("Incorrect format of input data", "Error...");
                return;
            }
            tempSpectrum.RVShift(rv);
            txtCurShift.Text = tempSpectrum.RV.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
