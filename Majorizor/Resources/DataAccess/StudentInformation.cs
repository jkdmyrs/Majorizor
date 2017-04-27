using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Handles database code for Resources.Student constructor
        /// 
        /// Calls `GetStudentByID` stored procedure
        /// 
        /// Catches MySQL exceptions, throws new exception with detalied error 
        /// </summary>
        /// <param name="userID">userID of student to initialize</param>
        /// <returns>Initalized Student with given userID</returns>
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

        /// <summary>
        /// Handles the database code for Resources.Student.GetAllStudents()
        /// 
        /// Calls `GetAllStudents` stored procedure
        /// 
        /// Catches MySQL exceptions, throws new exception with detalied error 
        /// </summary>
        /// <returns>A List of Student objects initialized for all students in the system</returns>
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

        /// <summary>
        /// Handles database code for Student.GetAdvisorName()
        /// 
        /// Calls `GetAdvisorName` stored procedure
        /// 
        /// Catches MySQL exceptions, throws new exception with detalied error 
        /// </summary>
        /// <param name="studentID">studentID to get Advisor name for</param>
        /// <returns>Advisor name as string</returns>
        public static string GetAdvisorName(int studentID)
        {
            string fName, lName, fullName;
            DataSet ds = new DataSet();
            DataRow dr;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    MySqlCommand command = new MySqlCommand("GetAdvisorName", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@i_studentID", studentID);
                    MySqlDataAdapter adpater = new MySqlDataAdapter(command);
                    adpater.Fill(ds);
                }
                dr = ds.Tables[0].Rows[0];
                fName = dr["firstName"].ToString();
                lName = dr["lastName"].ToString();
                fullName = fName + " " + lName;
                return fullName;
            }
            catch (IndexOutOfRangeException)
            {
                return "N/A";
            }
            catch (MySqlException ex)
            {
                string error = "StudentInformation.GetAdvisorName failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }

        /// <summary>
        /// PRIVATE
        /// Maps the results of a Student query on the database into a Student object
        /// </summary>
        /// <param name="_dr">A DataRow returned from a query on the database for a Student object</param>
        /// <returns>A Student object initalized to the values in the DataRow</returns>
        private static Student studentClassMapping(DataRow _dr)
        {
            Student student = new Student();

            //Class Mapping code
            student.setUserID((int)_dr["userID"]);
            student.setFirstName((string)_dr["first_name"]);
            student.setLastName((string)_dr["last_name"]);
            student.setGraduation((string)_dr["graduation"]);

            switch ((string)_dr["year"])
            {
                case "Freshman":
                    student.setStudentYear(StudentYear.Freshman);
                    break;
                case "Sophomore":
                    student.setStudentYear(StudentYear.Sophomore);
                    break;
                case "Junior":
                    student.setStudentYear(StudentYear.Junior);
                    break;
                case "Senior":
                    student.setStudentYear(StudentYear.Senior);
                    break;
            }

            if (_dr["major1"] != DBNull.Value)
            {
                switch ((string)_dr["major1"])
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

            if (_dr["major2"] != DBNull.Value)
            {
                switch ((string)_dr["major2"])
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

            if (_dr["minor1"] != DBNull.Value)
            {
                switch ((string)_dr["minor1"])
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

            if (_dr["minor2"] != DBNull.Value)
            {
                switch ((string)_dr["minor2"])
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