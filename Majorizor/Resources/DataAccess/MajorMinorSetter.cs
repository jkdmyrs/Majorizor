using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Majorizor.Resources.Majors;
using Majorizor.Resources.Minors;
using MySql.Data.MySqlClient;
using System.Web.Configuration;

namespace Majorizor.Resources.DataAccess
{
    public class MajorMinorSetter
    {
        static string connString = WebConfigurationManager.ConnectionStrings["MajorizorConnectionString"].ConnectionString;

        #region Setters
        public static void setMajor1(MajorType type, int studentID)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    MySqlCommand command = new MySqlCommand("SetMajor1", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@i_studentID", studentID);
                    command.Parameters.AddWithValue("@i_major", type.ToString());
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            } 
            catch (MySqlException ex)
            {
                string error = "MajorMinorSetter.setMajor1 failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }

        public static void setMajor2(MajorType type, int studentID)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    MySqlCommand command = new MySqlCommand("SetMajor2", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@i_studentID", studentID);
                    command.Parameters.AddWithValue("@i_major", type.ToString());
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                string error = "MajorMinorSetter.setMajor2 failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }

        public static void setMinor1(MinorType type, int studentID)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    MySqlCommand command = new MySqlCommand("SetMinor1", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@i_studentID", studentID);
                    command.Parameters.AddWithValue("@i_major", type.ToString());
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                string error = "MajorMinorSetter.setMinro1 failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }

        public static void setMinor2(MinorType type, int studentID)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    MySqlCommand command = new MySqlCommand("SetMinor2", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@i_studentID", studentID);
                    command.Parameters.AddWithValue("@i_major", type.ToString());
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                string error = "MajorMinorSetter.setMinor2 failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }
        #endregion

        #region Droppers
        public static void dropMajor1(int studentID)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    MySqlCommand command = new MySqlCommand("DropMajor1", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@i_studentID", studentID);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                string error = "MajorMinorSetter.dropMajor1 failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }

        public static void dropMajor2(int studentID)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    MySqlCommand command = new MySqlCommand("DropMajor2", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@i_studentID", studentID);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                string error = "MajorMinorSetter.dropMajor2 failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }

        public static void dropMinor1(int studentID)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    MySqlCommand command = new MySqlCommand("DropMinor1", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@i_studentID", studentID);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                string error = "MajorMinorSetter.dropMinor1 failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }

        public static void dropMinor2(int studentID)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    MySqlCommand command = new MySqlCommand("DropMinor2", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@i_studentID", studentID);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                string error = "MajorMinorSetter.dropMinor2 failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }
        #endregion
    }
}