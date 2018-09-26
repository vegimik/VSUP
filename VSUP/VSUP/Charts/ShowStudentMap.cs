using LiveCharts;
using LiveCharts.Defaults;
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
using System.Windows.Media;
using VSUP.Services;

namespace VSUP.Charts
{
    public partial class ShowStudentMap : Form
    {
        public ShowStudentMap()
        {
            InitializeComponent();

            var r = new Random();

            cartesianChart1.Series.Add(new HeatSeries
            {
                Values = ChartValuesList(StudentMapList.numberStudentMap)
                ,
                DataLabels = true
                ,
                GradientStopCollection = new GradientStopCollection
                {
                    new GradientStop(System.Windows.Media.Color.FromRgb(0, 0, 255), 0),
                    new GradientStop(System.Windows.Media.Color.FromRgb(0, 128, 128), .25) ,
                    new GradientStop(System.Windows.Media.Color.FromRgb(0, 255, 0), .5),
                    new GradientStop(System.Windows.Media.Color.FromRgb(128, 128, 0), .75),
                    new GradientStop(System.Windows.Media.Color.FromRgb(255, 0, 0), 1)
                }
            });

            cartesianChart1.AxisX.Add(new Axis
            {
                LabelsRotation = -15,
                Labels = new[]
                {
                    "08:00 - 10:00",
                    "10:00 - 12:00",
                    "12:00 - 14:00",
                    "14:00 - 16:00",
                    "16:00 - 18:00",
                    "18:00 - 20:00"
                },
                Separator = new Separator { Step = 1 }
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Labels = new[]
                {
                    "Monday",
                    "Tuesday",
                    "Wednesday",
                    "Thursday",
                    "Friday",
                    "Saturday",
                    "Sunday"
                }
            });

        }

        public ChartValues<HeatPoint> ChartValuesList(int[,] numberStudentMap)
        {
            ChartValues<HeatPoint> heatPoints = new ChartValues<HeatPoint>();
            for (int i = 0; i < 6; i++)
            {
                HeatPoint HeatPoint0 = new HeatPoint(i, 0, numberStudentMap[i, 0]);
                HeatPoint HeatPoint1 = new HeatPoint(i, 1, numberStudentMap[i, 1]);
                HeatPoint HeatPoint2 = new HeatPoint(i, 2, numberStudentMap[i, 2]);
                HeatPoint HeatPoint3 = new HeatPoint(i, 3, numberStudentMap[i, 3]);
                HeatPoint HeatPoint4 = new HeatPoint(i, 4, numberStudentMap[i, 4]);

                heatPoints.Add(HeatPoint0);
                heatPoints.Add(HeatPoint1);
                heatPoints.Add(HeatPoint2);
                heatPoints.Add(HeatPoint3);
                heatPoints.Add(HeatPoint4);
            }
            return heatPoints;
        }


        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}
