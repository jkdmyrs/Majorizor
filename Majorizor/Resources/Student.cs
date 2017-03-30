﻿using System;
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

        public int userID;
        public string firstName;
        public string lastName;
        public StudentYear year;
        public Major major1;
        public Major major2;
        public Minor minor1;
        public Minor minor2;
        public string graduation;

        public static Student GetStudentByID(int userID)
        {
            return StudentInformation.getStudentByID(userID);
        }
    }
}