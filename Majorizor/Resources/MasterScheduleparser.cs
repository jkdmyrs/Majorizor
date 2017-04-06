using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;


namespace Majorizor.Resources
{
    public class MasterScheduleParser
    {
        public List<Course> EE = new List<Course>();
        public List<Course> CE = new List<Course>();
        public List<Course> SE = new List<Course>();
        public List<Course> CS = new List<Course>();
        public List<Course> MA = new List<Course>();
        public MasterScheduleParser() { }
        public MasterScheduleParser(Stream scheduleStream)
        {
            StreamReader reader = new StreamReader(scheduleStream);
            string line;
            while(!reader.EndOfStream)
            {
                line = reader.ReadLine();
                string[] lineElements = line.Split(',');
                if (lineElements[1] == "CS")
                {
                    int id = Convert.ToInt16(lineElements[0]);
                    int catalog = Convert.ToInt16(lineElements[2]);
                    if (lineElements[8] != "")
                    {
                        DateTime start = DateTime.Parse(lineElements[8]);
                        start.ToShortTimeString();
                        DateTime end = DateTime.Parse(lineElements[9]);
                        end.ToShortTimeString();
                        Course currentCourse = new Course(id, lineElements[1], catalog, lineElements[3], lineElements[4], start, end, lineElements[10]);
                        CS.Add(currentCourse);
                    }
                    else
                    {
                        DateTime start = Convert.ToDateTime("23:58:59");
                        start.ToShortTimeString();
                        DateTime end = Convert.ToDateTime("23:59:59");
                        end.ToShortTimeString();
                        Course currentCourse = new Course(id, lineElements[1], catalog, lineElements[3], lineElements[4], start, end,"NA");
                        CS.Add(currentCourse);
                    }

                }
                if (lineElements[1] == "EE")
                {
                    int id = Convert.ToInt16(lineElements[0]);
                    int catalog = Convert.ToInt16(lineElements[2]);
                    if (lineElements[8] != "")
                    {
                        DateTime start = DateTime.Parse(lineElements[8]);
                        start.ToShortTimeString();
                        DateTime end = DateTime.Parse(lineElements[9]);
                        end.ToShortTimeString();
                        Course currentCourse = new Course(id, lineElements[1], catalog, lineElements[3], lineElements[4], start, end, lineElements[10]);
                        EE.Add(currentCourse);
                    }
                    else
                    {
                        DateTime start = Convert.ToDateTime("23:58:59");
                        start.ToShortTimeString();
                        DateTime end = Convert.ToDateTime("23:59:59");
                        end.ToShortTimeString();
                        Course currentCourse = new Course(id, lineElements[1], catalog, lineElements[3], lineElements[4], start, end, "NA");
                        EE.Add(currentCourse);
                    }

                }
                if (lineElements[1] == "MA")
                {
                    int id = Convert.ToInt16(lineElements[0]);
                    int catalog = Convert.ToInt16(lineElements[2]);
                    if (lineElements[8] != "")
                    {
                        DateTime start = DateTime.Parse(lineElements[8]);
                        start.ToShortTimeString();
                        DateTime end = DateTime.Parse(lineElements[9]);
                        end.ToShortTimeString();
                        Course currentCourse = new Course(id, lineElements[1], catalog, lineElements[3], lineElements[4], start, end, lineElements[10]);
                        MA.Add(currentCourse);
                    }
                    else
                    {
                        DateTime start = Convert.ToDateTime("23:58:59");
                        start.ToShortTimeString();
                        DateTime end = Convert.ToDateTime("23:59:59");
                        end.ToShortTimeString();
                        Course currentCourse = new Course(id, lineElements[1], catalog, lineElements[3], lineElements[4], start, end, "NA");
                        MA.Add(currentCourse);
                    }

                }



            }

        }




    }

}