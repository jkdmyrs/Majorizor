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

        public static List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            DataSet ds = new DataSet("usersDS");

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                MySqlCommand command = new MySqlCommand("GetAllUsers", connection);
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
                    user.setUserGroup(UserGroup.USER);
                    break;
                case "ADMIN":
                    user.setUserGroup(UserGroup.ADMIN);
                    break;
                default:
                    user.setUserGroup(UserGroup.USER);
                    break;
            }
            return user;
        }
    }
}