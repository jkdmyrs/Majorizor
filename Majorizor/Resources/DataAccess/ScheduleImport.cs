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
                    try
                    {
                        MySqlCommand command = new MySqlCommand("UploadMasterSchedule", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@i_ID", course.id);
                        command.Parameters.AddWithValue("@i_subject", course.subject);
                        command.Parameters.AddWithValue("@i_catalog", course.catalog);
                        command.Parameters.AddWithValue("@i_section", course.section);
                        command.Parameters.AddWithValue("@i_startTime", course.startTime.TimeOfDay);
                        command.Parameters.AddWithValue("@i_endTime", course.endTime.TimeOfDay);
                        command.Parameters.AddWithValue("@i_days", course.days);

                        command.ExecuteNonQuery();
                    }
                    catch (MySqlException e)
                    // TODO - Handle when an update fails.
                    {
                        connection.Close();
                        string error = "Update failed on course " + course.id + " with error: " + e.Message;
                        throw new Exception(error, e);
                    }
                }
                connection.Close();
            }
        }
    }
}