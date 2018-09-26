using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSUP.DataModel
{
    public class Courses
    {
        public List<Course> courseList = new List<Course>();// { get; set; }

        public Courses()
        {
            //course = new List<Course>();
        }
    }

    public class Course
    {
        
        public string id { get; set; }
        
        public string teacher { get; set; }
        
        public string lectures { get; set; }
        
        public string min_days { get; set; }
        
        public string students { get; set; }
        
        public string double_lectures { get; set; }

        public Course(string id, string teacher, string lectures, string min_days, string students, string double_lectures)
        {
            this.id = id;
            this.teacher = teacher;
            this.lectures = lectures;
            this.min_days = min_days;
            this.students = students;
            this.double_lectures = double_lectures;
                
        }
    }
}
