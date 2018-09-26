using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using VSUP.DataModel;
using VSUP.Services;
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

namespace VSUP.Charts.Other
{
    public partial class TeacherAgendMap : Form
    {
        public static Instance objInstance = new Instance();

        public TeacherAgendMap()
        {
            InitializeComponent();
            SetDataComboBox();

            cartesianChart1.Series.Add(new HeatSeries
            {
                Values = null//ChartValuesList()
                ,
                DataLabels = false,

                GradientStopCollection = new GradientStopCollection
                {
                    new GradientStop(System.Windows.Media.Color.FromRgb(0, 0, 255), 0),
                    new GradientStop(System.Windows.Media.Color.FromRgb(0, 0, 255), .25),
                    new GradientStop(System.Windows.Media.Color.FromRgb(0, 0, 255), .5),
                    new GradientStop(System.Windows.Media.Color.FromRgb(0, 0, 255), .75),
                    new GradientStop(System.Windows.Media.Color.FromRgb(0, 0, 255), 1)
                    
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

        

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void cmbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cartesianChart1.Series.Clear();
            }catch (Exception ex)
            {

            }

            for (int i = 0; i < TeacherAgendList.teacherAgends.Count; i++)
            {
                if (cmbTeacher.Text.ToString() == TeacherAgendList.teacherAgends[i].courseId)
                {
                    ChartValues<HeatPoint> heatPoints = new ChartValues<HeatPoint>();
                    for (int j = 0; j < TeacherAgendList.teacherAgends[i].agendIds.Count; j++)
                    {
                        HeatPoint HeatPoint0 = new HeatPoint(TeacherAgendList.teacherAgends[i].agendIds[j].period, TeacherAgendList.teacherAgends[i].agendIds[j].day, 100);

                        heatPoints.Add(HeatPoint0);
                    }

                    cartesianChart1.Series.Add(new HeatSeries
                    {
                        Values = heatPoints,
                        DataLabels = false,
                        Title= TeacherAgendList.teacherAgends[i].teacherId,

                        //The GradientStopCollection is optional
                        //If you do not set this property, LiveCharts will set a gradient
                        GradientStopCollection = new GradientStopCollection
                        {
                            new GradientStop(System.Windows.Media.Color.FromRgb(0, 0, 200), 0),
                            new GradientStop(System.Windows.Media.Color.FromRgb(0, 0, 200), .25),
                            new GradientStop(System.Windows.Media.Color.FromRgb(0, 0, 200), .5),
                            new GradientStop(System.Windows.Media.Color.FromRgb(0, 0, 200), .75),
                            new GradientStop(System.Windows.Media.Color.FromRgb(0, 0, 200), 1)
                        }

                    });
                }
            }
        }



        public void SetDataComboBox()// List<TeacherAgend> teacherAgends)
        {
            for (int i = 0; i < TeacherAgendList.teacherAgends.Count; i++)
            {
                cmbTeacher.Items.Add(TeacherAgendList.teacherAgends[i].courseId);
            }
        }

        private void TeacherAgendMap_Load(object sender, EventArgs e)
        {

        }
    }
}
