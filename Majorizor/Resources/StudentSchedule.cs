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

            List<Course> availableCourses = Course.GetAllRequiredCourses();

            // Classes in which the student is enrolled (first 5 classes of coursesToTake)
            courses.Add(coursesToTake[0]);
            courses.Add(coursesToTake[1]);
            courses.Add(coursesToTake[2]);
            courses.Add(coursesToTake[3]);
            courses.Add(coursesToTake[4]);
            
            List<Course> course1sec = new List<Course>();
            List<Course> course2sec = new List<Course>();
            List<Course> course3sec = new List<Course>();
            List<Course> course4sec = new List<Course>();
            List<Course> course5sec = new List<Course>();

            for (int i = 0; i < availableCourses.Count; ++i) {
                if (availableCourses[i].name.Equals(courses[0].name, StringComparison.Ordinal))
                {
                    course1sec.Add(availableCourses[i]);
                }
                else if (availableCourses[i].name.Equals(courses[1].name, StringComparison.Ordinal))
                {
                    course2sec.Add(availableCourses[i]);
                }
                else if (availableCourses[i].name.Equals(courses[2].name, StringComparison.Ordinal))
                {
                    course3sec.Add(availableCourses[i]);
                }
                else if (availableCourses[i].name.Equals(courses[3].name, StringComparison.Ordinal))
                {
                    course4sec.Add(availableCourses[i]);
                }
                else if (availableCourses[i].name.Equals(courses[4].name, StringComparison.Ordinal)) {
                    course5sec.Add(availableCourses[i]);
                }
            }

            for (int a = 0; a < course1sec.Count; ++a) {
                for (int b = 0; b < course2sec.Count; ++b) {
                    for (int c = 0; c < course3sec.Count; ++c) {
                        for (int d = 0; d < course4sec.Count; ++d) {
                            for (int e = 0; e < course4sec.Count; ++d) {
                                if (Course.noConflicts(course1sec[a], course2sec[b], course3sec[c], course4sec[d], course5sec[e])) {
                                    courses = new List<Course>();
                                    courses.Add(course1sec[a]);
                                    courses.Add(course2sec[b]);
                                    courses.Add(course3sec[c]);
                                    courses.Add(course4sec[d]);
                                    courses.Add(course5sec[e]);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            
        }

    }
}