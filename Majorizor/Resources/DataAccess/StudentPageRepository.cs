using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.Configuration;
using Majorizor.Resources.Majors;
using Majorizor.Resources.Minors;
using System.Collections.Generic;

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

        static public List<string> LoadMajorsDdl(int studentID)
        {
            List<Major> majors = new List<Major>();
            List<string> majorNames = new List<string>();
            majorNames.Add("< Select a Major >");
            DataSet ds = new DataSet();
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                MySqlCommand command = new MySqlCommand("GetAvailableMajors", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@i_studentID", studentID);
                command.Parameters.AddWithValue("@i_degreeType", "MAJ");
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(ds);
            }
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                switch (dr["major"].ToString())
                {
                    case "SE":
                        majors.Add(new SE_Major());
                        break;
                    case "EE":
                        majors.Add(new EE_Major());
                        break;
                    case "CE":
                        majors.Add(new CE_Major());
                        break;
                    case "MA":
                        majors.Add(new MA_Major());
                        break;
                    case "CS":
                        majors.Add(new CS_Major());
                        break;
                }
            }
            foreach (Major major in majors)
            {
                majorNames.Add(major.majorName);
            }
            return majorNames;
        }

        static public List<string> LoadMinorsDdl(int studentID)
        {
            List<Minor> minors = new List<Minor>();
            List<string> minorNames = new List<string>();
            minorNames.Add("< Select a Minor >");
            DataSet ds = new DataSet();
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                MySqlCommand command = new MySqlCommand("GetAvailableMajors", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@i_studentID", studentID);
                command.Parameters.AddWithValue("@i_degreeType", "MIN");
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(ds);
            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                switch (dr["major"].ToString())
                {
                    case "SE":
                        minors.Add(new SE_Minor());
                        break;
                    case "EE":
                        minors.Add(new EE_Minor());
                        break;
                    case "MA":
                        minors.Add(new MA_Minor());
                        break;
                    case "CS":
                        minors.Add(new CS_Minor());
                        break;
                }
            }
            foreach (Minor minor in minors)
            {
                minorNames.Add(minor.minorName);
            }
            return minorNames;
        }
    }
}