using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using VSUP.Charts;
using VSUP.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSUP
{
    public partial class RoomUtilization : Form
    {
        public RoomUtilization()
        {
            InitializeComponent();
            LabelRoomsList(listData);

        }

        RoomUtilizationClass objRoomUtilizationClass = new RoomUtilizationClass();
        public static List<DataSolution> listData = new List<DataSolution>();
        public List<string> listDataRepeted = new List<string>();
        public int abscissaX { get; set; }
        public int[] ordinateY { get; set; }

        private void Labels_Load(object sender, EventArgs e)
        {
            cartesianChart1.Series.Add(new ColumnSeries
            {
                Values = ChartValuesList()                
                ,
                DataLabels = true,
                LabelPoint = point => point.Y + " hours \n per week ("+ (point.Y*100/30.0).ToString("F1", CultureInfo.InvariantCulture) + ")%"
            });

            cartesianChart1.AxisX.Add(new Axis
            {
                Labels = LabelRoomsList(listData)               
                ,
                Separator = new Separator // force the separator step to 1, so it always display all labels
                {
                    Step = 1,
                    IsEnabled = false //disable it to make it invisible.
                },
                LabelsRotation = 15
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                LabelFormatter = value => value + " hours per week",
                Separator = new Separator()
            });

        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        public ChartValues<ObservableValue> ChartValuesList() // Values for room utilization
        {
            ChartValues<ObservableValue> cvOV=new ChartValues<ObservableValue>();
            int[] listValue = ValuesForRoom(listData);
            for(int i=0; i< listValue.Length; i++)
            {
                cvOV.Add(new ObservableValue(listValue[i]));
            }return cvOV;
        }

        public string[] LabelRoomsList(List<DataSolution> listData)
        {
            string[] labelRoomsList = new string[listData.Count];
            List<string> listDataLabelRoomsRepeted = new List<string>();
            List<string> listDataLabelRoomsRepetedPlusTotal = new List<string>();

            for(int i=0; i<listData.Count; i++)
            {
                listDataLabelRoomsRepeted.Add(listData[i].RoomRef);
            }

            listDataRepeted = listDataLabelRoomsRepeted;
            //labelRoomsList = listDataLabelRoomsRepeted.Distinct().ToArray();
            listDataLabelRoomsRepetedPlusTotal = listDataLabelRoomsRepeted.Distinct().ToList();
            listDataLabelRoomsRepetedPlusTotal.Add("Total");
            labelRoomsList = listDataLabelRoomsRepetedPlusTotal.ToArray();
            //PieChartExample.listLabel = labelRoomsList;
            return labelRoomsList;
        }

        public int[] ValuesForRoom(List<DataSolution> listData)
        {
            int k = listDataRepeted.Distinct().Count();
            List<string> _valuesForRoomList = listDataRepeted.Distinct().ToList();
            int[] _valuesForRoom = new int[k+1];

            for(int i=0; i<k; i++)
            {
                RoomClass objRoomClass = new RoomClass();
                objRoomClass.RoomRef = _valuesForRoomList[i];                
                for (int j = 0; j < listData.Count; j++)
                {
                    if(_valuesForRoomList[i]==listData[j].RoomRef)
                    {
                        objRoomClass.RoomValueUtil += 1;
                    }

                }
                objRoomUtilizationClass.RoomUtilizationList.Add(objRoomClass);

            }

            //Plus Totlal value
            double total = 0;
            for (int i = 0; i < k; i++)
            {
                total+= objRoomUtilizationClass.RoomUtilizationList[i].RoomValueUtil;
            }
            total = total / k;

            RoomClass roomClassTotal = new RoomClass();
            roomClassTotal.RoomRef = "Total";
            roomClassTotal.RoomValueUtil = Int32.Parse(total.ToString("F0", CultureInfo.InvariantCulture));
            objRoomUtilizationClass.RoomUtilizationList.Add(roomClassTotal);
            

            //Set value in "ordinateY"
            for (int i=0; i<k+1; i++)
            {
                _valuesForRoom[i] = objRoomUtilizationClass.RoomUtilizationList[i].RoomValueUtil;
            }
            ordinateY = _valuesForRoom;
            //PieChartExample.listValue = _valuesForRoom;
            return _valuesForRoom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Gauge360Example gauge360Example = new Gauge360Example();
            //gauge360Example.Show();
        }
    }
}
