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
    public partial class Majorizor : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button loginNavbar = (Button)FindControl("loginNavbar");
            Button logoutNavbar = (Button)FindControl("logoutNavbar");

            if (Session["UserName"] == null)
            {
                logoutNavbar.Visible = false;
                loginNavbar.Visible = true;

                student_dropDown.Visible = false;
                advisor_dropDown.Visible = false;
                admin_dropDown.Visible = false;
                navBar_Brand.HRef = "~/Default.aspx";
            }
            else
            {
                logoutNavbar.Visible = true;
                loginNavbar.Visible = false;
                switch ((UserGroup)Session["UserGroup"])
                {
                    case UserGroup.USER:
                        student_dropDown.Visible = true;
                        advisor_dropDown.Visible = false;
                        admin_dropDown.Visible = false;
                        navBar_Brand.HRef = "~/Screens/Students/StudentLanding.aspx";
                        break;
                    case UserGroup.ADVISOR:
                        student_dropDown.Visible = true;
                        advisor_dropDown.Visible = true;
                        admin_dropDown.Visible = false;
                        navBar_Brand.HRef = "~/Screens/Advisors/AdvisorLanding/aspx";
                        break;
                    case UserGroup.ADMIN:
                        student_dropDown.Visible = true;
                        advisor_dropDown.Visible = true;
                        admin_dropDown.Visible = true;
                        navBar_Brand.HRef = "~/Screens/Admins/AdminLanding.aspx";
                        break;
                }
            }
        }

        protected void loginNavbar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Login.aspx");
        }

        protected void LogoutNavBar_Click(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Session["UserGroup"] = null;
            Response.Redirect("/Default.aspx");
        }
    }
}