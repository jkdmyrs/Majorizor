using System;
using System.Collections.Generic;
using Majorizor.Resources.Majors;

namespace Majorizor.Resources.DataAccess
{
    public class MajorInformation
    {
        public static List<CourseName> GetCoursesByMajor(MajorType type)
        {
            List<CourseName> majorCourses = new List<CourseName>();
            switch (type)
            {
                case MajorType.CE:
                    // Add each required course to list
                    majorCourses.Add(new CourseName("CM", "131"));
                    majorCourses.Add(new CourseName("CM", "132"));
                    majorCourses.Add(new CourseName("PH", "131"));
                    majorCourses.Add(new CourseName("PH", "132"));
                    majorCourses.Add(new CourseName("EE", "221"));
                    majorCourses.Add(new CourseName("EE", "261"));
                    majorCourses.Add(new CourseName("EE", "316"));
                    majorCourses.Add(new CourseName("EE", "321"));
                    majorCourses.Add(new CourseName("EE", "341"));
                    majorCourses.Add(new CourseName("EE", "360"));
                    majorCourses.Add(new CourseName("EE", "361"));
                    majorCourses.Add(new CourseName("EE", "363"));
                    majorCourses.Add(new CourseName("EE", "365"));
                    majorCourses.Add(new CourseName("EE", "416"));
                    majorCourses.Add(new CourseName("EE", "462"));
                    majorCourses.Add(new CourseName("EE", "464"));
                    majorCourses.Add(new CourseName("EE", "466"));
                    majorCourses.Add(new CourseName("ES", "100"));
                    majorCourses.Add(new CourseName("ES", "110"));
                    majorCourses.Add(new CourseName("ES", "250"));
                    majorCourses.Add(new CourseName("FY", "100"));
                    majorCourses.Add(new CourseName("MA", "131"));
                    majorCourses.Add(new CourseName("MA", "132"));
                    majorCourses.Add(new CourseName("MA", "211"));
                    majorCourses.Add(new CourseName("MA", "231"));
                    majorCourses.Add(new CourseName("MA", "232"));
                    majorCourses.Add(new CourseName("STAT", "383"));
                    majorCourses.Add(new CourseName("UNIV", "190"));
                    return majorCourses;
                case MajorType.SE:
                    // Add each required course to list
                    majorCourses.Add(new CourseName("CM", "131"));
                    majorCourses.Add(new CourseName("CM", "132"));
                    majorCourses.Add(new CourseName("CS", "341"));
                    majorCourses.Add(new CourseName("CS", "344"));
                    majorCourses.Add(new CourseName("CS", "444"));
                    majorCourses.Add(new CourseName("CS", "458"));
                    majorCourses.Add(new CourseName("EE", "221"));
                    majorCourses.Add(new CourseName("EE", "264"));
                    majorCourses.Add(new CourseName("EE", "360"));
                    majorCourses.Add(new CourseName("EE", "361"));
                    majorCourses.Add(new CourseName("EE", "363"));
                    majorCourses.Add(new CourseName("EE", "368"));
                    majorCourses.Add(new CourseName("EE", "407"));
                    majorCourses.Add(new CourseName("EE", "408"));
                    majorCourses.Add(new CourseName("EE", "418"));
                    majorCourses.Add(new CourseName("EE", "462"));
                    majorCourses.Add(new CourseName("EE", "466"));
                    majorCourses.Add(new CourseName("EE", "468"));
                    majorCourses.Add(new CourseName("ES", "100"));
                    majorCourses.Add(new CourseName("ES", "110"));
                    majorCourses.Add(new CourseName("ES", "250"));
                    majorCourses.Add(new CourseName("FY", "100"));
                    majorCourses.Add(new CourseName("MA", "131"));
                    majorCourses.Add(new CourseName("MA", "132"));
                    majorCourses.Add(new CourseName("MA", "211"));
                    majorCourses.Add(new CourseName("MA", "231"));
                    majorCourses.Add(new CourseName("MA", "232"));
                    majorCourses.Add(new CourseName("PH", "131"));
                    majorCourses.Add(new CourseName("PH", "132"));
                    majorCourses.Add(new CourseName("UNIV", "190"));
                    return majorCourses;
                case MajorType.EE:
                    // Add each required course to list
                    majorCourses.Add(new CourseName("CM", "131"));
                    majorCourses.Add(new CourseName("CM", "132"));
                    majorCourses.Add(new CourseName("EE", "211"));
                    majorCourses.Add(new CourseName("EE", "221"));
                    majorCourses.Add(new CourseName("EE", "261"));
                    majorCourses.Add(new CourseName("EE", "264"));
                    majorCourses.Add(new CourseName("EE", "311"));
                    majorCourses.Add(new CourseName("EE", "321"));
                    majorCourses.Add(new CourseName("EE", "324"));
                    majorCourses.Add(new CourseName("EE", "331"));
                    majorCourses.Add(new CourseName("EE", "341"));
                    majorCourses.Add(new CourseName("EE", "381"));
                    majorCourses.Add(new CourseName("EE", "412"));
                    majorCourses.Add(new CourseName("ES", "100"));
                    majorCourses.Add(new CourseName("ES", "110"));
                    majorCourses.Add(new CourseName("ES", "250"));
                    majorCourses.Add(new CourseName("FY", "100"));
                    majorCourses.Add(new CourseName("MA", "131"));
                    majorCourses.Add(new CourseName("MA", "132"));
                    majorCourses.Add(new CourseName("MA", "231"));
                    majorCourses.Add(new CourseName("MA", "232"));
                    majorCourses.Add(new CourseName("PH", "131"));
                    majorCourses.Add(new CourseName("PH", "132"));
                    majorCourses.Add(new CourseName("STAT", "383"));
                    majorCourses.Add(new CourseName("UNIV", "190"));
                    break;
                case MajorType.CS:
                    // Add each required course to list
                    majorCourses.Add(new CourseName("MA", "131"));
                    majorCourses.Add(new CourseName("MA", "132"));
                    majorCourses.Add(new CourseName("MA", "211"));
                    majorCourses.Add(new CourseName("CS", "141"));
                    majorCourses.Add(new CourseName("CS", "142"));
                    majorCourses.Add(new CourseName("CS", "241"));
                    majorCourses.Add(new CourseName("CS", "242"));
                    majorCourses.Add(new CourseName("CS", "341"));
                    majorCourses.Add(new CourseName("CS", "344"));
                    majorCourses.Add(new CourseName("CS", "345"));
                    majorCourses.Add(new CourseName("CS", "350"));
                    majorCourses.Add(new CourseName("CS", "444"));
                    majorCourses.Add(new CourseName("FY", "100"));
                    majorCourses.Add(new CourseName("UNIV", "190"));
                    return majorCourses;
                case MajorType.MA:
                    // Add each required course to list
                    majorCourses.Add(new CourseName("CS", "141"));
                    majorCourses.Add(new CourseName("CS", "142"));
                    majorCourses.Add(new CourseName("FY", "100"));
                    majorCourses.Add(new CourseName("MA", "131"));
                    majorCourses.Add(new CourseName("MA", "132"));
                    majorCourses.Add(new CourseName("MA", "200"));
                    majorCourses.Add(new CourseName("MA", "211"));
                    majorCourses.Add(new CourseName("MA", "231"));
                    majorCourses.Add(new CourseName("MA", "232"));
                    majorCourses.Add(new CourseName("MA", "311"));
                    majorCourses.Add(new CourseName("MA", "321"));
                    majorCourses.Add(new CourseName("MA", "322"));
                    majorCourses.Add(new CourseName("MA", "339"));
                    majorCourses.Add(new CourseName("PH", "131"));
                    majorCourses.Add(new CourseName("PH", "132"));
                    majorCourses.Add(new CourseName("STAT", "383"));
                    majorCourses.Add(new CourseName("UNIV", "190"));
                    return majorCourses;
                default:
                    break;
            }
            return majorCourses;
            
        }
    }
}