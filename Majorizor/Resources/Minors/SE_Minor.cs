using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Majorizor.Resources.DataAccess;

namespace Majorizor.Resources.Minors
{
    public class SE_Minor : Minor
    {
        public SE_Minor()
        {
            minorType = MinorType.SE;
            minorName = "Software Engineering";
            reqCourses = MinorInformation.GetRequiredCourses(minorType);
            //ProcessRequirements();
        }

        protected override void ProcessRequirements()
        {
            throw new NotImplementedException();
        }
    }
}