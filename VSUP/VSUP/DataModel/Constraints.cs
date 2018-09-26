using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSUP.DataModel
{
    public class Constraints
    {

        public List<Constraint> constraint = new List<Constraint>();// { get; set; }
        public Constraints()
        {
            //constraint = new List<Constraint>();
        }
    }
    public class Constraint
    {
        
        public string type { get; set; }
        
        public string course { get; set; }

        public List<Timeslot> timeslot = new List<Timeslot>();// { get; set; }

        public List<Room1> room = new List<Room1>();// { get; set; }
    }
    public class Timeslot
    {
        
        public string day { get; set; }
        
        public string period { get; set; }
    }
    public class Room1
    {
        
        public string @ref { get; set; }
    }

}
