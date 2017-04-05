using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Majorizor.Resources;
using System.IO;

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
            const string expctName = "MasterSchedule.csv";

            HttpPostedFile file;
            string fileName;
            int contentLength;

            file = Request.Files[0];
            fileName = file.FileName;
            contentLength = file.ContentLength;
            
            if (contentLength > 0 && fileName == expctName)
            {
                Stream s = file.InputStream;
                MasterScheduleParser p = new MasterScheduleParser(s);
            }
            else if (fileName != expctName)
            {
                //Error code for incorrect file
            }
            else if (contentLength <= 0)
            {
                //Error code for blank file
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