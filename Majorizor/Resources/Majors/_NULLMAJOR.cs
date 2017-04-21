using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Majorizor.Resources.Majors
{
    public class _NULLMAJOR : Major
    {

        public _NULLMAJOR()
        {
            majorType = MajorType.NONE;
        }

        protected override void ProcessRequirements()
        {
            throw new NotImplementedException();
        }
    }
}