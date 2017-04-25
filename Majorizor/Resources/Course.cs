using System;
using System.Collections.Generic;

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
    }

    /// <summary>
    /// Uses the IEqualityComparer interface to allow List.Except functionality
    /// </summary>
    public class CourseComparer : IEqualityComparer<Course>
    {
        public bool Equals(Course x, Course y)
        {
            // check whether the objects are the same
            if (ReferenceEquals(x, y)) return true;

            // check whether the objects' IDs are equal
            return x != null && y != null && x.id.Equals(y.id);
        }

        public int GetHashCode(Course obj)
        {
            // get hash for id field
            return obj.id.GetHashCode();
        }
    }
}
