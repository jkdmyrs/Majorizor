using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Configuration;
using MySql.Data.MySqlClient;

namespace Majorizor.Resources.DataAccess
{
    public class ScheduleImport
    {
        static string connString = WebConfigurationManager.ConnectionStrings["MajorizorConnectionString"].ConnectionString;

        public static void ImportMasterSchedule(List<Course> schedule)
        {
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();
                foreach (Course course in schedule)
                {
                    MySqlCommand command = new MySqlCommand("InsertIntoCourse", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    //add all parameters
                    command.Parameters.AddWithValue("name", course.id);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}