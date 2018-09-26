using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSUP.Charts;
using VSUP.DataModel;
using VSUP.Services;

namespace VSUP
{
    public partial class Dashboard : Form
    {
        //public Dashboard()
        public Dashboard()
        {
            InitializeComponent();
        }
        DataSolution dS = new DataSolution();
        Instance objInstance = new Instance();
        List<DataSolution> listData = new List<DataSolution>();
        string[,] dataUpload = new string[6, 5];


        private void Dashboard_Load(object sender, EventArgs e)
        {

            dataGridView1_Design();
            dataGridView1_HeaderCell_Name();




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == 2 && e.ColumnIndex == 2)
            {
                MessageBox.Show("2x2");
            }

        }


        private void mouse_Hover(object sender, EventArgs e)
        {


        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {

        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == 3 && e.ColumnIndex == 3)
            {
                //dataGridView1.Rows[3].Cells[3].Style.BackColor = Color.Red;
            }
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_Design()
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            for (int i = 1; i <= 6; i = i + 2)
            {
                try
                {
                    for (int j = 0; j < 5; j++)
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(238, 239, 249);
                }
                catch (Exception e)
                {
                    //MessageBox.Show("Error message to Design " + e.Message);
                }
            }

        }

        private void dataGridView1_HeaderCell_Name()
        {
            try
            {
                dataGridView1.Rows[0].HeaderCell.Value = "08:00 - 10:00";
                dataGridView1.Rows[1].HeaderCell.Value = "10:00 - 12:00";
                dataGridView1.Rows[2].HeaderCell.Value = "12:00 - 14:00";
                dataGridView1.Rows[3].HeaderCell.Value = "14:00 - 16:00";
                dataGridView1.Rows[4].HeaderCell.Value = "16:00 - 18:00";
                dataGridView1.Rows[5].HeaderCell.Value = "18:00 - 20:00";
            }
            catch (Exception e)
            {
                //MessageBox.Show("Error message to HeaderCell_Name " + e.Message);
            }
        }

        public void dataGridView1_DataUpload(string monday, string tuesday, string wednesday, string thursday, string friday)
        {
            int n = 0;
            n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = monday;
            dataGridView1.Rows[n].Cells[1].Value = tuesday;
            dataGridView1.Rows[n].Cells[2].Value = wednesday;
            dataGridView1.Rows[n].Cells[3].Value = thursday;
            dataGridView1.Rows[n].Cells[4].Value = friday;
        }

        private void generate_dataUpload()
        {
            for (int i = 0; i < listData.Count; i++)
            {
                if (listData[i].DayNumber == 0)
                {
                    //Monday
                    chooseCoordinate(listData[i].PeriodNumber, listData[i].DayNumber, i);
                }
                else if (listData[i].DayNumber == 1)
                {
                    //Tuesday
                    chooseCoordinate(listData[i].PeriodNumber, listData[i].DayNumber, i);

                }
                else if (listData[i].DayNumber == 2)
                {
                    //Wednesday
                    chooseCoordinate(listData[i].PeriodNumber, listData[i].DayNumber, i);

                }
                else if (listData[i].DayNumber == 3)
                {
                    //Thursday
                    chooseCoordinate(listData[i].PeriodNumber, listData[i].DayNumber, i);

                }
                else if (listData[i].DayNumber == 4)
                {
                    //Friday
                    chooseCoordinate(listData[i].PeriodNumber, listData[i].DayNumber, i);
                }
            }

        }

        private void chooseCoordinate(int periodNumber, int dayNumber, int i)
        {
            switch (periodNumber)
            {
                case 0:
                    //Period 08:00 - 10:00
                    dataUpload[periodNumber, dayNumber] = (dataUpload[periodNumber, dayNumber] != null) ? (dataUpload[periodNumber, dayNumber] + ", " + listData[i].CourseID+"["+ConvertFromCourseIDToTeacherId(listData[i].CourseID) + "]") : (listData[i].CourseID + "[" + ConvertFromCourseIDToTeacherId(listData[i].CourseID) + "]");
                    break;
                case 1:
                    dataUpload[periodNumber, dayNumber] = (dataUpload[periodNumber, dayNumber] != null) ? (dataUpload[periodNumber, dayNumber] + ", " + listData[i].CourseID + "[" + ConvertFromCourseIDToTeacherId(listData[i].CourseID) + "]") : (listData[i].CourseID + "[" + ConvertFromCourseIDToTeacherId(listData[i].CourseID) + "]");
                    //Period 10:00 - 12:00
                    break;
                case 2:
                    dataUpload[periodNumber, dayNumber] = (dataUpload[periodNumber, dayNumber] != null) ? (dataUpload[periodNumber, dayNumber] + ", " + listData[i].CourseID + "[" + ConvertFromCourseIDToTeacherId(listData[i].CourseID) + "]") : (listData[i].CourseID + "[" + ConvertFromCourseIDToTeacherId(listData[i].CourseID) + "]");
                    //Period 12:00 - 14:00
                    break;
                case 3:
                    dataUpload[periodNumber, dayNumber] = (dataUpload[periodNumber, dayNumber] != null) ? (dataUpload[periodNumber, dayNumber] + ", " + listData[i].CourseID + "[" + ConvertFromCourseIDToTeacherId(listData[i].CourseID) + "]") : (listData[i].CourseID + "[" + ConvertFromCourseIDToTeacherId(listData[i].CourseID) + "]");
                    //Period 14:00 - 16:00
                    break;
                case 4:
                    dataUpload[periodNumber, dayNumber] = (dataUpload[periodNumber, dayNumber] != null) ? (dataUpload[periodNumber, dayNumber] + ", " + listData[i].CourseID + "[" + ConvertFromCourseIDToTeacherId(listData[i].CourseID) + "]") : (listData[i].CourseID + "[" + ConvertFromCourseIDToTeacherId(listData[i].CourseID) + "]");
                    //Period 16:00 - 18:00
                    break;
                case 5:
                    dataUpload[periodNumber, dayNumber] = (dataUpload[periodNumber, dayNumber] != null) ? (dataUpload[periodNumber, dayNumber] + ", " + listData[i].CourseID+"["+ConvertFromCourseIDToTeacherId(listData[i].CourseID) + "]") : (listData[i].CourseID + "[" + ConvertFromCourseIDToTeacherId(listData[i].CourseID) + "]");
                    //Period 18:00 - 20:00
                    break;
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowDataGridViewData();

            if (listData != null)
            {
                button2.Enabled = false;
                button2.Text = "Uploaded";
            }

            TransferDataBetweenClasses();

        }

        public void ShowDataGridViewData()
        {
            listData = dS.UploadDataSolution();
            generate_dataUpload();

            dataGridView1_DataUpload(dataUpload[0, 0], dataUpload[0, 1], dataUpload[0, 2], dataUpload[0, 3], dataUpload[0, 4]);
            dataGridView1_DataUpload(dataUpload[1, 0], dataUpload[1, 1], dataUpload[1, 2], dataUpload[1, 3], dataUpload[1, 4]);
            dataGridView1_DataUpload(dataUpload[2, 0], dataUpload[2, 1], dataUpload[2, 2], dataUpload[2, 3], dataUpload[2, 4]);
            dataGridView1_DataUpload(dataUpload[3, 0], dataUpload[3, 1], dataUpload[3, 2], dataUpload[3, 3], dataUpload[3, 3]);
            dataGridView1_DataUpload(dataUpload[4, 0], dataUpload[4, 1], dataUpload[4, 2], dataUpload[4, 3], dataUpload[4, 4]);
            dataGridView1_DataUpload(dataUpload[5, 0], dataUpload[5, 1], dataUpload[5, 2], dataUpload[5, 3], dataUpload[5, 4]);

            dataGridView1_HeaderCell_Name();
        }

        public string ConvertFromCourseIDToTeacherId(string CourseId)
        {
            string teacherNumber = "";
            for (int i = 0; i < objInstance.courses.courseList.Count; i++)
            {
                if (objInstance.courses.courseList[i].id == CourseId)
                {
                    teacherNumber = objInstance.courses.courseList[i].teacher;
                    break;
                }
            }
            return teacherNumber;
        }

        public void TransferDataBetweenClasses()
        {
            //MessageBox.Show("GJITHSESIII DUHET NDREQUR: Duhet ta ndryshojme listen e shenimve e sepse kur kursey jane doubke duhet te vendoset edhe diten tjeter");

            RoomUtilization.listData = listData;

            StudentMapList objStudentMapList = new StudentMapList();
            objStudentMapList.SetDataToMyProperty(listData);

            TeacherAgendList.listData = listData;
            TeacherAgendList.objInstance = objInstance;
            TeacherAgendList.teacherAgends = TeacherAgendList.TeacherAgendAllList();



        }



        private void button1_Click(object sender, EventArgs e)
        {
            ReadXMLFile readXMLFile = new ReadXMLFile();
            objInstance = readXMLFile.UploadXML();
            StudentMapList.objInstance = objInstance;
            CourseAgendMap.objInstance = objInstance;
            if (objInstance.name != null)
            {
                button1.Enabled = false;
                button1.Text = "Uploaded";
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 5; j++)
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;

            dataGridView1_Design();
            dataGridView1.Rows[0].Cells[0].Selected = false;

            string textDown = (textBox1.Text.ToString() + e.KeyChar.ToString()).ToLower();
            if (textDown.Length >= 5)
            {
                int j = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        //MessageBox.Show(row.Cells[i].Value.ToString());
                        if ((row.Cells[i].Value.ToString()).Contains(textDown))
                        {
                            dataGridView1.Rows[j].Cells[i].Style.BackColor = Color.FromArgb(0, 128, 204); ;
                        }
                    }
                    j++;
                }
            }


        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void button4_Click(object sender, EventArgs e)
        {
            RoomUtilization roomUtilization = new RoomUtilization();
            //List<string> LabelRoomsListttt = FreeRoomList.LabelRoomsList(listData);
            //List<PeriodDayPerRoom> SetPeriodDayPerRoomList = FreeRoomList.SetPeriodDayPerRoomList("rB");
            //FreeRoomList.setPeriodDayPerAllRoomsList = FreeRoomList.SetPeriodDayPerAllRoomsList();
            roomUtilization.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            new CourseAgendMap().Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {



        }

        private void button7_Click(object sender, EventArgs e)
        {
            ShowStudentMap showStudentMap = new ShowStudentMap();
            showStudentMap.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Its OK");




        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            new FreeRooms().Show();
        }
    }
}


