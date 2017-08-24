using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpectrViewer
{
    class GraphsList
    {
        private int grapsCount;
        private double[][] vals_x;
        private double[][] vals_y;
        private string[] labels;
        private Color[] colors;

        public GraphsList()
        {
            this.grapsCount = 0;
        }

        public void Add(double[] x, double[] y, string label, Color color)
        {
            int length = x.Length;
            if (this.grapsCount == 0)
            {
                this.grapsCount = 1;

                this.vals_x = new double[1][];
                this.vals_y = new double[1][];
                this.labels = new string[1];
                this.colors = new Color[1];

                this.labels[0] = label;
                this.colors[0] = color;
                this.vals_x[0] = new double[length];
                this.vals_y[0] = new double[length];

                for (int i = 0; i < length; i++)
                {
                    vals_x[0][i] = x[i];
                    vals_y[0][i] = y[i];
                }
            }
            else
            {
                string[] labels_buff = new string[this.grapsCount];
                Color[] colors_buff = new Color[this.grapsCount];
                double[][] vals_x_buff = new double[this.grapsCount][];
                double[][] vals_y_buff = new double[this.grapsCount][];

                for (int i = 0; i < this.grapsCount; i++)
                {
                    labels_buff[i] = this.labels[i];
                    colors_buff[i] = this.colors[i];
                    vals_x_buff[i] = new double[this.vals_x[i].Length];
                    vals_y_buff[i] = new double[this.vals_y[i].Length];

                    for (int j = 0; j < vals_x_buff[i].Length; j++)
                    {
                        vals_x_buff[i][j] = this.vals_x[i][j];
                        vals_y_buff[i][j] = this.vals_y[i][j];
                    }
                }

                this.grapsCount++;

                this.labels = new string[this.grapsCount];
                this.colors = new Color[this.grapsCount];
                this.vals_x = new double[this.grapsCount][];
                this.vals_y = new double[this.grapsCount][];

                for (int i = 0; i < this.grapsCount-1; i++)
                {
                    this.labels[i] = labels_buff[i];
                    this.colors[i] = colors_buff[i];
                    this.vals_x[i] = new double[vals_x_buff[i].Length];
                    this.vals_y[i] = new double[vals_y_buff[i].Length];

                    for (int j = 0; j < vals_x_buff[i].Length; j++)
                    {
                        this.vals_x[i][j] = vals_x_buff[i][j];
                        this.vals_y[i][j] = vals_y_buff[i][j];
                    }
                }

                this.labels[this.grapsCount - 1] = label;
                this.colors[this.grapsCount - 1] = color;
                this.vals_x[this.grapsCount - 1] = new double[length];
                this.vals_y[this.grapsCount - 1] = new double[length];

                for (int i = 0; i < length; i++)
                {
                    this.vals_x[this.grapsCount - 1][i] = x[i];
                    this.vals_y[this.grapsCount - 1][i] = y[i];
                }
            }
        }

        public void Delete(int number)
        {
            string[] labels_buff = new string[this.grapsCount];
            Color[] colors_buff = new Color[this.grapsCount];
            double[][] vals_x_buff = new double[this.grapsCount][];
            double[][] vals_y_buff = new double[this.grapsCount][];

            for (int i = 0; i < this.grapsCount; i++)
            {
                labels_buff[i] = this.labels[i];
                colors_buff[i] = this.colors[i];
                vals_x_buff[i] = new double[this.vals_x[i].Length];
                vals_y_buff[i] = new double[this.vals_y[i].Length];

                for (int j = 0; j < vals_x_buff[i].Length; j++)
                {
                    vals_x_buff[i][j] = this.vals_x[i][j];
                    vals_y_buff[i][j] = this.vals_y[i][j];
                }
            }

            this.grapsCount--;

            this.labels = new string[this.grapsCount];
            this.colors = new Color[this.grapsCount];
            this.vals_x = new double[this.grapsCount][];
            this.vals_y = new double[this.grapsCount][];

            int k = 0;
            for (int i = 0; i < this.grapsCount; i++)
            {
                if (i == number) k++;
                this.labels[i] = labels_buff[k];
                this.colors[i] = colors_buff[k];
                this.vals_x[i] = new double[vals_x_buff[k].Length];
                this.vals_y[i] = new double[vals_y_buff[k].Length];

                for (int j = 0; j < vals_x_buff[k].Length; j++)
                {
                    this.vals_x[i][j] = vals_x_buff[k][j];
                    this.vals_y[i][j] = vals_y_buff[k][j];
                }
                k++;
            }
        }

        public Color GetColors(int index)
        {
            return this.colors[index];
        }

        public void SetColor(int index, Color color)
        {
            this.colors[index] = color;
        }

        public string Label(int index)
        {
            return this.labels[index];
        }

        public double[] ValsX(int index)
        {
            return this.vals_x[index];
        }

        public double[] ValsY(int index)
        {
            return this.vals_y[index];
        }

        public int Count
        {
            get
            {
                return this.grapsCount;
            }
        }
    }
}
