using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace Majorizor.Resources.DataAccess
{

    public class StudentInformation
    {
        static string connString = WebConfigurationManager.ConnectionStrings["MajorizorConnectionString"].ConnectionString;

        public static Student getStudentByID(int userID)
        {
            Student student = new Student();
            DataSet ds = new DataSet("studentDS");
            
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                MySqlCommand command = new MySqlCommand("GetStudentByID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@i_userID", userID);

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(ds);
            }

            student = studentClassMapping(ds, userID);
            return student;
        }

        private static Student studentClassMapping(DataSet ds, int userID)
        {
            Student student = new Student();
            DataRow dr = ds.Tables[0].Rows[0];

            //Class Mapping code
            student.userID = userID;
            student.firstName = (string)dr["first_name"];
            student.lastName = (string)dr["last_name"];
            student.graduation = (string)dr["graduation"];

            switch ((string)dr["year"])
            {
                case "Freshman":
                    student.year = StudentYear.FRESHMAN;
                    break;
                case "Sophomore":
                    student.year = StudentYear.SOPHOMORE;
                    break;
                case "Junior":
                    student.year = StudentYear.JUNIOR;
                    break;
                case "Senior":
                    student.year = StudentYear.SENIOR;
                    break;
            }

            switch ((string)dr["major1"])
            {
                case "CE":
                    student.major1 = Major.CE;
                    break;
                case "CS":
                    student.major1 = Major.CS;
                    break;
                case "EE":
                    student.major1 = Major.EE;
                    break;
                case "MA":
                    student.major1 = Major.MA;
                    break;
                case "SE":
                    student.major1 = Major.SE;
                    break;
            }

            if (dr["major2"] != DBNull.Value)
            {
                switch ((string)dr["major2"])
                {
                    case "CE":
                        student.major1 = Major.CE;
                        break;
                    case "CS":
                        student.major1 = Major.CS;
                        break;
                    case "EE":
                        student.major1 = Major.EE;
                        break;
                    case "MA":
                        student.major1 = Major.MA;
                        break;
                    case "SE":
                        student.major1 = Major.SE;
                        break;
                }
            }
            else student.minor1 = Minor.NONE;

            if (dr["minor1"] != DBNull.Value)
            {
                switch ((string)dr["minor1"])
                {
                    case "CS":
                        student.minor1 = Minor.CS;
                        break;
                    case "EE":
                        student.minor1 = Minor.EE;
                        break;
                    case "MA":
                        student.minor1 = Minor.MA;
                        break;
                    case "SE":
                        student.minor1 = Minor.SE;
                        break;
                }
            }
            else student.minor1 = Minor.NONE;

            if (dr["minor2"] != DBNull.Value)
            {
                switch ((string)dr["minor2"])
                {
                    case "CS":
                        student.minor2 = Minor.CS;
                        break;
                    case "EE":
                        student.minor2 = Minor.EE;
                        break;
                    case "MA":
                        student.minor2 = Minor.MA;
                        break;
                    case "SE":
                        student.minor2 = Minor.SE;
                        break;
                }
            }
            else student.minor2 = Minor.NONE;

            return student;
        }
    }
}