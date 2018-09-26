using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSUP.Services
{
    class RoomUtilizationClass
    {
        public List<RoomClass> RoomUtilizationList = new List<RoomClass>();
    }


    class RoomClass
    {
        public string RoomRef { get; set; }
        public int RoomValueUtil{ get; set; }
    }
}
