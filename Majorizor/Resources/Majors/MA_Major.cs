using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Majorizor.Resources.Majors
{
    public class MA_Major : Major
    {
        public MA_Major()
        {
            majorType = MajorType.MA;
            majorName = "Math";
            reqCourses = DataAccess.MajorInformation.GetCoursesByMajor(majorType);
            //ProcessRequirements();
        }

        protected override void ProcessRequirements()
        {
            throw new NotImplementedException();
        }
    }
}