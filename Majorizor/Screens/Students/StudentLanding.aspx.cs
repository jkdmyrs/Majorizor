using System;
using Majorizor.Resources;
using Majorizor.Resources.Majors;
using Majorizor.Resources.Minors;

namespace Majorizor.Screens.Students
{
    public partial class StudentLanding : System.Web.UI.Page
    {
        Student student;
        MajorMinorManager manager;

        protected void Page_Load(object sender, EventArgs e)
        {
            int userID;
            try
            {
                userID = (int)Session["UserID"];
                if (UserGroups.userHasAccess(UserGroup.USER, new User(userID)) != true)
                    Response.Redirect("~/Default.aspx", false);
            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Default.aspx", false);
            }

            try
            {
                student = new Student((int)Session["UserID"]);
                manager = new MajorMinorManager(student);

                label_advisor.Text = student.getAdvisorName();
                label_graduation.Text = student.graduation;
                label_majors.Text = student.getMajors();
                label_minors.Text = student.getMinors();
                label_name.Text = student.getFullName();
                label_year.Text = student.year.ToString();
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