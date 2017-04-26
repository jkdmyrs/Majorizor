using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Majorizor.Resources
{
    public class CourseName
    {
        public string subject { get; private set; }
        public string catalog { get; private set; }

        public CourseName() { }

        public CourseName(string _subject, string _catalog)
        {
            this.subject = _subject;
            this.catalog = _catalog;
        }

        public static bool operator ==(CourseName thisCourse, Course compareCourse) {
            if (thisCourse.subject.Equals(compareCourse.subject))
                return true;
            return false;
            }

        public static bool operator !=(CourseName thisCourse, Course compareCourse) {
            if (thisCourse.subject.Equals(compareCourse.subject))
                return false;
            return true;
        }



    }
}