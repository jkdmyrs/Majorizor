using System;
using System.Collections.Generic;
using System.Data;
using Majorizor.Resources.DataAccess;


namespace Majorizor.Resources
{
    public class Course
    {
        #region Member Variables
        public int id { get; private set; }
        public string subject { get; private set; }
        public string catalog { get; private set; }
        public string section { get; private set; }
        public string name { get; private set; }
        public DateTime startTime { get; private set; }
        public DateTime endTime { get; private set; }
        public string days { get; private set; }
        #endregion

        #region Constructors
        // Default constructor
        public Course() { }

        /// <summary>
        /// Constructor used to pass a DataRow with "subject", "catalog", and "name" fields
        /// </summary>
        /// <param name="dr">DataRow with "subject", "catalog", and "name"</param>
        public Course(string _subject, string _catalog, string _name)
        {
            subject = _subject;
            catalog = _catalog;
            name = _name;
            id = -1;
        }

        /// <summary>
        /// Initializes a Course object with the given values
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="_subject"></param>
        /// <param name="_catalog"></param>
        /// <param name="_section"></param>
        /// <param name="_name"></param>
        /// <param name="_start"></param>
        /// <param name="_end"></param>
        /// <param name="_days"></param>
        public Course(int _ID, string _subject, string _catalog, string _section, string _name, DateTime _start, DateTime _end, string _days)
        {
            id = _ID;
            subject = _subject;
            catalog = _catalog;
            section = _section;
            name = _name;
            startTime = _start;
            endTime = _end;
            days = _days;
        }
        #endregion

        #region Setters

        public void setID(int _id)
        {
            id = _id;
        }

        public void setSubject(string _subject)
        {
            subject = _subject;
        }

        public void setCatalog(string _catalog)
        {
            catalog = _catalog;
        }

        public void setSection(string _section)
        {
            section = _section;
        }

        public void setName(string _name)
        {
            name = _name;
        }

        public void setStartTime(DateTime _startTime)
        {
            startTime = _startTime;
        }

        public void setEndTime(DateTime _endTime)
        {
            endTime = _endTime;
        }

        public void setDays(string _days)
        {
            _days = days;
        }

        #endregion

        #region Static Methods

        public static List<Course> GetAllRequiredCourses()
        {
            return CourseInformation.GetAllRequiredCourses();
        }

        public static String toString(Course c) {
            String courseStr = c.subject + c.catalog + " " + c.name + "  " + c.days + " " + c.startTime.ToShortTimeString() + " - " c.endTime.ToShortTimeString();
            return courseStr;
        }

        public static bool noConflicts(Course a, Course b, Course c, Course d, Course e) {
            List<Course> courses = new List<Course>();
            courses.Add(a);
            courses.Add(b);
            courses.Add(c);
            courses.Add(d);
            courses.Add(e);

            for (int i = 0; i < courses.Count - 1; ++i) {
                for (int j = i+1; j < courses.Count; ++j) {
                    // If the two courses are on the same days and there is a time conflict
                    if (courses[i].days.Equals(courses[j].days,StringComparison.Ordinal) &&
                        (courses[i].startTime.CompareTo(courses[j].startTime) < 0 && 
                            courses[i].endTime.CompareTo(courses[j].startTime) > 0 ) ||
                        (courses[j].startTime.CompareTo(courses[i].startTime) < 0 && 
                            courses[j].endTime.CompareTo(courses[i].startTime) > 0 )) {
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion
    }

    #region IEqualityComparer
    /// <summary>
    /// Uses the IEqualityComparer interface to allow List.Except functionality
    /// </summary>
    public class CourseComparer : IEqualityComparer<Course>
    {
        public bool Equals(Course x, Course y)
        {
            // check whether the objects are the same
            if (ReferenceEquals(x, y)) return true;
            
            // check if they are both is a partial course object
            if(x.id == -1 && y.id == -1)
            {
                return x.catalog.Equals(y.catalog) && x.subject.Equals(y.subject);
            }
            else
                // check whether the objects' IDs are equal
                return x != null && y != null && x.id.Equals(y.id);
        }

        public int GetHashCode(Course obj)
        {
            // get hash for id field
            return obj.id.GetHashCode();
        }
    }
    #endregion
}
