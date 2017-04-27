using System;
using Majorizor.Resources.DataAccess;
using Majorizor.Resources.Majors;
using Majorizor.Resources.Minors;

namespace Majorizor.Resources
{
    public class MajorMinorManager
    {
        public Student student { get; private set; }

        /// <summary>
        /// 1 - if major1 is available
        /// 2 - if major2 is available
        ///-1 - if no major available
        /// </summary>
        public int availableMajor { get; private set; }

        /// <summary>
        /// 1 - if minor1 is available
        /// 2 - if minor2 is available
        ///-1 - if no minor available
        /// </summary>
        public int availableMinor { get; private set; }

        #region Constructor

        /// <summary>
        /// Constructor (studentID) - Initialize the Student member variable
        /// </summary>
        /// <param name="studentID">userID of the student you would like to initialize</param>
        public MajorMinorManager(Student _student)
        {
            student = _student;
            availableMajor = isMajorAvailable();
            availableMinor = isMinorAvailable();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Gets whether or not there is an available major spot for the student
        /// Majorizor allows 2 spots
        /// </summary>
        /// <returns>True if avialable spot, else false</returns>
        public bool MajorAvailable()
        {
            if (availableMajor == -1)
                return false;
            return true;
        }

        /// <summary>
        /// Gets whether or not there is an available minor spot for the student
        /// Majorizor allows 2 spots
        /// </summary>
        /// <returns>True if avialable spot, else false</returns>
        public bool MinorAvailable()
        {
            if (availableMinor == -1)
                return false;
            return true;
        }

        /// <summary>
        /// If an major spot is open, then set the major ONLY IF the new major is not the same as an existing major.
        /// 
        /// If the major cannot be set, an exception will be thrown (there is an exception for each case)
        /// </summary>
        /// <param name="type">Major type to be set</param>
        public void SetMajor(MajorType type)
        {
            switch (availableMajor)
            {
                case 1:
                    if (student.major2.majorType == type)
                    {
                        string error = "Cannot add a " + student.major2.majorName + " Major because " + student.getFullName() +" already has it selected as a major.";
                        throw new Exception(error);
                    }
                    else
                    {
                        MajorMinorSetter.setMajor1(type);
                        student.setMajor1(type);
                        // update availableMajor
                        isMajorAvailable();
                        break;
                    }
                case 2:
                    if (student.major1.majorType == type)
                    {
                        string error1 = "Cannot add a " + student.major1.majorName + " Major because " + student.getFullName() + " already has it selected as a major.";
                        throw new Exception(error1);
                    }
                    else
                    {
                        MajorMinorSetter.setMajor1(type);
                        student.setMajor1(type);
                        // update availableMajor
                        isMajorAvailable();
                        break;
                    }
                default:
                    string error2 = student.getFullName() + " already has two Majors. Before adding a new Major, an existing Major must be dropped.";
                    throw new Exception(error2);
            }
        }

        /// <summary>
        /// If a minor spot is open, then set the minor ONLY IF the new minor is not the same as an existing minor.
        /// 
        /// If the minor cannot be set, an exception will be thrown (there is an exception for each case)
        /// </summary>
        /// <param name="type">Major type to be set</param>
        public void SetMinor(MinorType type)
        {
            switch(availableMinor)
            {
                case 1:
                    if (student.minor2.minorType == type)
                    {
                        string error = "Cannot add a " + student.minor2.minorName + " Minor becuase " + student.getFullName() + " already has it selected as a minor.";
                        throw new Exception(error);
                    }
                    else
                    {
                        MajorMinorSetter.setMinor1(type);
                        student.setMinor1(type);
                        // update availableMinor
                        isMinorAvailable();
                        break;
                    }
                case 2:
                    if (student.minor1.minorType == type)
                    {
                        string error = "Cannot add a " + student.minor1.minorName + " Minor becuase " + student.getFullName() + " already has it selected as a minor.";
                        throw new Exception(error);
                    }
                    else
                    {
                        MajorMinorSetter.setMinor1(type);
                        student.setMinor1(type);
                        // update availableMinor
                        isMinorAvailable();
                        break;
                    }
                default:
                    string error2 = "You already have two Minors. Before adding a new Minor, you must drop an existing one.";
                    throw new Exception(error2);
            }
        }

        #region private
        /// <summary>
        /// PRIVATE
        /// Returns the first available majorSpot to set, if available
        /// else returns -1
        /// </summary>
        /// <returns>1 - if major1 is available
        ///          2 - if major2 is available
        ///         -1 - if no major available</returns>
        private int isMajorAvailable()
        {
            if (student.major1.majorType == MajorType.NONE)
                return 1;
            else if (student.major2.majorType == MajorType.NONE)
                return 2;
            return -1;
        }

        /// <summary>
        /// PRIVATE
        /// Returns the first available minorSpot to set, if available
        /// else returns -1
        /// </summary>
        /// <returns>1 - if minor1 is available
        ///          2 - if minor2 is available
        ///         -1 - if no minor available</returns>
        private int isMinorAvailable()
        {
            if (student.minor1.minorType == MinorType.NONE)
                return 1;
            else if (student.minor2.minorType == MinorType.NONE)
                return 2;
            return -1;
        }
        #endregion
        #endregion
    }
}