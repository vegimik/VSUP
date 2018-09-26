using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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

namespace VSUP.Charts
{
    public partial class FreeRooms : Form
    {
        private List<RoomListWithCells> setPeriodDayPerAllRoomsList = new List<RoomListWithCells>();
        private List<RoomListWithCells> setPeriodDayPerAllRoomsListModifed = new List<RoomListWithCells>();

        public FreeRooms()
        {
            InitializeComponent();
            setPeriodDayPerAllRoomsList = (new FreeRoomList()).SetPeriodDayPerAllRoomsList();
            SetPeriodDayPerAllRoomsListModifed();

            int i = -1;
            string[] aa ={ "a", "aa" };

            cartesianChart1.Series.Add(new HeatSeries
            {
                Values = ChartValuesList()
                ,
                DataLabels = false,
                LabelPoint = point => NameOfRoom(Int32.Parse(point.Y.ToString()), Int32.Parse(point.X.ToString())),


                //The GradientStopCollection is optional
                //If you do not set this property, LiveCharts will set a gradient
                GradientStopCollection = new GradientStopCollection
                {
                    new GradientStop(System.Windows.Media.Color.FromRgb(0, 255, 0), 0),
                    new GradientStop(System.Windows.Media.Color.FromRgb(0, 255, 0), .25),
                    new GradientStop(System.Windows.Media.Color.FromRgb(0, 255, 0), .5),
                    new GradientStop(System.Windows.Media.Color.FromRgb(0, 255, 0), .75),
                    new GradientStop(System.Windows.Media.Color.FromRgb(0, 255, 0), 1),
                    

                }
                //GradientStopCollection = new GradientStopCollection
                //{
                //    new GradientStop(System.Windows.Media.Color.FromRgb(0, 0, 255), 0),
                //    new GradientStop(System.Windows.Media.Color.FromRgb(0, 128, 128), .25) ,
                //    new GradientStop(System.Windows.Media.Color.FromRgb(0, 255, 0), .5),
                //    new GradientStop(System.Windows.Media.Color.FromRgb(128, 128, 0), .75),
                //    new GradientStop(System.Windows.Media.Color.FromRgb(255, 0, 0), 1)                    


                //}
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

        public ChartValues<HeatPoint> ChartValuesList()
        {
            ChartValues<HeatPoint> heatPoints = new ChartValues<HeatPoint>();
            for (int i = 0; i < setPeriodDayPerAllRoomsListModifed.Count; i++)
            {
                for (int j = 0; j < setPeriodDayPerAllRoomsListModifed[i].listPeriodDayPerRoom.Count; j++)
                {
                    HeatPoint HeatPoint0 = new HeatPoint(setPeriodDayPerAllRoomsListModifed[i].listPeriodDayPerRoom[j].period, setPeriodDayPerAllRoomsListModifed[i].listPeriodDayPerRoom[j].day, i*2);

                    heatPoints.Add(HeatPoint0);
                    
                }

            }
            return heatPoints;
        }


        private void FreeRooms_Load(object sender, EventArgs e)
        {

        }

        public void SetPeriodDayPerAllRoomsListModifed()
        {
                                //kjo perfshin vetem ato qe jane nen 30
            List<RoomListWithCells> _setPeriodDayPerAllRoomsList= new List<RoomListWithCells>();
            List<RoomListWithCells> _setPeriodDayPerAllRoomsModifed= new List<RoomListWithCells>();

            FreeRoomList objfreeRoomList = new FreeRoomList();

            for (int i = 0; i < setPeriodDayPerAllRoomsList.Count; i++)
            {

                if (setPeriodDayPerAllRoomsList[i].listPeriodDayPerRoom.Count < 30)
                {
                    RoomListWithCells objRoomListWithCells = new RoomListWithCells();
                    objRoomListWithCells.room = setPeriodDayPerAllRoomsList[i].room;

                    List<PeriodDayPerRoom> listPeriodDayPerRoom = new List<PeriodDayPerRoom>();

                    for (int u = 0; u < 6; u++)
                    {
                        for (int v = 0; v < 5; v++)
                        {
                            PeriodDayPerRoom objPeriodDayPerRoom = new PeriodDayPerRoom();
                            objPeriodDayPerRoom.day = v;
                            objPeriodDayPerRoom.period = u;
                            listPeriodDayPerRoom.Add(objPeriodDayPerRoom);
                        }
                    }
                    objRoomListWithCells.listPeriodDayPerRoom = listPeriodDayPerRoom;
                    objfreeRoomList.setPeriodDayPerAllRoomsList.Add(objRoomListWithCells);
                    _setPeriodDayPerAllRoomsList.Add(setPeriodDayPerAllRoomsList[i]);
                }
            }


            for (int i = 0; i < _setPeriodDayPerAllRoomsList.Count; i++)
            {
                for (int j = 0; j < _setPeriodDayPerAllRoomsList[i].listPeriodDayPerRoom.Count; j++)
                {
                    int x = _setPeriodDayPerAllRoomsList[i].listPeriodDayPerRoom[j].day;
                    int y = _setPeriodDayPerAllRoomsList[i].listPeriodDayPerRoom[j].period;
                    bool value = false;
                    for (int u = 0; u < 6; u++)
                    {
                        for (int v = 0; v < 5; v++)
                        {
                            if (x == v && y == u)
                            {
                                value = true;
                            }
                        }
                    }

                    if (value == true)
                    {

                        //for (int m = 0; m < objfreeRoomList.setPeriodDayPerAllRoomsList.Count; m++)
                        //{
                            for (int w = 0; w < objfreeRoomList.setPeriodDayPerAllRoomsList[i].listPeriodDayPerRoom.Count; w++)
                            {
                                if (objfreeRoomList.setPeriodDayPerAllRoomsList[i].listPeriodDayPerRoom[w].day == x && objfreeRoomList.setPeriodDayPerAllRoomsList[i].listPeriodDayPerRoom[w].period == y)
                                {
                                    objfreeRoomList.setPeriodDayPerAllRoomsList[i].listPeriodDayPerRoom.RemoveAt(w);
                                }
                            }
                        //}
                    }
                }

                





            }



            _setPeriodDayPerAllRoomsModifed = objfreeRoomList.setPeriodDayPerAllRoomsList;
            setPeriodDayPerAllRoomsListModifed = _setPeriodDayPerAllRoomsModifed;



        }


        public string NameOfRoom(int day, int period)
        {
            string nameOfRooms = "";
            for(int i=0; i< setPeriodDayPerAllRoomsListModifed.Count; i++)
            {
                for(int j=0; j< setPeriodDayPerAllRoomsListModifed[i].listPeriodDayPerRoom.Count; j++)
                {
                    if (setPeriodDayPerAllRoomsListModifed[i].listPeriodDayPerRoom[j].day == day && setPeriodDayPerAllRoomsListModifed[i].listPeriodDayPerRoom[j].period == period)
                        nameOfRooms = nameOfRooms + ", " + setPeriodDayPerAllRoomsListModifed[i].room;
                }
            }
            return nameOfRooms;
        }





        //public ChartValues<HeatPoint> ChartValuesList()
        //{
        //    ChartValues<HeatPoint> heatPoints = new ChartValues<HeatPoint>();
        //    for (int i = 0; i < setPeriodDayPerAllRoomsList.Count; i++)
        //    {
        //        if (setPeriodDayPerAllRoomsList[i].listPeriodDayPerRoom.Count < 30)
        //        {
        //            //for (int u = 0; u < 6; u++)
        //            //{
        //                for (int j = 0; j < setPeriodDayPerAllRoomsList.Count; j++)
        //            {
        //                    //if(setPeriodDayPerAllRoomsList[i].listPeriodDayPerRoom[j].day)
        //                    //HeatPoint HeatPoint0 = new HeatPoint(i, 0, numberStudentMap[i, 0]);
        //                }

        //            //}

        //        }

        //    }
        //        //for (int i = 0; i < 6; i++)
        //        //{
        //        //    HeatPoint HeatPoint0 = new HeatPoint(i, 0, numberStudentMap[i, 0]);
        //        //    HeatPoint HeatPoint1 = new HeatPoint(i, 1, numberStudentMap[i, 1]);
        //        //    HeatPoint HeatPoint2 = new HeatPoint(i, 2, numberStudentMap[i, 2]);
        //        //    HeatPoint HeatPoint3 = new HeatPoint(i, 3, numberStudentMap[i, 3]);
        //        //    HeatPoint HeatPoint4 = new HeatPoint(i, 4, numberStudentMap[i, 4]);

        //        //    heatPoints.Add(HeatPoint0);
        //        //    heatPoints.Add(HeatPoint1);
        //        //    heatPoints.Add(HeatPoint2);
        //        //    heatPoints.Add(HeatPoint3);
        //        //    heatPoints.Add(HeatPoint4);
        //        //}
        //        return heatPoints;
        //}


        //private List<RoomListWithCells> GetPeriodDayPerAllRoomsList()
        //{
        //    List<RoomListWithCells> _getPeriodDayPerAllRoomsList = new List<RoomListWithCells>();
        //    List<PeriodDayPerRoom> listPeriodDayPerRoom = new List<PeriodDayPerRoom>();
        //    for (int i = 0; i < setPeriodDayPerAllRoomsList.Count; i++)
        //    {
        //        if (setPeriodDayPerAllRoomsList[i].listPeriodDayPerRoom.Count < 30)
        //        {
        //            for (int j = 0; j < setPeriodDayPerAllRoomsList[i].listPeriodDayPerRoom.Count; j++)
        //            {
        //                bool value = false;
        //                for (int u = 0; u < 6; u++)
        //                {
        //                    for (int v = 0; v < 5; v++)
        //                    {
        //                        value = (setPeriodDayPerAllRoomsList[i].listPeriodDayPerRoom[j].day == u && setPeriodDayPerAllRoomsList[i].listPeriodDayPerRoom[j].day == v);
        //                        if (value)
        //                        {

        //                        }



        //                    }



        //                }
        //            }


        //        }

        //    }

        //}
    }
}
