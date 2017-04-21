using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Majorizor.Resources.Minors
{
    public enum MinorType { NONE, CS, EE, MA, SE };
    public abstract class Minor
    {
        public MinorType minorType { get; protected set; }
        public string minorName { get; protected set; }
        public List<Course> reqCourses { get; protected set; }
        public bool req_met { get; protected set; }

        abstract protected void ProcessRequirements();
    }
}