using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Majorizor.Resources.DataAccess;

namespace Majorizor.Resources
{
    public class User
    {
        #region Member Variables
        public int userID { get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public string email { get; private set; }
        public UserGroup userGroup { get; private set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a User with userGroup = NONE
        /// </summary>
        public User()
        {
            userGroup = UserGroup.NONE;
        }

        /// <summary>
        /// Initializes a User with information from the database for the specific userID
        /// </summary>
        /// <param name="_userID">userID of the User to initialize</param>
        public User(int _userID)
        {
            User _user = UserInformation.GetUserByID(_userID);
            userID = _user.userID;
            firstName = _user.firstName;
            lastName = _user.lastName;
            email = _user.email;
            userGroup = _user.userGroup;
        }
        #endregion

        #region Setters
        // Setters
        //
        // set private member variables 
        //
        // used in DataAccess.UserInformation class
        public void setUserID(int _userID)
        {
            userID = _userID;
        }

        public void setFirstName(string _firstName)
        {
            firstName = _firstName;
        }

        public void setLastName(string _lastName)
        {
            lastName = _lastName;
        }

        public void setEmail(string _email)
        {
            email = _email;
        }

        public void setUserGroup(UserGroup _userGroup)
        {
            userGroup = _userGroup;
        }
        #endregion

        #region Static Methods
        /// <summary>
        /// Get a list of all Users registered in the system
        /// </summary>
        /// <returns>A list of User objects initialized for all Users in the system</returns>
        public static List<User> GetAllUsers()
        {
            return UserInformation.GetAllUsers();
        }
        
        /// <summary>
        /// Updates the UserGroup to the given userGroup for the User with the given userID
        /// </summary>
        /// <param name="userID">userID of the user to update</param>
        /// <param name="userGroup">new userGroup</param>
        public static void UpdateUserGroup(int userID, UserGroup userGroup)
        {
            UserInformation.UpdateUserGroup(userID, userGroup);
        }
        
        /// <summary>
        /// Deletes the User with the given userID from the system
        /// </summary>
        /// <param name="userID"></param>
        public static void DeleteUser(int userID)
        {
            UserInformation.DeleteUser(userID);
        }
        #endregion
    }
}