using System;
using System.Collections.Generic;
using Majorizor.Resources;
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
                if (UserGroups.userHasAccess(UserGroup.ADVISOR, new User((int)Session["UserID"])) != true)
                    Response.Redirect("~/Default.aspx", false);
            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Default.aspx", false);
            }

            try
            {
                advisorID = (int)Session["UserID"];
                if (!IsPostBack)
                {
                    LoadTables();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler handler = new ExceptionHandler(ex, error_box);
                handler.Handle();
            }
        }

        /// <summary>
        /// Load Current Advisees and Add Advisees tables with correct students
        /// 
        /// Add Advisees should not display students in Current Advisees table
        /// </summary>
        private void LoadTables()
        {
            List<int> adviseeIDs = new Advisor(advisorID).AdviseeIDs;
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

        /// <summary>
        /// Add the selected Student to the logged-in Advisor's advisee list
        /// 
        /// If fails, catch error
        /// 
        /// If success, re-load tables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void button_add_Click(object sender, EventArgs e)
        {
            bool success = true;
            Button b = (Button)sender;
            RepeaterItem item = (RepeaterItem)b.NamingContainer;
            // get hiddenID from HTML
            HiddenField hiddenID = (HiddenField)item.FindControl("add_hiddenID");
            int studentID = int.Parse(hiddenID.Value);
            try
            {
                Advisor.AddAdvisee(advisorID, studentID);
            }
            catch (Exception ex)
            {
                success = false;
                ExceptionHandler handler = new ExceptionHandler(ex, error_box);
                handler.Handle();
            }
            finally
            {
                if(success)
                {
                    LoadTables();
                }
            }
        }

        /// <summary>
        /// Remove the selected Student from the logged-in Advisor's advisee list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void button_remove_Click(object sender, EventArgs e)
        {
            bool success = true;
            Button b = (Button)sender;
            RepeaterItem item = (RepeaterItem)b.NamingContainer;
            // get hideenID from HTML
            HiddenField hiddenID = (HiddenField)item.FindControl("curr_hiddenID");
            int studentID = int.Parse(hiddenID.Value);
            try
            {
                Advisor.RemoveAdvisee(advisorID, studentID);
            }
            catch (Exception ex)
            {
                success = false;
                ExceptionHandler handler = new ExceptionHandler(ex, error_box);
                handler.Handle();
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