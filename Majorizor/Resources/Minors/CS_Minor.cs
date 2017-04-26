using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Majorizor.Resources.DataAccess;

namespace Majorizor.Resources.Minors
{
    public class CS_Minor : Minor
    {
        public CS_Minor()
        {
            minorType = MinorType.CS;
            minorName = "Computer Science";
            reqCourses = MinorInformation.GetRequiredCourses(minorType);
            //ProcessRequirements();
        }
        protected override void ProcessRequirements()
        {
            throw new NotImplementedException();
        }
    }
}