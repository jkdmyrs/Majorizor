using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Majorizor.Resources
{
    public class StudentSchedule
    {
        public List<Course> requiredCourseNames { get; set; }
        public List<Course> courses { get; set; }

        public StudentSchedule() { }

        public StudentSchedule(Student student_) {
            List<Course> coursesToTake = student_.requiredCourses;
            List<Course> coursesTaken = student_.coursesTaken;

            int lengthCTT = coursesToTake.Count;
            int lengthCT = coursesTaken.Count;

            // Remove courses already taken from consideration
            for (int i = 0; i < lengthCTT; ++i) {
                for (int j = 0; j < lengthCT; ++j) {
                    if (coursesToTake[i] == coursesTaken[j]) {
                        coursesToTake.RemoveAt(i);
                        --lengthCTT;
                    }
                }
            }


            
        }

    }
}