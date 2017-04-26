using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Majorizor.Resources.Majors
{
    public class CS_Major : Major
    {
        public CS_Major()
        {
            majorType = MajorType.CS;
            majorName = "Computer Science";
            reqCourses = DataAccess.MajorInformation.GetRequiredCourses(majorType);
           //ProcessRequirements();
        }

        protected override void ProcessRequirements()
        {
            throw new NotImplementedException();
        }
    }
}