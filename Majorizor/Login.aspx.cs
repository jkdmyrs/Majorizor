using System;
using System.IO;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Majorizor.Resources;
using Majorizor.Resources.Security;

namespace Majorizor
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            username_input.Focus();
        }

        protected void button_login_Click(object sender, EventArgs e)
        {
            try
            {
                UserLogin(username_input.Value, password_input.Value);
            }
            catch (Exception ex)
            {
                ExceptionHandler handler = new ExceptionHandler(ex, error_box);
                handler.Handle();
            }
        }
        
        private void UserLogin(string email, string password)
        {
            User user = Resources.DataAccess.AccountController.Login(email, password);

            //If Login was successful, build global application state hashtable
            if (user.userGroup != UserGroup.NONE)
            {
                Session["UserName"] = email;
                Session["UserGroup"] = user.userGroup;
                Session["UserID"] = user.userID;

                switch (user.userGroup)
                {
                    case UserGroup.USER:
                        Response.Redirect("~/Screens/Students/StudentLanding.aspx", false);
                        break;
                    case UserGroup.ADVISOR:
                        Response.Redirect("~/Screens/Advisors/AdvisorLanding.aspx", false);
                        break;
                    case UserGroup.ADMIN:
                        Response.Redirect("~/Screens/Admins/AdminLanding.aspx", false);
                        break;
                }
            }
        }

        protected void button_register_Click(object sender, EventArgs e)
        {
            try
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
                else
                {
                    string error = "Passwords do not match. Please try again.";
                    throw new Exception(error);
                }
            }
            catch (Exception registerEx)
            {
                ExceptionHandler handler = new ExceptionHandler(registerEx, error_box);
                handler.Handle();
            }
        }
    }
}