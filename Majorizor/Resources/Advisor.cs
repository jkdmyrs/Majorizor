using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Majorizor.Resources.DataAccess;

namespace Majorizor.Resources
{
    public class Advisor
    {
        public List<int> AdviseeIDs;

        public static List<int> GetAllAdviseeIDs(string advisorEmail)
        {
            return AdvisorInformation.GetAllAdviseeIDs(advisorEmail);
        }
    }
}