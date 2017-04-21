using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Majorizor.Resources.Minors
{
    public class _NULLMINOR : Minor
    {
        public _NULLMINOR()
        {
            minorType = MinorType.NONE;
        }

        protected override void ProcessRequirements()
        {
            throw new NotImplementedException();
        }
    }
}