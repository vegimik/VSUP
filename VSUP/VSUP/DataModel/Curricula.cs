using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSUP.DataModel
{
    public class Curricula
    {

        public List<Curriculum> curriculum = new List<Curriculum>();// { get; set; }
        public Curricula()
        {
            //curriculum = new List<Curriculum>();
        }
    }

    public class Curriculum
    {
        
        public string id { get; set; }

        public List<Course1> course1 = new List<Course1>(); //{ get; set; }
        public Curriculum()
        {
            //course = new List<Course1>();
        }
    }
    public class Course1
    {
        
        public string @ref { get; set; }
    }

}
