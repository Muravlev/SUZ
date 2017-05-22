using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            int A = (int)numericUpDown1.Value;
            int B = (int)numericUpDown2.Value;
            double alpha = double.Parse(textBox1.Text);// (int)numericUpDown3.Value;
            double betha = double.Parse(textBox2.Text);//(int)numericUpDown4.Value;
            double[] teory = new double[B - A + 1];
            //Теория
            string tableTe = "X;Y   ";
            for (int x = A; x <= B; x++)
            {
                for (int y = A; y <= B; y++)
                {
                    if (x > y)
                    {
                        teory[x] += ((x - y) * betha) / (double)(B - A + 1);
                    }
                    else
                    {
                        teory[x] += ((y - x) * alpha) / (double)(B - A + 1);
                    }
                }
                chart1.Series[0].Points.AddXY(x, teory[x]);
                tableTe += String.Format("{0};{1}   ", x, Math.Round(teory[x],2));
            }
            
            //Q min
            double minQ = teory[0];
            int minX = 0;
            for (int i = 1; i <= B - A; i++)
            {
                if (teory[i] < minQ)
                {
                    minQ = teory[i];
                    minX = i - A;
                }
            }
            //=====================================
            label6.Text = String.Format("Q min = {0:0.00}", minQ);
            label7.Text = String.Format("при x = {0}", minX);            
        }
    }
}
