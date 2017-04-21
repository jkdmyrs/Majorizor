using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Majorizor.Resources.DataAccess;
using Majorizor.Resources.Majors;
using Majorizor.Resources.Minors;

namespace Majorizor.Resources
{

    public enum StudentYear { FRESHMAN, SOPHOMORE, JUNIOR, SENIOR };

    public class Student
    {

        public int userID { get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public StudentYear year { get; private set; }
        public Major major1 { get; private set; }
        public Major major2 { get; private set; }
        public Minor minor1 { get; private set; }
        public Minor minor2 { get; private set; }
        public string graduation { get; private set; }

        public Student() { }

        public Student(int ID)
        {
            Student student = GetStudentByID(ID);
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

        // == Operator


        //Setters
        public void setUserID(int ID)
        {
            this.userID = ID;
        }

        public void setFirstName(string fN)
        {
            this.firstName = fN;
        }

        public void setLastName(string lN)
        {
            this.lastName = lN;
        }

        public void setStudentYear(StudentYear sY)
        {
            this.year = sY;
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
        private static Student GetStudentByID(int userID)
        {
            return StudentInformation.getStudentByID(userID);
        }

        public static List<Student> GetAllStudents()
        {
            return StudentInformation.GetAllStudents();
        }
    }

    public class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            // check whether the objects are the same object
            if (Object.ReferenceEquals(x, y)) return true;

            // check wheather the objects' userIDs are equal
            return x != null && y != null && x.userID.Equals(y.userID);
        }

        public int GetHashCode(Student obj)
        {
            // get has for userID feild
            return obj.userID.GetHashCode();
        }
    }
}