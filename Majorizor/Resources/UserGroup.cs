using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Majorizor.Resources.DataAccess;

namespace Majorizor.Resources
{
    public enum UserGroup { DEFUALT, USER, ADVISOR, ADMIN };

    public class UserGroups
    {
        //RETURNS:  true if user has access to check, false otherwise.
                
        //          A user has access if their UserGroup is above the check. (ie. ADMIN has access to USER and ADvISOR, USER only has access to USER)

        //INPUTS:   check - the UserGroup you are checking if they have access to
        //          userGroup - the current user's UserGroup
        public static Boolean userHasAccess(UserGroup check, UserGroup userGroup)
        {
            if (check == UserGroup.USER)
                return (userGroup == UserGroup.USER || userGroup == UserGroup.ADVISOR || userGroup == UserGroup.ADMIN);
            else if (check == UserGroup.ADVISOR)
                return (userGroup == UserGroup.ADVISOR || userGroup == UserGroup.ADMIN);
            else if (check == UserGroup.ADMIN)
                return (userGroup == UserGroup.ADMIN);
            else
                return false;
        }

        public static void UpdateUserGroup(int userID, UserGroup userGroup)
        {
            AccountController.UpdateUserGroup(userID, userGroup);
        }
    }
}