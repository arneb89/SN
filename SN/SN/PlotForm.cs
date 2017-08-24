using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NPlot;

namespace SpectrViewer
{
    public partial class PlotForm : Form
    {
        GraphsList grList;

        public PlotForm()
        {
            InitializeComponent();
            this.grList = new GraphsList();
            this.lbCurves.SelectedIndexChanged+=new EventHandler(lbCurves_SelectedIndexChanged);
            plot.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.HorizontalDrag());
            plot.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.VerticalDrag());
            plot.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.AxisDrag(true));
        }



        private void PlotForm_Load(object sender, EventArgs e)
        {

        }

        private void RefreshCurveList()
        {
            lbCurves.Items.Clear();
            for (int i = 0; i < grList.Count; i++)
            {
                lbCurves.Items.Add(string.Format("{0}", grList.Label(i)));
            }
        }

        private void ShowGraphs()
        {
            this.RefreshCurveList();
            for (int i = 0; i < grList.Count; i++)
            {
                double[] x = grList.ValsX(i);
                double[] y = grList.ValsY(i);
                LinePlot lp = new LinePlot(y, x);
                plot.Add(lp);
                plot.Refresh();
            }
        }

        public void AddCurve(double[] x, double[] y, string label)
        {
            this.grList.Add(x, y, label, Color.Black);
            this.ShowGraphs();
        }

        private void btnDeleteCurve_Click(object sender, EventArgs e)
        {
            int number = lbCurves.SelectedIndex;
            if (number == -1) return;
            this.grList.Delete(number);
            this.RefreshCurveList();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            int number = lbCurves.SelectedIndex;
            if (number == -1) return;
            colorDialog1.ShowDialog();
            Color color = colorDialog1.Color;
            this.grList.SetColor(number, color);
            pnlColor.BackColor = color;
        }

        private void lbCurves_SelectedIndexChanged(object sender, EventArgs e)
        {
            int number = lbCurves.SelectedIndex;
            if (lbCurves.SelectedIndex == -1) return;
            pnlColor.BackColor = this.grList.GetColors(number);
        }

        private void btnRefreshPlot_Click(object sender, EventArgs e)
        {
            plot.Clear();
            for (int i = 0; i < this.grList.Count; i++)
            {
                LinePlot lp = new LinePlot();
                lp.AbscissaData = this.grList.ValsX(i);
                lp.OrdinateData = this.grList.ValsY(i);
                lp.Color = this.grList.GetColors(i);
                plot.Add(lp);
            }
            plot.Refresh();
        }
    }
}
