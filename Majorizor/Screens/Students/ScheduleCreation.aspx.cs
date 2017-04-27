using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Majorizor.Resources;

namespace Majorizor.Screens.Students
{
    public partial class ViewSchedule : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            Student activeUser = Student.GetStudentByID((int)Session["userID"]);

            StudentSchedule scheduleForUser = new StudentSchedule(activeUser);

            List<Course> enrolledCourses = scheduleForUser.courses;

            course1.Text = enrolledCourses[0].ToString();
            course2.Text = enrolledCourses[1].ToString();
            course3.Text = enrolledCourses[2].ToString();
            course4.Text = enrolledCourses[3].ToString();
            course5.Text = enrolledCourses[4].ToString();

        }
        
    }
}