using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Majorizor.Resources.DataAccess;

namespace Majorizor.Resources.Minors
{
    public class MA_Minor : Minor
    {
        public MA_Minor()
        {
            minorType = MinorType.MA;
            minorName = "Math";
            reqCourses = MinorInformation.GetCoursesByMinor(minorType);
            //ProcessRequirements();
        }
        protected override void ProcessRequirements()
        {
            throw new NotImplementedException();
        }
    }
}