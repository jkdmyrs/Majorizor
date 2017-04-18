using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using MySql.Data.MySqlClient;


namespace Majorizor.Resources
{
    public class MasterScheduleLoader
    {
        public List<Course> ParsedMasterSchedule { get; private set; }
        public List<string> MajorList { get; private set; } 
        public List<string> ES_ElectiveList { get; private set; } 
        public StreamReader reader { get; private set; }

        public MasterScheduleLoader(Stream scheduleStream)
        {
            reader = new StreamReader(scheduleStream);
            ParsedMasterSchedule = new List<Course>();
            MajorList = new List<string> { "EE", "CS", "MA", "FY" };
            ES_ElectiveList = new List<string> { "100", "110", "220", "222", "250", "260", "340", "405", "499" };
        }
    
        private void InputSchedule()
        {
            string line;
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                string[] lineElements = line.Split('|');
                if (MajorList.Contains(lineElements[1]))
                {
                    int id = Convert.ToInt16(lineElements[0]);
                    string catalog = lineElements[2];
                    if (lineElements[8] != "")
                    {
                        DateTime start = DateTime.Parse(lineElements[8]);
                        start.ToShortTimeString();
                        DateTime end = DateTime.Parse(lineElements[9]);
                        end.ToShortTimeString();
                        Course currentCourse = new Course(id, lineElements[1], catalog, lineElements[3], lineElements[4], start, end, lineElements[10]);
                        ParsedMasterSchedule.Add(currentCourse);
                    }
                    else
                    {
                        DateTime start = Convert.ToDateTime("23:58:59");
                        start.ToShortTimeString();
                        DateTime end = Convert.ToDateTime("23:59:59");
                        end.ToShortTimeString();
                        Course currentCourse = new Course(id, lineElements[1], catalog, lineElements[3], lineElements[4], start, end, "NA");
                        ParsedMasterSchedule.Add(currentCourse);
                    }
                }

                if ((lineElements[1] == "CM" && ((lineElements[2] == "131") || (lineElements[2] == "132"))) ||
                        (lineElements[1] == "PH" && ((lineElements[2] == "131") || (lineElements[2] == "132"))) ||
                        (lineElements[1] == "ES" && (ES_ElectiveList.Contains(lineElements[2]))) ||
                        (lineElements[1] == "UNIV" && (lineElements[2] == "190")) ||
                        (lineElements[1] == "STAT" && (lineElements[2] == "383")))
                {
                    int id = Convert.ToInt16(lineElements[0]);
                    string catalog = lineElements[2];
                    if (lineElements[8] != "")
                    {
                        DateTime start = DateTime.Parse(lineElements[8]);
                        start.ToShortTimeString();
                        DateTime end = DateTime.Parse(lineElements[9]);
                        end.ToShortTimeString();
                        Course currentCourse = new Course(id, lineElements[1], catalog, lineElements[3], lineElements[4], start, end, lineElements[10]);
                        ParsedMasterSchedule.Add(currentCourse);
                    }
                    else
                    {
                        DateTime start = Convert.ToDateTime("23:58:59");
                        start.ToShortTimeString();
                        DateTime end = Convert.ToDateTime("23:59:59");
                        end.ToShortTimeString();
                        Course currentCourse = new Course(id, lineElements[1], catalog, lineElements[3], lineElements[4], start, end, "NA");
                        ParsedMasterSchedule.Add(currentCourse);
                    }
                }
            }
        }

        public void LoadSchedule()
        {
            InputSchedule();
            DataAccess.ScheduleImport.ImportMasterSchedule(this.ParsedMasterSchedule);
        }
    }
}