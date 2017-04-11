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
                MySqlTransaction sqlTran = connection.BeginTransaction();
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

                        command.Transaction = sqlTran;
                        command.ExecuteNonQuery();
                    }
                    catch (MySqlException executeEx)
                    {
                        // TODO - Handle when an update fails.

                        // gracefully dispose objects
                        sqlTran.Rollback();
                        sqlTran.Dispose();
                        connection.Close();
                        connection.Dispose();
                        string error = "Update failed on course " + course.id + " with error: " + executeEx.Message;
                        throw new Exception(error, executeEx);
                    }
                }
                try
                {
                    sqlTran.Commit();
                }
                catch (MySqlException commitEx)
                {
                    // gracefully dispose objects
                    sqlTran.Rollback();
                    sqlTran.Dispose();
                    connection.Close();
                    connection.Dispose();
                    string error2 = "Commit failed with error: " + commitEx.Message;
                    throw new Exception(error2, commitEx);
                }
            }
        }
    }
}