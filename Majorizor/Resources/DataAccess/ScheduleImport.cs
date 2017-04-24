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

        /// <summary>
        /// Handles database code for Resources.MasterSchedueLoader.LoadSchedule
        /// 
        /// Preforms an SQL transaction to import each Course object in the schedule list
        /// 
        /// Calls `UploadMasterSchedule` stored procedure for each Course in list
        /// 
        /// If all calls to stored procedure are successfull, the transaction is commited
        /// Otherwise the transaction is rolled back
        /// This is to prevent only part of a MasterSchedule to be uploaded in the event that a single row failed to process
        /// 
        /// Catches MySQL exceptions, throws new exception with detalied error 
        /// </summary>
        /// <param name="schedule">A list of Course objects</param>
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