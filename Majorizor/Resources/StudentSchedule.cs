using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Majorizor.Resources
{
    public class StudentSchedule
    {
        public List<CourseName> requiredCourseNames { get; set; }
        public List<Course> courses { get; set; }

        public StudentSchedule() { }

        public StudentSchedule(Student student_) {
            List<CourseName> coursesToTake = student_.requiredCourses;
            List<CourseName> coursesTaken = student_.coursesTaken;


        }

    }
}