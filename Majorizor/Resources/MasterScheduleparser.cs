using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;


namespace Majorizor.Resources
{
    public class MasterScheduleParser
    {
        public List<Course> EE;
        public List<Course> CE;
        public List<Course> SE;
        public List<Course> CS;
        public List<Course> MA;
        public MasterScheduleParser() { }
        public MasterScheduleParser(Stream scheduleStream)
        {
            StreamReader reader = new StreamReader(scheduleStream);
            string line;
            while(!reader.EndOfStream)
            {
                line = reader.ReadLine();
                string[] lineElements = line.Split(',');
                if (lineElements[1] == "EE")
                {
                    int id = Convert.ToInt16(lineElements[0]);
                    int catalog = Convert.ToInt16(lineElements[2]);
                    int section = Convert.ToInt16(lineElements[3]);
                    DateTime start = Convert.ToDateTime(lineElements[8]);
                    DateTime end = Convert.ToDateTime(lineElements[9]);
                    Course currentCourse = new Course(id, lineElements[1], catalog, section, lineElements[4], start, end, lineElements[10]);
                    EE.Add(currentCourse);
                }
                if (lineElements[1] == "CS")
                {
                    int id = Convert.ToInt16(lineElements[0]);
                    int catalog = Convert.ToInt16(lineElements[2]);
                    int section = Convert.ToInt16(lineElements[3]);
                    DateTime start = Convert.ToDateTime(lineElements[8]);
                    DateTime end = Convert.ToDateTime(lineElements[9]);
                    Course currentCourse = new Course(id, lineElements[1], catalog, section, lineElements[4], start, end, lineElements[10]);
                    CS.Add(currentCourse);
                }
                if (lineElements[1] == "MA")
                {
                    int id = Convert.ToInt16(lineElements[0]);
                    int catalog = Convert.ToInt16(lineElements[2]);
                    int section = Convert.ToInt16(lineElements[3]);
                    DateTime start = Convert.ToDateTime(lineElements[8]);
                    DateTime end = Convert.ToDateTime(lineElements[9]);
                    Course currentCourse = new Course(id, lineElements[1], catalog, section, lineElements[4], start, end, lineElements[10]);
                    MA.Add(currentCourse);
                }


            }

        }




    }

}