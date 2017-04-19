using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using Majorizor.Resources;

namespace Majorizor.Resources.DataAccess
{
    public class AccountController
    {
        static string connString = WebConfigurationManager.ConnectionStrings["MajorizorConnectionString"].ConnectionString;

        //Returns the userGroup and userName if the login is successful, 
        //  else rueturns userName = null, userGroup = DEFAULT
        public static User Login(string email, string password)
        {
            User user = new User();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    string salt = getSalt(email);
                    if (salt != "")
                    {
                        string hashedPass = Security.Security.generateHash(password, salt);

                        MySqlCommand command = new MySqlCommand("Login", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@input_email", email);
                        command.Parameters.AddWithValue("@input_password", hashedPass);

                        MySqlParameter o_userID = new MySqlParameter();
                        o_userID.ParameterName = "@o_userID";
                        o_userID.MySqlDbType = MySqlDbType.Int32;
                        o_userID.Size = 11;
                        o_userID.Direction = ParameterDirection.Output;

                        command.Parameters.Add(o_userID);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();


                        if (command.Parameters["@o_userID"].Value.ToString() != "")
                        {
                            user = new User((int)o_userID.Value);
                            return user;
                        }
                    }
                }
                return user;
            } catch (MySqlException ex)
            {
                string error = "AccountController.Login failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }

        //Add a new user to the user, user_password tables.
        public static void RegisterUser(string firstname, string lastname, string email, string password, string salt)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    MySqlCommand command = new MySqlCommand("Register", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@i_first_name", firstname);
                    command.Parameters.AddWithValue("@i_last_name", lastname);
                    command.Parameters.AddWithValue("@i_email", email);
                    command.Parameters.AddWithValue("@i_password", password);
                    command.Parameters.AddWithValue("@i_salt", salt);


                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            } catch (MySqlException ex)
            {
                string error = "AccountController.Registration failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }
        
        //Return the password's salt based on user email
        private static String getSalt(string email)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    MySqlCommand command = new MySqlCommand("GetSalt", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@i_email", email);

                    MySqlParameter salt = new MySqlParameter();
                    salt.ParameterName = "@o_salt";
                    salt.MySqlDbType = MySqlDbType.VarChar;
                    salt.Size = 16;
                    salt.Direction = ParameterDirection.Output;

                    command.Parameters.Add(salt);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    return command.Parameters["@o_salt"].Value.ToString();
                }
            } catch (MySqlException ex)
            {
                string error = "AccountController.getSalt failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }
    }
}