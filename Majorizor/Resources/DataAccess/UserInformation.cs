﻿using System;
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
                    user.setUserGroup(UserGroup.DEFUALT);
                    break;
            }
            return user;
        }
    }
}