using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Majorizor.Resources;
using System.IO;

namespace Majorizor.UserGroups.Admins
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
    }
}