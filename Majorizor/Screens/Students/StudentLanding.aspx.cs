using System;
using Majorizor.Resources;
using Majorizor.Resources.Majors;
using Majorizor.Resources.Minors;

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
                    Response.Redirect("~/Default.aspx", false);
            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Default.aspx", false);
            }

            try
            {
                Student s = new Student(userID);
                if (s.major1.majorType == MajorType.NONE)
                    Response.Redirect("~/Screens/Students/MajorMinorSelection.aspx");
                else
                {
                    label_name.Text = s.getFullName();
                    label_majors.Text = s.getMajors();
                    label_minors.Text = s.getMinors();
                    label_year.Text = s.year.ToString();
                    label_graduation.Text = s.graduation;
                    // TODO - Improve this to show more advisor information (email, office number?)
                    label_advisor.Text = s.getAdvisorName();
                }
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

        protected void button_viewCurriculum_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Screens/Students/CurriculumView.aspx");
        }

        protected void button_viewSchedule_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Screens/Students/CurriculumView.aspx");
        }
    }
}