using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Majorizor.Resources
{
    public class Time
    {
        public int Hours { get; private set; }
        public int Minutes { get; private set; }

        public Time(int h, int m)
        {
            if (h > 23 || m > 59)
            {
                throw new ArgumentException("Invalid time specified");
            }
            Hours = h;
            Minutes = m;
        }

        public override string ToString()
        {
            return String.Format(
                "{0:00}:{1:00}:",
                this.Hours, this.Minutes);
        }
    }
}