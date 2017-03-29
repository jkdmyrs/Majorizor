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

            using(MySqlConnection connection = new MySqlConnection(connString))
            {
                MySqlCommand command = new MySqlCommand("GetAllAdviseeIDs", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@i_email", advisorEmail);

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(ds);
            }

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                IDs.Add((int)dr["studentID"]);
            }
            return IDs;
        }
    }
}