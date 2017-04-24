using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Majorizor.Resources.DataAccess;

namespace Majorizor.Resources.Minors
{
    public class EE_Minor : Minor
    {
        public EE_Minor()
        {
            minorType = MinorType.EE;
            minorName = "Electrical Engineering";
            //reqCourses = MinorInformation.GetCoursesByMinor(minorType);
            //ProcessRequirements();
        }
        protected override void ProcessRequirements()
        {
            throw new NotImplementedException();
        }
    }
}