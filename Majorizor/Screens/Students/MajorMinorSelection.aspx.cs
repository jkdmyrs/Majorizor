using System;
using Majorizor.Resources;

namespace Majorizor.Screens.Students
{
    public partial class MajorMinorSelection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (UserGroups.userHasAccess(UserGroup.USER, new User((int)Session["UserID"])) != true)
                    Response.Redirect("~/Default.aspx", false);
            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Default.aspx", false);
            }

            try
            {
                Student s = new Student((int)Session["UserID"]);
            }
            catch (IndexOutOfRangeException)
            {
                Response.Redirect("~/Screens/Students/SetStudentInformation.aspx");
            }
            catch (Exception ex)
            {
                ExceptionHandler handler = new ExceptionHandler(ex, error_box);
                handler.Handle();
            }
        }
    }
}