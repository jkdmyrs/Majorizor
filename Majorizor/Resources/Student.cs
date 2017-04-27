using System.Collections.Generic;
using Majorizor.Resources.DataAccess;
using Majorizor.Resources.Majors;
using Majorizor.Resources.Minors;

namespace Majorizor.Resources {
    public enum StudentYear { Freshman, Sophomore, Junior, Senior };

    public class Student {
        #region Member Variables
        public int userID { get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public StudentYear year { get; private set; }
        public Major major1 { get; private set; }
        public Major major2 { get; private set; }
        public Minor minor1 { get; private set; }
        public Minor minor2 { get; private set; }
        public string graduation { get; private set; }
        public List<Course> coursesTaken { get; private set; }
        public List<Course> requiredCourses { get; private set; }
        #endregion
        #region Constructors
        /// <summary>
        /// Defualt Constructor
        /// </summary>
        public Student() { }

        /// <summary>
        /// Initializes a Student with information from the database for the specific userID
        /// </summary>
        /// <param name="userID">userID of the Student</param>
        public Student(int userID)
        {
            Student student = StudentInformation.getStudentByID(userID);
            setUserID(student.userID);
            setFirstName(student.firstName);
            setLastName(student.lastName);
            setStudentYear(student.year);
            setMajor1(student.major1.majorType);
            setMajor2(student.major2.majorType);
            setMinor1(student.minor1.minorType);
            setMinor2(student.minor2.minorType);
            setGraduation(student.graduation);
        }
        #endregion

        #region Setters
        // Setters
        //
        // set private member variables 
        //
        // used in DataAccess.StudentInformation class
        public void setUserID(int ID)
        {
            userID = ID;
        }

        public void setFirstName(string fN)
        {
            firstName = fN;
        }

        public void setLastName(string lN)
        {
            lastName = lN;
        }

        public void setStudentYear(StudentYear sY)
        {
            year = sY;
        }

        public void setMajor1(MajorType m)
        {
            switch (m)
            {
                case MajorType.CE:
                    major1 = new CE_Major();
                    break;
                case MajorType.CS:
                    major1 = new CS_Major();
                    break;
                case MajorType.EE:
                    major1 = new EE_Major();
                    break;
                case MajorType.MA:
                    major1 = new MA_Major();
                    break;
                case MajorType.SE:
                    major1 = new SE_Major();
                    break;
                default:
                    major1 = new _NULLMAJOR();
                    break;
            }
        }

        public void setMajor2(MajorType m)
        {
            switch (m)
            {
                case MajorType.CE:
                    major2 = new CE_Major();
                    break;
                case MajorType.CS:
                    major2 = new CS_Major();
                    break;
                case MajorType.EE:
                    major2 = new EE_Major();
                    break;
                case MajorType.MA:
                    major2 = new MA_Major();
                    break;
                case MajorType.SE:
                    major2 = new SE_Major();
                    break;
                default:
                    major2 = new _NULLMAJOR();
                    break;
            }
        }

        public void setMinor1(MinorType m)
        {
            switch (m)
            {
                case MinorType.CS:
                    minor1 = new CS_Minor();
                    break;
                case MinorType.EE:
                    minor1 = new EE_Minor();
                    break;
                case MinorType.MA:
                    minor1 = new MA_Minor();
                    break;
                case MinorType.SE:
                    minor1 = new SE_Minor();
                    break;
                case MinorType.NONE:
                    minor1 = new _NULLMINOR();
                    break;
            }
        }

        public void setMinor2(MinorType m)
        {
            switch (m)
            {
                case MinorType.CS:
                    minor2 = new CS_Minor();
                    break;
                case MinorType.EE:
                    minor2 = new EE_Minor();
                    break;
                case MinorType.MA:
                    minor2 = new MA_Minor();
                    break;
                case MinorType.SE:
                    minor2 = new SE_Minor();
                    break;
                case MinorType.NONE:
                    minor2 = new _NULLMINOR();
                    break;
            }
        }

        public void setGraduation(string g)
        {
            this.graduation = g;
        }

        // static methods
        public static Student GetStudentByID(int userID)
        {
            return StudentInformation.getStudentByID(userID);
        }
        #endregion

        #region Static Methods
        /// <summary>
        /// Gets a list of all Students
        /// </summary>
        /// <returns>A list of Student objects initialized for all Students in the system</returns>
        public static List<Student> GetAllStudents()
        {
            return StudentInformation.GetAllStudents();
        }

        /// <summary>
        /// Get students full name
        /// </summary>
        /// <returns>Full name as string</returns>
        public string getFullName()
        {
            return firstName + " " + lastName;
        }

        /// <summary>
        /// Get student's advisor's name
        /// </summary>
        /// <returns>Advisor Name, 
        ///          "" if no Advisor</returns>
        public string getAdvisorName()
        {
            return StudentInformation.GetAdvisorName(userID);
        }

        /// <summary>
        /// Get Major names as nicely formatted string
        /// </summary>
        /// <returns>If only 1 major, returns "majorname"
        ///          Otherwise returns "majorname1, majorname2"</returns>
        public string getMajors()
        {
            if (major1.majorType != MajorType.NONE && major2.majorType == MajorType.NONE)
                return major1.majorName;
            if (major1.majorType == MajorType.NONE && major2.majorType != MajorType.NONE)
                return major2.majorName;
            if (major1.majorType != MajorType.NONE && major2.majorType != MajorType.NONE)
                return major1.majorName + ", " + major2.majorName;
            return "N/A";
        }

        /// <summary>
        /// Get Minor names as nicely formatted string
        /// </summary>
        /// <returns>If only 1 minor, returns "minorname"
        ///          Otherwise returns "minorname1, minorname2"</returns>
        public string getMinors()
        {
            if (minor1.minorType != MinorType.NONE && minor2.minorType == MinorType.NONE)
                return minor1.minorName;
            if (minor1.minorType == MinorType.NONE && minor2.minorType != MinorType.NONE)
                return minor2.minorName;
            if (minor1.minorType != MinorType.NONE && minor2.minorType != MinorType.NONE)
                return minor1.minorName + ", " + minor2.minorName;
            return "N/A";
        }
        #endregion
    }

    public class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            // check whether the objects are the same object
            if (ReferenceEquals(x, y)) return true;

            // check whether the objects' userIDs are equal
            return x != null && y != null && x.userID.Equals(y.userID);
        }

        public int GetHashCode(Student obj)
        {
            // get hash for userID field
            return obj.userID.GetHashCode();
        }
    }
}