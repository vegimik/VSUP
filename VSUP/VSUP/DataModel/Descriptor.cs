using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSUP.DataModel
{
    public class Descriptor
    {
        public Days days { get; set; }
        public Periods_Per_Day periods_per_day { get; set; }
        public Daily_Lectures daily_lectures { get; set; }
        public Descriptor()
        {
            //days = new Days();
            //periods_per_day = new Periods_Per_Day();
            //daily_lectures = new Daily_Lectures();
        }
    }
    public class Days
    {
        public string value { get; set; }

    }
    public class Periods_Per_Day
    {
        public string value { get; set; }

    }
    public class Daily_Lectures
    {
        public string min { get; set; }
        
        public string max { get; set; }
    }
}
