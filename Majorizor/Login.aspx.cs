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
            UserGroup userGroup = Resources.DataAccess.AccountController.Login(email, password);
            
            //If Login was successful, build global application state hashtable
            if (userGroup != UserGroup.DEFUALT)
            {
                Session["UserName"] = email;
                Session["UserGroup"] = userGroup;

                switch(userGroup)
                {
                    case UserGroup.USER:
                        Response.Redirect("~/Screens/Students/StudentLanding.aspx");
                        break;
                    case UserGroup.ADVISOR:
                        Response.Redirect("~/Screens/Advisors/AdvisorLanding.aspx");
                        break;
                    case UserGroup.ADMIN:
                        Response.Redirect("~/Screens/Admins/AdminLanding.aspx");
                        break;
                }
            }
            //If login was not successful, inform the user
            //TODO - Make this better 
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

                Resources.DataAccess.AccountController.RegisterUser(firstName, lastName, email, hashedPass, salt);
                UserLogin(email, password);
            }
            //If register was not successful, inform the user
            //TODO - Make this better 
            else
                Response.Write("Register Failed.");
        }
    }
}