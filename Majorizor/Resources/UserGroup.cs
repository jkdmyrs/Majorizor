using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Majorizor.Resources.DataAccess;

namespace Majorizor.Resources
{
    public enum UserGroup { NONE, USER, ADVISOR, ADMIN };       // NONE - No user logged in

    public class UserGroups
    {
        /// <summary>
        /// Checks if the given user has access to the given userGroup
        /// </summary>
        /// <param name="check">the UserGroup you are checking if they have access to</param>
        /// <param name="user">the user you would like to check</param>
        /// <returns>true if user has access, otherwise false</returns>
        public static bool userHasAccess(UserGroup check, User user)
        {
            if (check == UserGroup.USER)
                return (user.userGroup == UserGroup.USER || user.userGroup == UserGroup.ADVISOR || user.userGroup == UserGroup.ADMIN);
            else if (check == UserGroup.ADVISOR)
                return (user.userGroup == UserGroup.ADVISOR || user.userGroup == UserGroup.ADMIN);
            else if (check == UserGroup.ADMIN)
                return (user.userGroup == UserGroup.ADMIN);
            else
                return false;
        }
    }
}