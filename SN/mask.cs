using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SN
{
    class Mask
    {
        private bool includeMask;
        private int size;
        private double[][] ranges;

        public Mask()
        {
            this.size = 0;
            this.ranges = new double[2][];
            this.ranges[0] = new double[0];
            this.ranges[1] = new double[0];
        }

        public Mask(string path)
        {
            StreamReader sr = new StreamReader(path);

            string str;
            string[] strMas;
            str = sr.ReadLine();
            int numStr = int.Parse(str);
            this.size = numStr;
            this.ranges = new double[2][];
            this.ranges[0] = new double[numStr];
            this.ranges[1] = new double[numStr];

            for (int i = 0; i < numStr; i++)
            {
                str = sr.ReadLine();
                strMas = str.Split(new string[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
                this.ranges[0][i] = double.Parse(strMas[0]);
                this.ranges[1][i] = double.Parse(strMas[1]);
            }

            sr.Close();
        }

        public bool IncludeMask
        {
            get
            {
                return this.includeMask;
            }
            set
            {
                this.includeMask = value;
            }
        }

        public void AddRange(double lambda1, double lambda2)
        {
            if (this.size == 0)
            {
                this.size++;
                this.ranges[0] = new double[this.size];
                this.ranges[1] = new double[this.size];
                this.ranges[0][0] = lambda1;
                this.ranges[1][0] = lambda2;
                return;
            }

            this.size++;
            double[][] rangesCopy = new double[2][];
            rangesCopy[0] = new double[this.ranges[0].Length];
            rangesCopy[1] = new double[this.ranges[1].Length];
            Array.Copy(this.ranges[0], rangesCopy[0], this.ranges[0].Length);
            Array.Copy(this.ranges[1], rangesCopy[1], this.ranges[1].Length);

            this.ranges[0] = new double[this.size];
            this.ranges[1] = new double[this.size];

            for (int i = 0; i < this.size-1; i++)
                ranges[0][i] = rangesCopy[0][i];

            for (int i = 0; i < this.size-1; i++)
                ranges[1][i] = rangesCopy[1][i];

            ranges[0][this.size - 1] = lambda1;
            ranges[1][this.size - 1] = lambda2;
        }

        public void DeleteRange(int number)
        {
            this.size--;
            double[][] rangesCopy = new double[2][];
            rangesCopy[0] = new double[this.ranges[0].Length];
            rangesCopy[1] = new double[this.ranges[1].Length];
            Array.Copy(this.ranges[0], rangesCopy[0], this.ranges[0].Length);
            Array.Copy(this.ranges[1], rangesCopy[1], this.ranges[1].Length);

            this.ranges[0] = new double[this.size];
            this.ranges[1] = new double[this.size];

            int j = 0;
            for (int i = 0; i < this.size; i++)
            {
                if (j == number) j++;
                ranges[0][i] = rangesCopy[0][j];
                ranges[1][i] = rangesCopy[1][j];
                j++;
            }
        }

        public double GetLeftBound(int index)
        {
            return ranges[0][index];
        }

        public double GetRightBound(int index)
        {
            return ranges[1][index];
        }

        public bool InMask(double lambda)
        {
            bool ans = false;
            for (int i = 0; i < this.size; i++)
            {
                if ((lambda >= ranges[0][i]) && (lambda <= ranges[1][i]))
                {
                    ans = true;
                    break;
                }
            }
            return ans;
        }

        public int Size()
        {
            return this.size;
        }

        public void Sort()
        {
            double temp = 0; // временная переменная для хранения элемента массива
            bool exit = false; // болевая переменная для выхода из цикла, если массив отсортирован

            double[] avers = new double[this.size];

            for (int i = 0; i < avers.Length; i++)
            {
                avers[i] = (ranges[1][i] + ranges[0][i]) * 0.5;
            }

            while (!exit)
            {
                exit = true;
                for (int i = 0; i < avers.Length - 1; i++)
                {
                    //сортировка пузырьком по возрастанию - знак >
                    //сортировка пузырьком по убыванию - знак <
                    if (avers[i] > avers[i + 1]) // сравниваем два соседних элемента
                    {
                        // выполняем перестановку элементов массива

                        temp = avers[i];
                        avers[i] = avers[i + 1];
                        avers[i + 1] = temp;

                        temp = ranges[0][i];
                        ranges[0][i] = ranges[0][i + 1];
                        ranges[0][i + 1] = temp;

                        temp = ranges[1][i];
                        ranges[1][i] = ranges[1][i + 1];
                        ranges[1][i + 1] = temp;
                        
                        exit = false;
                    }
                }
            }
        }

        public void Clear()
        {
            this.size = 0;
            this.ranges[0] = null;
            this.ranges[1] = null;
        }

        public void Write(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(this.size.ToString());
            for (int i = 0; i < this.size; i++)
            {
                sw.WriteLine("{0:0000.00000}\t{1:0000.00000}", this.ranges[0][i], this.ranges[1][i]);
            }
            sw.Close();
        }
    }
}
