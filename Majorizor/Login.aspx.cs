using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Majorizor.Resources;

namespace Majorizor
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button_register_click (object sender, EventArgs e)
        {
            //New user code
        }

        protected void button_login_Click(object sender, EventArgs e)
        {
            string userName = null;
            userGroup userGroup = userGroup.USER;

            /*
            TODO 
            Data Layer Login 
            inputs: string userNameTextBox.Value, string userGroupTextBox.Value
            outputs: string userName, UserGroup.userGroup userGroup
             */


            //build Global Application State object
            Hashtable htblCurrentUser = null;
            if (Application["CurrentUser"] != null)
            {
                htblCurrentUser = (Hashtable)Application["CurrentUser"];
            }
            else
            {
                htblCurrentUser = new Hashtable();
            }

            htblCurrentUser.Add("userName", userName.ToString());
            htblCurrentUser.Add("userGroup", userGroup);

            this.Application["CurrentUser"] = htblCurrentUser;

            //Redirect to landing page based on user


            /*
            Example of how to access this.Application

            
            string x, y;
            Hashtable hashUser = (Hashtable)this.Application["CurrentUser"];

            x = hashUser["userName"].ToString();
            y= hashUser["userGroup"].ToString();
            */

        }
    }
}