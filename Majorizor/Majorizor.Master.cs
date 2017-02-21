using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Majorizor
{
    public partial class Majorizor : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {/*
            Example of how to access this.Application

            
            string x, y;
            Hashtable hashUser = (Hashtable)this.Application["CurrentUser"];

            x = hashUser["userName"].ToString();
            y= hashUser["userGroup"].ToString();
            */

            Button loginNavbar = (Button)FindControl("loginNavbar");
            Button logoutNavbar = (Button)FindControl("logoutNavbar");

            if (Application["CurrentUser"] == null)
            {
                logoutNavbar.Visible = false;
                loginNavbar.Visible = true;
            }
            else
            {
                Hashtable userHash = (Hashtable)this.Application["CurrentUser"];
                logoutNavbar.Visible = true;
                loginNavbar.Visible = false;
            }
        }

        protected void loginNavbar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void LogoutNavBar_Click(object sender, EventArgs e)
        {
            this.Application["CurrentUser"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}