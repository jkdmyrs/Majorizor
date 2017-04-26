using System;
using System.Data;
using System.Collections.Generic;
using Majorizor.Resources.Minors;
using MySql.Data.MySqlClient;
using System.Web.Configuration;

namespace Majorizor.Resources.DataAccess
{
    public class MinorInformation
    {
        static string connString = WebConfigurationManager.ConnectionStrings["MajorizorConnectionString"].ConnectionString;

        /// <summary>
        /// Get a List of ALL 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<Course> GetRequiredCourses(MinorType type)
        {
            List<Course> courses = new List<Course>();
            DataSet ds = new DataSet("reqCourses");
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    MySqlCommand command = new MySqlCommand("GetRequiredCourses", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@i_majorType", type.ToString());
                    command.Parameters.AddWithValue("@i_degreeType", "MIN");
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(ds);
                }
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    courses.Add(CourseInformation.partial_courseinfoClassMapping(dr));
                }
                return courses;
            }
            catch (MySqlException ex)
            {
                string error = "MajorInformation.GetRequiredCourses failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }
    }
}