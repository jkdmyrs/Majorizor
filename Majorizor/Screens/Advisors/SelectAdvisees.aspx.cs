using System;
using System.Collections.Generic;
using Majorizor.Resources;

namespace Majorizor.Screens.Advisors
{
    public partial class SelectAdvisees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Resources.UserGroups.userHasAccess(UserGroup.ADVISOR, (UserGroup)Session["UserGroup"]) != true)
                    Response.Redirect("~/Default.aspx");
            }
            catch (System.NullReferenceException)
            {
                Response.Redirect("~/Default.aspx");
            }

            try
            {
                LoadAdvisees();
                // TODO - Select Advisees - Backend
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                // TODO - C# Bootstrap exception framework???? Maybe something like this exists. 
                // Otherwise it would be neat to eventually build a class to take (errorType, error message) as
                // parameters, and to add popup error messages built in clean bootstrap html.
            }
        }

        private void LoadAdvisees()
        {
            List<Student> students = Student.GetAllStudents();
            foreach (Student student in students)
            {
                GridView1.DataSource = students;
                GridView1.DataBind();
            }
        }
    }
}