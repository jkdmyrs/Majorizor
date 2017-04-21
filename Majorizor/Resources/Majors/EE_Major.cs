using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Majorizor.Resources.Majors
{
    public class EE_Major : Major
    {
        public EE_Major()
        {
            majorType = MajorType.EE;
            majorName = "Electrical Engineering";
            reqCourses = DataAccess.MajorInformation.GetCoursesByMajor(majorType);
            //ProcessRequirements();
        }

        protected override void ProcessRequirements()
        {
            throw new NotImplementedException();
        }
    }
}