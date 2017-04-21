using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Majorizor.Resources.DataAccess;

namespace Majorizor.Resources
{
    public class Advisor
    {
        public List<int> AdviseeIDs { get; private set; }

        public Advisor() { }
        public Advisor(string userName)
        {
            this.AdviseeIDs = GetAllAdviseeIDs(userName);
        }

        private static List<int> GetAllAdviseeIDs(string advisorEmail)
        {
            return AdvisorInformation.GetAllAdviseeIDs(advisorEmail);
        }

        static public void AddAdvisee(int advisorID, int studentID)
        {
            AdvisorInformation.AddAdvisee(advisorID, studentID);
        }

        static public void RemoveAdvisee(int advisorID, int studentID)
        {
            AdvisorInformation.RemoveAdvisee(advisorID, studentID);
        }
    }
}