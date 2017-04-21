using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Majorizor.Resources.Majors
{
    public class SE_Major : Major
    {
        public bool extraReq1 { get; protected set; }   // EE261 or CS141
        public bool extraReq2 { get; protected set; }   // EE221 or ES Elective
        public bool extraReq3 { get; protected set; }   // MA383 or MA381
        public bool EC_Req { get; protected set; }      // EC requirement
        public bool pro_Req { get; protected set; }     // Professional Electives

        public SE_Major()
        {
            majorType = MajorType.SE;
            majorName = "Software Engineering";
            reqCourses = DataAccess.MajorInformation.GetCoursesByMajor(majorType);
            //ProcessRequirements();
        }

        protected override void ProcessRequirements()
        {
            throw new NotImplementedException();
        }
    }
}