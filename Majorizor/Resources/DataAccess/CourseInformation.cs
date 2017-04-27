using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using MySql.Data.MySqlClient;

namespace Majorizor.Resources.DataAccess
{
    public class CourseInformation
    {
        static string connString = WebConfigurationManager.ConnectionStrings["MajorizorConnectionString"].ConnectionString;

        /// <summary>
        /// Class mapping for when you only need subject, catalog, and name in the object
        /// </summary>
        /// <param name="_dr">DataRow containing fields `subject`, `catalog`, and `name`</param>
        /// <returns>a Course object with subject, catalog, and name initialized</returns>
        public static Course partial_courseinfoClassMapping(DataRow _dr)
        {
            string subject = _dr["subject"].ToString();
            string catalog = _dr["catalog"].ToString();
            string name = _dr["name"].ToString();
            return new Course(subject, catalog, name);
        }

        public static List<Course> GetAllRequiredCourses()
        {
            List<Course> courses = new List<Course>();
            DataSet ds = new DataSet();
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                MySqlCommand command = new MySqlCommand("GetAllRequiredCourses", connection);
                command.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(ds);
            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                courses.Add(courseClassMapping(dr));
            }
            return courses;
        }

        /// <summary>
        /// Class mapping for full Course Object from database
        /// </summary>
        /// <param name="_dr"></param>
        /// <returns></returns>
        private static Course courseClassMapping(DataRow _dr)
        {
            Course c = new Course();
            c.setCatalog(_dr["catalog"].ToString());
            c.setDays(_dr["days"].ToString());
            c.setEndTime(DateTime.Parse(_dr["endTime"].ToString()));
            c.setID((int)_dr["id"]);
            c.setName(_dr["name"].ToString());
            c.setSection(_dr["section"].ToString());
            c.setStartTime(DateTime.Parse(_dr["startTime"].ToString()));
            c.setSubject(_dr["subject"].ToString());
            return c;
        }
    }
}