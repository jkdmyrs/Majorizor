using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Majorizor.Resources.Majors
{
    public enum MajorType { NONE, CE, CS, EE, MA, SE }

    public abstract class Major
    {
        public MajorType majorType { get; protected set; }
        public string majorName { get; protected set; }
        public List<Course> reqCourses { get; protected set; }
        public bool reqMet { get; protected set; }

        abstract protected void ProcessRequirements();
    }
}