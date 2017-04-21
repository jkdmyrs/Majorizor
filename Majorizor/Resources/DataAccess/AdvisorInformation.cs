using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.Configuration;

namespace Majorizor.Resources.DataAccess
{
    public class AdvisorInformation
    {
        static string connString = WebConfigurationManager.ConnectionStrings["MajorizorConnectionString"].ConnectionString;

        public static List<int> GetAllAdviseeIDs(string advisorEmail)
        {
            List<int> IDs = new List<int>();
            DataSet ds = new DataSet("adviseeDS");
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    MySqlCommand command = new MySqlCommand("GetAllAdviseeIDs", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@i_email", advisorEmail);

                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = command;
                    adapter.Fill(ds);
                }

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    IDs.Add((int)dr["studentID"]);
                }
                return IDs;
            } catch (MySqlException ex)
            {
                string error = "AdvisorInfromation.GetAllAdviseeIDs failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }

        public static void AddAdvisee(int advisorID, int studentID)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    MySqlCommand command = new MySqlCommand("AddAdvisee", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@i_student", studentID);
                    command.Parameters.AddWithValue("@i_advisor", advisorID);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                string error = "AdvisorInformation.AddAdvisee failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }

        public static void RemoveAdvisee(int advisorID, int studentID)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    MySqlCommand command = new MySqlCommand("RemoveAdvisee", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@i_student", studentID);
                    command.Parameters.AddWithValue("@i_advisor", advisorID);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                string error = "AdvisorInformation.RemoveAdvisee failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }
    }
}