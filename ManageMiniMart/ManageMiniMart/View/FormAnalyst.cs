using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageMiniMart.View
{
    public partial class FormAnalyst : Form
    {
        public FormAnalyst()
        {
            InitializeComponent();
            chartRevenue.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Month",
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }
            });
            chartRevenue.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Revenue",
                LabelFormatter = value => value.ToString("C")
            });
            chartRevenue.LegendLocation = LiveCharts.LegendLocation.Right;
            loadRevenue();
            loadChartCustomer();
        }
        private void loadRevenue()
        {
            chartRevenue.Series.Clear();
            SeriesCollection series = new SeriesCollection();
            Random r = new Random();
            for (int i =2020; i< 2024; i++)
            {
                
                List<double> values = new List<double>();
                for(int month = 1; month <= 12; month++)
                {
                    
                    values.Add(r.NextDouble() * 200 + 30);
                }
                series.Add(new LineSeries()
                {
           
                    Title = i.ToString(),
                    Values = new ChartValues<double>(values)
                });
            }
            chartRevenue.Series = series;
            
        }
        private void loadChartCustomer()
        {
            Random r = new Random();
            for (int i = 1; i< 13; i++)
            {
                int value = r.Next(10, 200);
                chartCustomer.Series["AmountCustomer"].Points.Add(value);
                chartCustomer.Series["AmountCustomer"].Points[i-1].Color = Color.Plum;
                chartCustomer.Series["AmountCustomer"].Points[i-1].AxisLabel = i.ToString();
                chartCustomer.Series["AmountCustomer"].Points[i - 1].LegendText= value.ToString();
                chartCustomer.Series["AmountCustomer"].Points[i - 1].Label = value.ToString();
            }
        }

        private void chartRevenue_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}
