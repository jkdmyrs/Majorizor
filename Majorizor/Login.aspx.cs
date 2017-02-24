using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Majorizor.Resources;
using Majorizor.Resources.Security;

namespace Majorizor
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button_login_Click(object sender, EventArgs e)
        {
            UserLogin(username_input.Value, password_input.Value);
        }
        
        private void UserLogin(string email, string password)
        {
            userGroup userGroup = userGroup.DEFUALT;
            string userName = null;

            //Login DataAccess Call
            Resources.DataAccess.AccountControls.Login(email, password, out userGroup, out userName);
            
            //If Login was successful, build global application state hashtable
            if (userName != null && userGroup != userGroup.DEFUALT)
            {
                //build Global Application State hashtable
                Hashtable htblCurrentUser = null;
                if (Application["CurrentUser"] != null)
                {
                    htblCurrentUser = (Hashtable)Application["CurrentUser"];
                }
                else
                {
                    htblCurrentUser = new Hashtable();
                }

                htblCurrentUser.Add("userName", userName);
                htblCurrentUser.Add("userGroup", userGroup);

                this.Application["CurrentUser"] = htblCurrentUser;

                Response.Redirect("/Default.aspx");
            }
            //If login was not successful, inform the user
            //TODO - Make this better xD
            else
                Response.Write("Login failed");
        }

        protected void button_register_Click(object sender, EventArgs e)
        {
            string firstName = firstname_input.Value.ToString();
            string lastName = lastname_input.Value.ToString();
            string email = email_input.Value.ToString();
            string password = passwordRegister_input.Value.ToString();
            string verifyPassword = passwordVerify_input.Value.ToString();

            if (password == verifyPassword)
            {
                //salt and hash password, then store user information & Login
                string hashedPass;
                string salt;

                salt = Security.generateSalt(10);
                hashedPass = Security.generateHash(password, salt);

                Resources.DataAccess.AccountControls.RegisterUser(firstName, lastName, email, hashedPass, salt);
                UserLogin(email, password);
            }
            else
            {
                Response.Write("Register Failed.");
            }
        }
    }
}