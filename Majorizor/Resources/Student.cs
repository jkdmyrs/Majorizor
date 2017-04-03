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

        public int userID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public StudentYear year { get; set; }
        public Major major1 { get; set; }
        public Major major2 { get; set; }
        public Minor minor1 { get; set; }
        public Minor minor2 { get; set; }
        public string graduation { get; set; }

        public Student() { }

        public Student(int ID)
        {
            Student student = GetStudentByID(ID);
            this.userID = student.userID;
            this.firstName = student.firstName;
            this.lastName = student.lastName;
            this.year = student.year;
            this.major1 = student.major1;
            this.major2 = student.major2;
            this.minor1 = student.minor1;
            this.minor2 = student.minor2;
            this.graduation = student.graduation;
        }

        private static Student GetStudentByID(int userID)
        {
            return StudentInformation.getStudentByID(userID);
        }
    }
}