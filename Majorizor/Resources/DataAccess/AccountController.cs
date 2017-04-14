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
        public static UserGroup Login(string email, string password)
        {
            UserGroup userGroup;

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

                    MySqlParameter user_group_out = new MySqlParameter();
                    user_group_out.ParameterName = "@user_group_out";
                    user_group_out.MySqlDbType = MySqlDbType.VarChar;
                    user_group_out.Size = 10;
                    user_group_out.Direction = ParameterDirection.Output;

                    command.Parameters.Add(user_group_out);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    if (command.Parameters["@user_group_out"].Value.ToString() != "")
                    {
                        switch (user_group_out.Value.ToString())
                        {
                            case "ADMIN":
                                userGroup = UserGroup.ADMIN;
                                break;
                            case "ADVISOR":
                                userGroup = UserGroup.ADVISOR;
                                break;
                            case "USER":
                                userGroup = UserGroup.USER;
                                break;
                            default:
                                userGroup = UserGroup.DEFUALT;
                                break;
                        }
                        return userGroup;
                    }
                }
            }
            return UserGroup.DEFUALT;
        }

        //Add a new user to the user, user_password tables.
        public static void RegisterUser(string firstname, string lastname, string email, string password, string salt)
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
        }
        
        //Return the password's salt based on user email
        private static String getSalt(string email)
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
        }

        public static void UpdateUserGroup(int userID, UserGroup userGroup)
        {
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                MySqlCommand command = new MySqlCommand("UpdateUserGroup",connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@i_userID", userID);
                command.Parameters.AddWithValue("@i_userGroup", userGroup.ToString());

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}