using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Majorizor.Resources;
using Majorizor.Resources.DataAccess;
using MySql.Data.MySqlClient;
using System.Data;

namespace Majorizor.Screens.Students
{
    public partial class SetStudentInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (UserGroups.userHasAccess(UserGroup.USER, new User((int)Session["UserID"])) != true)
                    Response.Redirect("~/Default.aspx");
            }
            catch (System.NullReferenceException)
            {
                Response.Redirect("~/Default.aspx");
            }

            try
            {
                //bind graduation drop down
                LoadGraduation();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                // TODO - C# Bootstrap exception framework???? Maybe something like this exists. 
                // Otherwise it would be neat to eventually build a class to take (errorType, error message) as
                // parameters, and to add popup error messages built in clean bootstrap html.
            }
        }

        private void LoadGraduation()
        {
            DataTable gradTerms = StudentPageRepository.LoadGraduation();

            graduation_ddl.DataSource = gradTerms;
            graduation_ddl.DataTextField = "term_name";
            graduation_ddl.DataValueField = "termID";
            graduation_ddl.DataBind();
        }

        protected void button_update_Click(object sender, EventArgs e)
        {
            bool success = true;
            try
            {
                // Set firstTime Student Information
                int userID = (int)Session["UserID"];
                int termID = int.Parse(graduation_ddl.SelectedValue);
                string year = year_ddl.SelectedValue;
                StudentPageRepository.SetStudentInformation(userID, termID, year);
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
                    Response.Redirect("~/Screens/Students/MajorMinorSelection.aspx");
                }
            }
        }
    }
}