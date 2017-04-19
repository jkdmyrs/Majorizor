using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Majorizor.Resources;
using System.IO;
using System.Web.UI.HtmlControls;

namespace Majorizor.Screens.Admins
{
    public partial class AdminLanding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check access
            try
            {
                if (Resources.UserGroups.userHasAccess(UserGroup.ADMIN, (UserGroup)Session["UserGroup"]) != true)
                    Response.Redirect("~/Default.aspx");
            }
            catch (System.NullReferenceException)
            {
                Response.Redirect("~/Default.aspx");
            }

            try
            {
                if(!IsPostBack)
                {
                    List<User> users = Resources.User.GetAllUsers();
                    Repeater1.DataSource = users;
                    Repeater1.DataBind();
                }

            } catch (Exception ex)
            {
                string error = ex.Message;
                // TODO - C# Bootstrap exception framework???? Maybe something like this exists. 
                // Otherwise it would be neat to eventually build a class to take (errorType, error message) as
                // parameters, and to add popup error messages built in clean bootstrap html.
            }
        }

        protected void upload_Btn_Click(object sender, EventArgs e)
        {
            //const string expctName = "MasterSchedule.csv";

            HttpPostedFile file;
            string fileName;
            int contentLength;

            file = Request.Files[0];
            fileName = file.FileName;
            contentLength = file.ContentLength;
            
            //if (contentLength > 0 && fileName == expctName)
            if (contentLength > 0)
            {
                Stream s = file.InputStream;
                MasterScheduleLoader loader = new MasterScheduleLoader(s);
                try
                {
                    loader.LoadSchedule();
                } catch (Exception ex)
                {
                    string error = ex.Message;
                    // TODO - C# Bootstrap exception framework???? Maybe something like this exists. 
                    // Otherwise it would be neat to eventually build a class to take (errorType, error message) as
                    // parameters, and to add popup error messages built in clean bootstrap html.
                }
            }
        }

        protected void deleteUser_Click(object sender, EventArgs e)
        {
            bool success = true;
            LinkButton button = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)button.NamingContainer;
            HiddenField hiddenID = (HiddenField)item.FindControl("hiddenID");
            int ID = int.Parse(hiddenID.Value);
            try
            {
                Resources.User.DeleteUser(ID);
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
                    Response.Redirect(Request.RawUrl);
            }
        }

        protected void userGroup_ItemChanged(object sender, EventArgs e)
        {
            bool success = true;
            UserGroup userGroup;
            DropDownList ddl = (DropDownList)sender;
            
            //Get hiddenID
            RepeaterItem item = (RepeaterItem)ddl.NamingContainer;
            HiddenField hiddenID = (HiddenField)item.FindControl("hiddenID");
            int ID = int.Parse(hiddenID.Value);

            string value = ddl.SelectedValue;
            switch (value)
            {
                case "ADMIN":
                    userGroup = UserGroup.ADMIN;
                    break;
                case "ADVISOR":
                    userGroup = UserGroup.ADVISOR;
                    break;
                case "USER":
                    userGroup = UserGroup.USER;
                    break;
                default:
                    userGroup = UserGroup.DEFUALT;
                    success = false;
                    break;
            }
            try
            {
                Resources.User.UpdateUserGroup(ID, userGroup);
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
                    Response.Redirect(Request.RawUrl);
            }
        }
    }
}