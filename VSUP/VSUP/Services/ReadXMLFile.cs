using VSUP.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace VSUP.Services
{
    public class ReadXMLFile
    {
        public static Instance objInstance = new Instance();

        public ReadXMLFile()
        {
            
        }
        public Instance UploadXML()
        {
            UploadXMLFileSOL();
            return objInstance;
        }

        public void UploadXMLFileSOL()
        {
            Descriptor objDescriptor = new Descriptor();
            Courses objCourses = new Courses();
            Rooms objRooms = new Rooms();
            Curricula objCurricula = new Curricula();
            Constraints objConstraints = new Constraints();

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = ".";
            openFileDialog1.Filter = "Xml files (*.xml)|*.xml";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(openFileDialog1.FileName);
                    string name = "";

                    foreach (XmlNode node in doc.DocumentElement)
                    {
                        if (doc.DocumentElement.Name.ToString() == "instance")
                        {
                            objInstance.name = doc.DocumentElement.Attributes[0].InnerText.ToString();
                            if (node.Name.ToString() == "descriptor")
                            {

                                foreach (XmlNode child in node.ChildNodes)//"days" or "periods_per_day" or "daily_lectures"
                                {

                                    if (child.Name.ToString() == "days")
                                    {
                                        Days objDays = new Days();
                                        objDays.value = child.Attributes[0].InnerText.ToString();
                                        objDescriptor.days = objDays;
                                    }
                                    else if (child.Name.ToString() == "periods_per_day")
                                    {
                                        Periods_Per_Day objPeriods_Per_Day = new Periods_Per_Day();
                                        objPeriods_Per_Day.value = child.Attributes[0].InnerText.ToString();
                                        objDescriptor.periods_per_day = objPeriods_Per_Day;
                                    }
                                    else if (child.Name.ToString() == "daily_lectures")
                                    {
                                        Daily_Lectures objDaily_Lectures = new Daily_Lectures();
                                        objDaily_Lectures.min = child.Attributes[0].InnerText.ToString();
                                        objDaily_Lectures.max = child.Attributes[1].InnerText.ToString();
                                        objDescriptor.daily_lectures = objDaily_Lectures;
                                    }
                                }
                                objInstance.descriptor = objDescriptor;

                            }
                            else if (node.Name.ToString() == "courses")
                            {
                                // one by one - course
                                foreach (XmlNode child in node.ChildNodes)
                                {
                                    Course course = new Course(child.Attributes[0].InnerText, child.Attributes[1].InnerText, child.Attributes[2].InnerText, child.Attributes[3].InnerText, child.Attributes[4].InnerText, child.Attributes[5].InnerText);
                                    objCourses.courseList.Add(course);
                                }
                                objInstance.courses = objCourses;
                            }
                            else if (node.Name.ToString() == "rooms")
                            {
                                // one by one - course
                                foreach (XmlNode child in node.ChildNodes)
                                {
                                    Room room = new Room(child.Attributes[0].InnerText, child.Attributes[1].InnerText, child.Attributes[2].InnerText);
                                    objRooms.roomList.Add(room);
                                }
                                objInstance.rooms = objRooms;
                            }
                            else if (node.Name.ToString() == "curricula")
                            {

                                foreach (XmlNode child in node.ChildNodes)//curriculum
                                {
                                    Curriculum objCurriculum = new Curriculum();
                                    objCurriculum.id = child.Attributes[0].InnerText.ToString();

                                    foreach (XmlNode kids in child.ChildNodes)//course
                                    {
                                        Course1 objCourse1 = new Course1();
                                        objCourse1.@ref = kids.Attributes[0].InnerText.ToString();
                                        objCurriculum.course1.Add(objCourse1);

                                    }
                                    objCurricula.curriculum.Add(objCurriculum);
                                }
                                objInstance.curricula = objCurricula;
                            }
                            else if (node.Name.ToString() == "constraints")
                            {

                                foreach (XmlNode child in node.ChildNodes)//constraint
                                {
                                    Constraint objConstraint = new Constraint();
                                    objConstraint.type = child.Attributes[0].InnerText.ToString();
                                    objConstraint.course = child.Attributes[1].InnerText.ToString();

                                    foreach (XmlNode kids in child)
                                    {

                                        if (kids.Name.ToString() == "timeslot")
                                        {
                                            Timeslot objTimeslot = new Timeslot();
                                            objTimeslot.day = kids.Attributes[0].InnerText.ToString();
                                            objTimeslot.period = kids.Attributes[1].InnerText.ToString();
                                            objConstraint.timeslot.Add(objTimeslot);
                                        }
                                        else if (kids.Name.ToString() == "room")
                                        {
                                            Room1 objRoom1 = new Room1();
                                            objRoom1.@ref = kids.Attributes[0].InnerText.ToString();
                                            objConstraint.room.Add(objRoom1);
                                        }
                                    }
                                    objConstraints.constraint.Add(objConstraint);
                                }
                                objInstance.constraints = objConstraints;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
