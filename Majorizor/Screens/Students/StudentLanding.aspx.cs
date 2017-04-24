using System;
using Majorizor.Resources;
using Majorizor.Resources.Majors;

namespace Majorizor.Screens.Students
{
    public partial class StudentLanding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = (int)Session["UserID"];
            try
            {
                if (UserGroups.userHasAccess(UserGroup.USER, new User(userID)) != true)
                    Response.Redirect("~/Default.aspx");
            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Default.aspx");
            }

            try
            {
                Student s = new Student(userID);
                if (s.major1.majorType == MajorType.NONE)
                    Response.Redirect("~/Screens/Students/MajorMinorSelection.aspx");
            }
            catch (IndexOutOfRangeException)
            {
                Response.Redirect("~/Screens/Students/SetStudentInformation.aspx");
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                // TODO - C# Bootstrap exception framework???? Maybe something like this exists. 
                // Otherwise it would be neat to eventually build a class to take (errorType, error message) as
                // parameters, and to add popup error messages built in clean bootstrap html.
            }
        }
    }
}