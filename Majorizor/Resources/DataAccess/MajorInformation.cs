using System;
using System.Data;
using System.Web.Configuration;
using System.Collections.Generic;
using Majorizor.Resources.Majors;
using MySql.Data.MySqlClient;

namespace Majorizor.Resources.DataAccess
{
    public class MajorInformation
    {
        static string connString = WebConfigurationManager.ConnectionStrings["MajorizorConnectionString"].ConnectionString;

        /// <summary>
        /// Get a List of ALL 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<Course> GetRequiredCourses(MajorType type)
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
                    command.Parameters.AddWithValue("@i_degreeType", "MAJ");
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