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
            majorType = MajorType.EE;
            majorName = "Computer Science";
            //reqCourses = DataAccess.MajorInformation.GetCoursesByMajor(majorType);
           //ProcessRequirements();
        }

        protected override void ProcessRequirements()
        {
            throw new NotImplementedException();
        }
    }
}