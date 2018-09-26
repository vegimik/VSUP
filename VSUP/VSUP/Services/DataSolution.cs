using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VSUP.Services
{
    public class DataSolution
    {
        
        public string CourseID { get; set; }
        public string RoomRef { get; set; }
        public int DayNumber { get; set; }
        public int PeriodNumber { get; set; }

        public int Seed { get; set; }
        public double Time { get; set; }
        public int Cost { get; set; }
        public int TotalCost { get; set; }

        public DataSolution()
        {
                
        }

        public DataSolution(string CourseID, string RoomRef, int DayNumber, int PeriodNumber)
        {
            this.CourseID = CourseID;
            this.RoomRef = RoomRef;
            this.DayNumber= DayNumber;
            this.PeriodNumber = PeriodNumber;
        }

        public List<DataSolution> UploadDataSolution()
        {
            List<DataSolution> listData = new List<DataSolution>();
            OpenFileDialog opf = new OpenFileDialog();
            DataSolution dT = new DataSolution();
            string[] lineListSol = new string[4];

            if (opf.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(opf.FileName);
                string lineSol = "";
                while ((lineSol = sr.ReadLine()) != null)
                {
                    lineListSol = lineSol.Split(' ');
                    
                    if(lineListSol[0] == "Seed")
                    {
                        Seed = Int32.Parse(lineListSol[1]);}
                    else if (lineListSol[0] == "Time")
                    {
                        Time = Double.Parse(lineListSol[1]);}
                    else if (lineListSol[0] == "Cost")
                    {
                        Cost = Int32.Parse(lineListSol[1]);
                    }
                    else if (lineListSol[0] == "Summary:")
                    {
                        string lastValueSummary = "";
                        foreach(string lineSummary in lineListSol)
                        {
                            lastValueSummary = lineSummary;
                        }
                        TotalCost = Int32.Parse(lastValueSummary);
                    }
                    else
                    {
                        dT.CourseID = lineListSol[0];
                        dT.RoomRef = lineListSol[1];
                        dT.DayNumber = Int32.Parse(lineListSol[2]);
                        dT.PeriodNumber = Int32.Parse(lineListSol[3]);

                        listData.Add(new DataSolution(lineListSol[0], lineListSol[1], Int32.Parse(lineListSol[2]), Int32.Parse(lineListSol[3])));
                    }
                   
                }
                //MessageBox.Show(listData.Count.ToString() + listData[4].CourseID + " : " + listData[4].RoomRef + " : " + listData[4].DayNumber + " : " + listData[4].PeriodNumber);
                sr.Close();
            }
            return listData;
        }


    }

    
}
