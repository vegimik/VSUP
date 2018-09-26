using VSUP.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSUP.Services
{
    class TeacherAgendList
    {
        public static List<DataSolution> listData = new List<DataSolution>();
        public static Instance objInstance = new Instance();
        public static List<TeacherAgend> teacherAgends = new List<TeacherAgend>();

        public TeacherAgendList()
        {

        }

        public static string ConvertFromCourseIDToTeacherID(string CourseId)
        {
            string studentNumber = "";
            for (int i = 0; i < objInstance.courses.courseList.Count; i++)
            {
                if (objInstance.courses.courseList[i].id == CourseId)
                {
                    studentNumber = objInstance.courses.courseList[i].teacher;
                    break;
                }
            }
            return studentNumber;
        }

        public static List<AgendId> AgendIdList(string courseId)
        {

            List<AgendId> agendIds = new List<AgendId>();
            for (int i=0; i<listData.Count; i++)
            {                
                if (listData[i].CourseID==courseId)
                {
                    AgendId agendId = new AgendId();
                    agendId.day = listData[i].DayNumber;
                    agendId.period = listData[i].PeriodNumber;
                    agendIds.Add(agendId);
                }                
            }
            return agendIds;
        }

        public static List<TeacherAgend> TeacherAgendAllList()
        {
            List<TeacherAgend> teacherAgends = new List<TeacherAgend>();
            for(int i=0; i<objInstance.courses.courseList.Count; i++)
            {
                TeacherAgend teacherAgend = new TeacherAgend();
                teacherAgend.courseId = objInstance.courses.courseList[i].id;
                teacherAgend.teacherId = objInstance.courses.courseList[i].teacher;
                teacherAgend.agendIds = AgendIdList(objInstance.courses.courseList[i].id);
                teacherAgends.Add(teacherAgend);
            }
            return teacherAgends;
        }
    }

    class TeacherAgend
    {
        public string teacherId { get; set; }
        public string courseId { get; set; }
        public List<AgendId> agendIds { get; set; }

    }

    class AgendId
    {
        public int day { get; set; }
        public int period { get; set; }
    }
}
