using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Majorizor.Resources.DataAccess;
using Majorizor.Resources.Majors;

namespace Majorizor.Resources
{

    public enum StudentYear { FRESHMAN, SOPHOMORE, JUNIOR, SENIOR };
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
            setUserID(student.userID);
            setFirstName(student.firstName);
            setLastName(student.lastName);
            setStudentYear(student.year);
            setMajor1(student.major1.majorType);
            setMajor2(student.major2.majorType);
            setMinor1(student.minor1);
            setMinor2(student.minor2);
            setGraduation(student.graduation);
        }

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
            if (m != MajorType.NONE)
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
                }
            }
            else
            {
                string error = "Student.setMajor1 failed - Invalid MajorType";
                throw new Exception(error);
            }
        }

        public void setMajor2(MajorType m)
        {
            if (m != MajorType.NONE)
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
                }
            }
            else
            {
                string error = "Student.setMajor2 failed - Invalid MajorType";
                throw new Exception(error);
            }
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
}