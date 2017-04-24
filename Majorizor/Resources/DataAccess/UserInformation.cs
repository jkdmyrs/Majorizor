using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace Majorizor.Resources.DataAccess
{
    public class UserInformation
    {
        static string connString = WebConfigurationManager.ConnectionStrings["MajorizorConnectionString"].ConnectionString;

        /// <summary>
        /// Handles the database code for Resources.User.GetAllUsers()
        /// 
        /// Calls `GetAllUsers` stored procedure
        /// 
        /// Catches MySQL exceptions, throws new exception with detalied error 
        /// </summary>
        /// <returns>A List of User objects initialized for all users in the system</returns>
        public static List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            DataSet ds = new DataSet("usersDS");

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    MySqlCommand command = new MySqlCommand("GetAllUsers", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = command;
                    adapter.Fill(ds);
                }

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    User user = userClassMapping(row);
                    users.Add(user);
                }

                return users;
            } catch (MySqlException ex)
            {
                string error = "UserInformation.GetAllUsers failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }

        /// <summary>
        /// Handles database code for Resources.User constructor
        /// 
        /// Calls `GetUserByID` stored procedure
        /// 
        /// Catches MySQL exceptions, throws new exception with detalied error 
        /// </summary>
        /// <param name="userID">userID of User to initialize</param>
        /// <returns>Initalized User with given userID</returns>
        public static User GetUserByID(int userID)
        {
            DataSet ds = new DataSet("userDS");

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    MySqlCommand command = new MySqlCommand("GetUserById", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@i_userID", userID);
                    MySqlDataAdapter adpater = new MySqlDataAdapter();
                    adpater.SelectCommand = command;
                    adpater.Fill(ds);
                }
                DataRow dr = ds.Tables[0].Rows[0];
                User user = userClassMapping(dr);
                return user;
            } catch (MySqlException ex)
            {
                string error = "UserInformation.GetUserByID failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }

        /// <summary>
        /// Handles database code for Resources.User.UpdateUserGroup
        /// 
        /// Calls `UpdateUserGroup` stored procedure
        /// 
        /// Catches MySQL exceptions, throws new exception with detalied error 
        /// </summary>
        /// <param name="userID">userID of the User to update</param>
        /// <param name="userGroup">New UserGroup</param>
        public static void UpdateUserGroup(int userID, UserGroup userGroup)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    MySqlCommand command = new MySqlCommand("UpdateUserGroup", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@i_userID", userID);
                    command.Parameters.AddWithValue("@i_userGroup", userGroup.ToString());
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                string error = "UserInformation.UpdateUserGroup failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }

        /// <summary>
        /// Handles database code for Resources.User.DeleteUser
        /// 
        /// Calls `DeleteUserByID` stored procedure
        /// 
        /// Catches MySQL exceptions, throws new exception with detalied error 
        /// </summary>
        /// <param name="userID"></param>
        public static void DeleteUser(int userID)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    MySqlCommand command = new MySqlCommand("DeleteUserByID", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@i_userID", userID);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                string error = "UserInformation.DeleteUser failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }

        /// <summary>
        /// PRIVATE
        /// Maps the results of a User query on the database into a User object
        /// </summary>
        /// <param name="_dr">A DataRow returned from a query on the database for a User object</param>
        /// <returns>A User object initalized to the values in the DataRow</returns>
        private static User userClassMapping(DataRow _dr)
        {
            User user = new User();
            DataRow dr = _dr;

            //Class Mapping code 
            user.setUserID((int)dr["userID"]);
            user.setFirstName((string)dr["firstName"]);
            user.setLastName((string)dr["lastName"]);
            user.setEmail((string)dr["email"]);
            switch ((string)dr["userGroup"])
            {
                case "USER":
                    user.setUserGroup(UserGroup.USER);
                    break;
                case "ADVISOR":
                    user.setUserGroup(UserGroup.ADVISOR);
                    break;
                case "ADMIN":
                    user.setUserGroup(UserGroup.ADMIN);
                    break;
                default:
                    user.setUserGroup(UserGroup.NONE);
                    break;
            }
            return user;
        }
    }
}