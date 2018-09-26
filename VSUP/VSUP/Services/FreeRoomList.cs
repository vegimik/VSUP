using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSUP.Services
{
    class FreeRoomList
    {
        public static List<DataSolution> listData = TeacherAgendList.listData;
        public List<RoomListWithCells> setPeriodDayPerAllRoomsList = new List<RoomListWithCells>();
               
        public List<string> LabelRoomsList(List<DataSolution> listData)
        {
            List<string> listDataLabelRooms = new List<string>();
            for (int i = 0; i < listData.Count; i++)
            {
                listDataLabelRooms.Add(listData[i].RoomRef);
            }       
            listDataLabelRooms=listDataLabelRooms.Distinct().ToList();           
            return listDataLabelRooms;
        }

        public List<PeriodDayPerRoom> SetPeriodDayPerRoomList(string room)
        {
            List<PeriodDayPerRoom> _setPeriodDayPerRoomList = new List<PeriodDayPerRoom>();
            for(int i=0; i<listData.Count; i++)
            {
                if(listData[i].RoomRef==room)
                {
                    PeriodDayPerRoom objPeriodDayPerRoom = new PeriodDayPerRoom();
                    objPeriodDayPerRoom.day = listData[i].DayNumber;
                    objPeriodDayPerRoom.period = listData[i].PeriodNumber;
                    _setPeriodDayPerRoomList.Add(objPeriodDayPerRoom);
                }
            }
            return _setPeriodDayPerRoomList;
        }

        public List<RoomListWithCells> SetPeriodDayPerAllRoomsList()
        {
            List<RoomListWithCells> _setPeriodDayPerAllRoomsList = new List<RoomListWithCells>();
            List<string> _labelRoomsList = LabelRoomsList(listData);
            for(int i=0; i< _labelRoomsList.Count; i++)
            {
                RoomListWithCells objRoomListWithCells = new RoomListWithCells();
                objRoomListWithCells.room = _labelRoomsList[i];
                objRoomListWithCells.listPeriodDayPerRoom = SetPeriodDayPerRoomList(_labelRoomsList[i]);
                _setPeriodDayPerAllRoomsList.Add(objRoomListWithCells);
            }
            return _setPeriodDayPerAllRoomsList;
        }      
    }

    class RoomListWithCells
    {
        public string room { get; set; }
        public List<PeriodDayPerRoom> listPeriodDayPerRoom { get; set; }
    }

    class PeriodDayPerRoom
    {
        public int day { get; set; }
        public int period { get; set; }
    }
}
