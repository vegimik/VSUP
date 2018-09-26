using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSUP.DataModel
{
   
    public class Instance
    {
        
        public string name { get; set; }
        public Descriptor descriptor { get; set; }
        public Courses courses { get; set; }
        public Rooms rooms { get; set; }
        public Curricula curricula { get; set; }
        public Constraints constraints { get; set; }

        public Instance()
        {

            //descriptor = new Descriptor();
        }
    }

}
