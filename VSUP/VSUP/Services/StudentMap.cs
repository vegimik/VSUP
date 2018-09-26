using VSUP.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSUP.Services
{
    class StudentMapList
    {      
        public static List<DataSolution> listData = new List<DataSolution>();
        public static List<StudentMap> studentMapList = new List<StudentMap>();
        public static int[,] numberStudentMap = new int[6, 5];
        public static Instance objInstance = new Instance();        
        public string ConvertFromCourseIDToStudentNumber(string CourseId)
        {
            string studentNumber = "";
            for(int i=0; i<objInstance.courses.courseList.Count; i++)
            {
                if(objInstance.courses.courseList[i].id==CourseId)
                {
                    studentNumber = objInstance.courses.courseList[i].students;
                    break;
                }
            }
            return studentNumber;            
        }
        public List<StudentMap> StudentMapListUnGruped()
        {
            for(int i=0; i<listData.Count; i++)
            {
                StudentMap studentMap = new StudentMap();
                studentMap.DayNumber = listData[i].DayNumber;
                studentMap.PeriodNumber = listData[i].PeriodNumber;
                studentMap.StudentNumber = Int32.Parse(ConvertFromCourseIDToStudentNumber(listData[i].CourseID));
                studentMapList.Add(studentMap);
            }
            return studentMapList;
        }
        public int[,] FindNumberStudentMap()
        {
            for (int i = 0; i<listData.Count; i++)
            {
                for (int ix = 0; ix < 6; ix++)
                {
                    for (int iy = 0; iy < 5; iy++)
                    {
                        if(ix==studentMapList[i].PeriodNumber && iy==studentMapList[i].DayNumber)
                        {
                            numberStudentMap[ix, iy]+= studentMapList[i].StudentNumber;
                        }
                    }
                }
            }
            return numberStudentMap;
        }
        public void SetDataToMyProperty(List<DataSolution> _listData)
        {
            listData = _listData;
            studentMapList = StudentMapListUnGruped();
            numberStudentMap = FindNumberStudentMap();
        }
    }

    class StudentMap
    {
        public int DayNumber { get; set; }
        public int PeriodNumber { get; set; }
        public int StudentNumber { get; set; }
    }
}
