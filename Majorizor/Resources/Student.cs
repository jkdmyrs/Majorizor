using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Majorizor.Resources.DataAccess;

namespace Majorizor.Resources
{

    public enum StudentYear { FRESHMAN, SOPHOMORE, JUNIOR, SENIOR };
    public enum Major { NONE, CE, CS, EE, MA, SE };
    public enum Minor { NONE, CS, EE, MA, SE };

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
            setUserID(ID);
            setFirstName(student.firstName);
            setLastName(student.lastName);
            setStudentYear(student.year);
            setMajor1(student.major1);
            setMajor2(student.major2);
            setMinor1(student.minor1);
            setMinor2(student.minor2);
            setGraduation(student.graduation);
        }

        private static Student GetStudentByID(int userID)
        {
            return StudentInformation.getStudentByID(userID);
        }

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

        public void setMajor1(Major m)
        {
            this.major1 = m;
        }

        public void setMajor2(Major m)
        {
            this.major2 = m;
        }

        public void setMinor1(Minor m)
        {
            this.minor1 = m;
        }

        public void setMinor2(Minor m)
        {
            this.minor2 = m;
        }

        public void setGraduation(string g)
        {
            this.graduation = g;
        }
    }
}