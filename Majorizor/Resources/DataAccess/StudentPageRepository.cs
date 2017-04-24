using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.Configuration;

namespace Majorizor.Resources.DataAccess
{
    public class StudentPageRepository
    {
        static string connString = WebConfigurationManager.ConnectionStrings["MajorizorConnectionString"].ConnectionString;

        /// <summary>
        /// Used to fill graduation DropDownList
        /// 
        /// Calls `GetGraduation` stored procedure
        /// 
        /// Catches MySQL exceptions, throws new exception with detalied error 
        /// </summary>
        /// <returns>A DataTable full of possible graduation terms</returns>
        static public DataTable LoadGraduation()
        {
            DataTable gradYears = new DataTable();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter("GetGraduation", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(gradYears);
                    return gradYears;
                }
            }
            catch (MySqlException ex)
            {
                string error = "StudentPageRepository.LoadGraduation failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }

        /// <summary>
        /// Inserts the given information into the student_info table in the database
        /// 
        /// Calls `SetStudentInformation` stored procedure
        /// 
        /// Catches MySQL exceptions, throws new exception with detalied error 
        /// </summary>
        /// <param name="userID">userID of student</param>
        /// <param name="termID">graduation termID (from graduation DropDownList)</param>
        /// <param name="year">Current year (from year DropDownList)</param>
        static public void SetStudentInformation(int userID, int termID, string year)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    MySqlCommand command = new MySqlCommand("SetStudentInformation", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@i_studentID", userID);
                    command.Parameters.AddWithValue("@i_termID", termID);
                    command.Parameters.AddWithValue("@i_year", year);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                string error = "StudentPageRepository.SetStudentInformation failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }
    }
}