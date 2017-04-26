using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Majorizor.Resources.Majors
{
    public class CE_Major : Major
    {
        public CE_Major()
        {
            majorType = MajorType.CE;
            majorName = "Computer Engineering";
            reqCourses = DataAccess.MajorInformation.GetRequiredCourses(majorType);
            //ProcessRequirements();
        }

        protected override void ProcessRequirements()
        {
            throw new NotImplementedException();
        }
        
    }
}