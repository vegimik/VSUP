using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSUP.DataModel
{

    
    public class Rooms
    {
        public List<Room> roomList = new List<Room>();
    }

    public class Room
    {        
        public string id { get; set; }        
        public string size { get; set; }        
        public string building { get; set; }

        public Room(string id, string size, string building)
        {
            this.id = id;
            this.size = size;
            this.building = building;
        }

    }
}
