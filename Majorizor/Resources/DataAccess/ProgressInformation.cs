using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Majorizor.Resources.DataAccess
{
    public class ProgressInformation
    {
        /// <summary>
        /// Gets a list of ALL required courses for the given Student
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns>List of Courses required by given Student</returns>
        static public List<Course> GetRequiredCourses(int studentID)
        {
            return new List<Course>();
        }

        /// <summary>
        /// Gets a list of all taken courses for the given Student
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns>List of Courses taken by given Student</returns>
        static public List<Course> GetTakenCourses(int studentID)
        {
            return new List<Course>();
        }
    }
}