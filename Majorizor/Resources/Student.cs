using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Majorizor.Resources
{
    public class Student
    {
        public enum StudentYear { FRESHMAN, SOPHOMORE, JUNIOR, SENIOR };
        public enum Major { NONE, CE, CS, EE, MA, SE };
        public enum Minor { NONE, CS, EE, MA, SE };
            public int userID;
            public string firstName;
            public string lastName;
            public StudentYear year;
            public Major major1;
            public Major major2;
            public Minor minor1;
            public Minor minor2;
            public int graduation;
        }
}