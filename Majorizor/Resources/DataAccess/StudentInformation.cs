using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using Majorizor.Resources.Majors;
using Majorizor.Resources.Minors;

namespace Majorizor.Resources.DataAccess
{

    public class StudentInformation
    {
        static string connString = WebConfigurationManager.ConnectionStrings["MajorizorConnectionString"].ConnectionString;

        public static Student getStudentByID(int userID)
        {
            Student student = new Student();
            DataSet ds = new DataSet("studentDS");
            
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    MySqlCommand command = new MySqlCommand("GetStudentByID", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@i_userID", userID);

                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = command;
                    adapter.Fill(ds);
                }
                student = studentClassMapping(ds.Tables[0].Rows[0]);
                return student;
            } catch (MySqlException ex)
            {
                string error = "StudentInformation.getStudentByID failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }

        public static List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            DataSet ds = new DataSet("studentDS");
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    MySqlCommand command = new MySqlCommand("GetAllStudents", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    MySqlDataAdapter adpater = new MySqlDataAdapter();
                    adpater.SelectCommand = command;
                    adpater.Fill(ds);
                }
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    students.Add(studentClassMapping(dr));
                }

                return students;
            }
            catch (MySqlException ex)
            {
                string error = "StudentInformation.GetAllStudents failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }

        private static Student studentClassMapping(DataRow _dr)
        {
            Student student = new Student();
            DataRow dr = _dr;

            //Class Mapping code
            student.setUserID((int)dr["userID"]);
            student.setFirstName((string)dr["first_name"]);
            student.setLastName((string)dr["last_name"]);
            student.setGraduation((string)dr["graduation"]);

            switch ((string)dr["year"])
            {
                case "Freshman":
                    student.setStudentYear(StudentYear.FRESHMAN);
                    break;
                case "Sophomore":
                    student.setStudentYear(StudentYear.SOPHOMORE);
                    break;
                case "Junior":
                    student.setStudentYear(StudentYear.JUNIOR);
                    break;
                case "Senior":
                    student.setStudentYear(StudentYear.SENIOR);
                    break;
            }

            if (dr["major1"] != DBNull.Value)
            {
                switch ((string)dr["major1"])
                {
                    case "CE":
                        student.setMajor1(MajorType.CE);
                        break;
                    case "CS":
                        student.setMajor1(MajorType.CS);
                        break;
                    case "EE":
                        student.setMajor1(MajorType.EE);
                        break;
                    case "MA":
                        student.setMajor1(MajorType.MA);
                        break;
                    case "SE":
                        student.setMajor1(MajorType.SE);
                        break;
                }
            }
            else student.setMajor1(MajorType.NONE);

            if (dr["major2"] != DBNull.Value)
            {
                switch ((string)dr["major2"])
                {
                    case "CE":
                        student.setMajor2(MajorType.CE);
                        break;
                    case "CS":
                        student.setMajor2(MajorType.CS);
                        break;
                    case "EE":
                        student.setMajor2(MajorType.EE);
                        break;
                    case "MA":
                        student.setMajor2(MajorType.MA);
                        break;
                    case "SE":
                        student.setMajor2(MajorType.SE);
                        break;
                }
            }
            else student.setMajor2(MajorType.NONE);

            if (dr["minor1"] != DBNull.Value)
            {
                switch ((string)dr["minor1"])
                {
                    case "CS":
                        student.setMinor1(MinorType.CS);
                        break;
                    case "EE":
                        student.setMinor1(MinorType.EE);
                        break;
                    case "MA":
                        student.setMinor1(MinorType.MA);
                        break;
                    case "SE":
                        student.setMinor1(MinorType.SE);
                        break;
                }
            }
            else student.setMinor1(MinorType.NONE);

            if (dr["minor2"] != DBNull.Value)
            {
                switch ((string)dr["minor2"])
                {
                    case "CS":
                        student.setMinor2(MinorType.CS);
                        break;
                    case "EE":
                        student.setMinor2(MinorType.EE);
                        break;
                    case "MA":
                        student.setMinor2(MinorType.MA);
                        break;
                    case "SE":
                        student.setMinor2(MinorType.SE);
                        break;
                }
            }
            else student.setMinor2(MinorType.NONE);

            return student;
        }
    }
}