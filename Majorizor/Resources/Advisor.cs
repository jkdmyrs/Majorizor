using System.Collections.Generic;
using Majorizor.Resources.DataAccess;

namespace Majorizor.Resources
{
    public class Advisor
    {
        #region Member Variables
        public List<int> AdviseeIDs { get; private set; }
        #endregion

        #region Constructors
        
        // Default constructor
        public Advisor() { }

        /// <summary>
        /// Initializes an Advisor object
        /// </summary>
        /// <param name="userName"></param>
        public Advisor(int userID)
        {
            AdviseeIDs = AdvisorInformation.GetAllAdviseeIDs(userID);
        }
        #endregion

        #region Static Methods

        /// <summary>
        /// Adds the given Student to the list of advisees for the given Advisor
        /// </summary>
        /// <param name="advisorID"></param>
        /// <param name="studentID"></param>
        static public void AddAdvisee(int advisorID, int studentID)
        {
            AdvisorInformation.AddAdvisee(advisorID, studentID);
        }

        /// <summary>
        /// Removes the given Student from the list of advisees for the given Advisor
        /// </summary>
        /// <param name="advisorID"></param>
        /// <param name="studentID"></param>
        static public void RemoveAdvisee(int advisorID, int studentID)
        {
            AdvisorInformation.RemoveAdvisee(advisorID, studentID);
        }
        #endregion
    }
}