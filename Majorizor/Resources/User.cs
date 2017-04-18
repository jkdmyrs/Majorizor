using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Majorizor.Resources.DataAccess;

namespace Majorizor.Resources
{
    public class User
    {
        public int userID { get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public string email { get; private set; }
        public UserGroup userGroup { get; private set; }

        public User()
        {
            userID = -1;
            firstName = "";
            lastName = "";
            email = "";
            userGroup = UserGroup.DEFUALT;
        }

        public User(int _userID)
        {
            User _user = UserInformation.GetUserByID(_userID);
            userID = _user.userID;
            firstName = _user.firstName;
            lastName = _user.lastName;
            email = _user.email;
            userGroup = _user.userGroup;
        }

        public static List<User> GetAllUsers()
        {
            return UserInformation.GetAllUsers();
        }

        public void setUserID(int _userID)
        {
            this.userID = _userID;
        }

        public void setFirstName(string _firstName)
        {
            this.firstName = _firstName;
        }

        public void setLastName(string _lastName)
        {
            this.lastName = _lastName;
        }

        public void setEmail(string _email)
        {
            this.email = _email;
        }

        public void setUserGroup(UserGroup _userGroup)
        {
            this.userGroup = _userGroup;
        }
    }
}