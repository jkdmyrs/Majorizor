using System;
using System.Collections.Generic;
using System.Linq;
using Majorizor.Resources.DataAccess;

namespace Majorizor.Resources
{
    /// <summary>
    /// TODO - In the future, this interface should be improved. 
    /// 
    /// Reccomended Improvements:
    ///  - Calculate the progress of each major/minor separately 
    ///    The Major and Minor classes are designed so that this should be relatively easy. 
    ///    
    ///  - Calculate progress with credits instead of number of courses
    ///  
    ///  - track required/taken courses for each major/minor separtely
    ///  
    /// The UI of the Advisor and Student panels should also be improved to use these features
    /// </summary>
    class ProgressTracker
    {
        public int studentID { get; private set; }
        public int progress { get; private set; }                       // progress as %, calculated by (# taken courses)/(totalCourses)*100 
                                                                        // TODO - Calculate this with credits instead of courses
        public List<Course> takenCourses { get; private set; }          // courses the student has taken
        public List<Course> requiredCourses { get; private set; }       // Courses the student is required to take (EXCEPT taken courses)
                                                                        // TODO - extend IEqualityComparer for Course to allow List.Except()
                                                                        
        public ProgressTracker(int userID)
        {
            studentID = userID;
        }

        /// <summary>
        /// Compile a list of a Student's taken courses.
        /// 
        /// Count total number of required courses
        /// 
        /// Compile a list of a Student's required courses (EXCEPT taken courses)
        /// 
        /// Calculate progress as percent
        /// </summary>
        /// <returns>progress as a percent</returns>
        public int CalculateProgress()
        {
            try
            {
                int requiredTotal, takenNum;
                requiredCourses = ProgressInformation.GetRequiredCourses(studentID);
                requiredTotal = requiredCourses.Count;
                takenCourses = ProgressInformation.GetTakenCourses(studentID);
                takenNum = takenCourses.Count;
                requiredCourses = requiredCourses.Except(takenCourses, new CourseComparer()).ToList();

                progress = takenNum*100 / requiredTotal;
                return progress;
            }
            catch (DivideByZeroException zeroEx)
            {
                string error = "ProgressTracker.CalculateProgress failed. No required courses found for userID: " + studentID + ". Has the user selected a Major?";
                throw new DivideByZeroException(error, zeroEx);
            }
        }


    }
}
