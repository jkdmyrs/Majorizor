using System;
using System.Collections.Generic;
using Majorizor.Resources;
using System.Web;
using System.Web.UI.WebControls;
using System.Linq;

namespace Majorizor.Screens.Advisors
{
    public partial class SelectAdvisees : System.Web.UI.Page
    {
        int advisorID;
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
                advisorID = int.Parse(Session["UserID"].ToString());
                if (!IsPostBack)
                {
                    LoadTables();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                // TODO - C# Bootstrap exception framework???? Maybe something like this exists. 
                // Otherwise it would be neat to eventually build a class to take (errorType, error message) as
                // parameters, and to add popup error messages built in clean bootstrap html.
            }
        }

        private void LoadTables()
        {
            List<int> adviseeIDs = new Advisor(Session["UserName"].ToString()).AdviseeIDs;
            List<Student> currAdvisees = new List<Student>();
            foreach (int id in adviseeIDs)
            {
                currAdvisees.Add(new Student(id));
            }
            repeater_current.DataSource = currAdvisees;
            repeater_current.DataBind();

            List<Student> students = Student.GetAllStudents();
            List<Student> except = students.Except(currAdvisees, new StudentComparer()).ToList();

            repeater_add.DataSource = except;
            repeater_add.DataBind();
        }

        protected void button_add_Click(object sender, EventArgs e)
        {
            bool success = true;
            Button b = (Button)sender;
            RepeaterItem item = (RepeaterItem)b.NamingContainer;
            HiddenField hiddenID = (HiddenField)item.FindControl("add_hiddenID");
            int studentID = int.Parse(hiddenID.Value);
            try
            {
                Advisor.AddAdvisee(advisorID, studentID);
            }
            catch (Exception ex)
            {
                success = false;
                string error = ex.Message;
                // TODO - C# Bootstrap exception framework???? Maybe something like this exists. 
                // Otherwise it would be neat to eventually build a class to take (errorType, error message) as
                // parameters, and to add popup error messages built in clean bootstrap html.
            }
            finally
            {
                if(success)
                {
                    LoadTables();
                }
            }
        }

        protected void button_remove_Click(object sender, EventArgs e)
        {
            bool success = true;
            Button b = (Button)sender;
            RepeaterItem item = (RepeaterItem)b.NamingContainer;
            HiddenField hiddenID = (HiddenField)item.FindControl("curr_hiddenID");
            int studentID = int.Parse(hiddenID.Value);
            try
            {
                Advisor.RemoveAdvisee(advisorID, studentID);
            }
            catch (Exception ex)
            {
                success = false;
                string error = ex.Message;
                // TODO - C# Bootstrap exception framework???? Maybe something like this exists. 
                // Otherwise it would be neat to eventually build a class to take (errorType, error message) as
                // parameters, and to add popup error messages built in clean bootstrap html.
            }
            finally
            {
                if (success)
                {
                    LoadTables();
                }
            }
        }
    }
}