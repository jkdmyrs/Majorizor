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

        // LoadGraduation
        //
        // Returns a DataTable to 
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