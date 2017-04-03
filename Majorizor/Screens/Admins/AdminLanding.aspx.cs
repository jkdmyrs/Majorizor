using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Majorizor.Resources;

namespace Majorizor.Screens.Admins
{
    public partial class AdminLanding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Resources.UserGroups.userHasAccess(UserGroup.ADMIN, (UserGroup)Session["UserGroup"]) != true)
                    Response.Redirect("~/Default.aspx");
            }
            catch (System.NullReferenceException)
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void upload_Btn_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = Request.Files["test.txt"];
            if (file != null && file.ContentLength > 0)
            {

            }
            int contentLength = scheduleUpload.PostedFile.ContentLength;
            string contentType = scheduleUpload.PostedFile.ContentType;
            string fileName = scheduleUpload.PostedFile.FileName;

            if(fileName == "masterSchedule.txt" && contentLength > 0)
            {
                string savePath = Server.MapPath("" + fileName);
                // TODO - Change how/where we save this.
                //We may want to save it, we may just want to read it and then process the information straight into the database.

                //scheduleUpload.PostedFile.SaveAs(savePath);
            }
        }

        protected void userGroup_ItemChanged(object sender, EventArgs e)
        {
            UserGroup userGroup;
            DropDownList ddl = (DropDownList)sender;
            string value = ddl.SelectedValue;
            int ID = Int32.Parse(ddl.ID.Substring(1));
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
                    userGroup = UserGroup.USER;
                    break;
            }
            UserGroups.UpdateUserGroup(ID, userGroup);
        }
    }
}