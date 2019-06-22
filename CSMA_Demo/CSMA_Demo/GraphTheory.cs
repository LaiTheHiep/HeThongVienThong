using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSMA_Demo
{
    public partial class GraphTheory : Form
    {
        public GraphTheory()
        {
            InitializeComponent();
            LoadChart();
        }
        public void LoadChart()
        {
            //1 - persistent CSMA slotted
            chartCSMA.Series.Add("1per");
            chartCSMA.Series.Add("Experiment");

            chartCSMA.Series["1per"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartCSMA.Series["1per"].Color = Color.Red;

            chartCSMA.Series["Experiment"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            chartCSMA.Series["Experiment"].Color = Color.Blue;

            for (double G = 0.01; G < 9; G = G + 0.01)
            {
                chartCSMA.Series["1per"].Points.AddXY(G, CSMA_1per(0.01, 10, G));
            }

            chartCSMA.Series["Experiment"].Points.AddXY(ConstantFrame.G_Graph, ConstantFrame.S_Graph);
            //chartCSMA.Series.Add("0.1-per");
            //chartCSMA.Series["0.1-per"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //chartCSMA.Series["0.1-per"].Color = Color.Red;

            //for (double G = 0.01; G < 20; G = G + 0.01)
            //{
            //    chartCSMA.Series["0.1-per"].Points.AddXY(G, CSMA_p_persistent_slotted(1, 10, G, 0.5, 1000));
            //}
        }

        #region 1-persistent
        /// <summary>
        /// 1 persistent Sloted
        /// </summary>
        /// <param name="a">Kich thuoc khe thoi gian</param>
        /// <param name="M">So luong user</param>
        /// <param name="g"></param>
        /// <returns>Thong luong S</returns>
        private double CSMA_1per(double a, int M, double G)
        {
            double g = G * a / M;
            double numerator = M * Math.Pow(1 - g, (1 + 1 / a) * (M - 1)) * ((1 - Math.Pow(1 - g, 1 + 1 / a)) * (1 - Math.Pow(1 - g, M)) + g * Math.Pow(1 - g, M + 1 / a));
            double denominator = (1 + a) * (1 - Math.Pow(1 - g, M)) + a * Math.Pow(1 - g, (1 + 1 / a) * M);

            return numerator / denominator;
        }

        #endregion

        #region non-persistent
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a">a = τ/T voi τ: trễ truyền lan; T thời gian truyền hết gói tin ra khỏi tram phat</param>
        /// <param name="G">tai duoc cung cap</param>
        /// <returns></returns>
        private double CSMA_NonePer(double a, double G)
        {
            double Tu = a * G * Math.Exp(-a * G);
            double Mau = 1 - Math.Exp(-a * G) + a;

            return Tu / Mau;
        }
        #endregion

        #region throughput of CSMA_p_persistent_slotted 

        /// <summary>
        /// Compute throughput of CSMA_p_persistent_slotted 
        /// </summary>
        /// <param name="a"> Size of slot </param>
        /// <param name="M"> Number of user </param>
        /// <param name="G"> </param>
        /// <param name="p"></param>
        /// <returns></returns>
        private double CSMA_p_persistent_slotted(double a, double M, double G, Double p, int k)
        {
            double g = Math.Min(1, G * a / M);

            double numerator = 0, dinominator = 0;

            return numerator / dinominator;
        }

        // Compute the part of the formula compute throughput of CSMA_p_persistent_slotted
        private double Part_of_formula(double a, int k, double g, double p, int part)
        {
            double o1 = Math.Pow(1 - p, k);
            double o2 = Math.Pow(1 - g, 1 + 1 / a);
            double o3 = (part == 1) ? (p * Math.Pow(1 - p, k) - g * Math.Pow(1 - g, k) / (p - g)) : (p * Math.Pow(1 - p, k) - p * Math.Pow(1 - g, k)) / (p - g);
            return o1 - o2 * o3;

        }

        #endregion

    }
}
