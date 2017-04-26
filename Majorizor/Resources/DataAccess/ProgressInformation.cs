using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Web.Configuration;
using System.Data;

namespace Majorizor.Resources.DataAccess
{
    public class ProgressInformation
    {
        static string connString = WebConfigurationManager.ConnectionStrings["MajorizorConnectionString"].ConnectionString;

        /// <summary>
        /// Handles database code for ProgressTracker.CalculateProgress
        /// 
        /// Calls `GetRequiredCourses` stored procedure
        /// 
        /// Catches MySQL exceptions, throws new exception with detalied error 
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns>List of ALL Courses required by given Student</returns>
        static public List<Course> GetRequiredCourses(int studentID)
        {
            List<Course> courses = new List<Course>();
            DataSet ds = new DataSet();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    MySqlCommand command = new MySqlCommand("GetReqCoursesByUserID", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@i_studentID", studentID);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(ds);
                }
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    courses.Add(CourseInformation.partial_courseinfoClassMapping(dr));
                }
                return courses;
            }
            catch (MySqlException ex)
            {
                string error = "ProgressInformatoin.GetRequiredCourses failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }

        /// <summary>
        /// Handles database code for ProgressTracker.CalculateProgress
        /// 
        /// Calls `GetTakenCourses` stored procedure
        /// 
        /// Catches MySQL exceptions, throws new exception with detalied error 
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns>List of Courses taken by given Student</returns>
        static public List<Course> GetTakenCourses(int studentID)
        {
            List<Course> courses = new List<Course>();
            DataSet ds = new DataSet();
            
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connString))
                {
                    MySqlCommand command = new MySqlCommand("GetTakenCourses", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@i_studentID", studentID);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(ds);
                }
                
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    courses.Add(CourseInformation.partial_courseinfoClassMapping(dr));
                }
                return courses;
            }
            catch (MySqlException ex)
            {
                string error = "ProgressInformation.GetTakenCourses failed with error: " + ex.Message;
                throw new Exception(error, ex);
            }
        }
    }
}