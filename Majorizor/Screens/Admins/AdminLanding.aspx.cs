using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Majorizor.Resources;

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
    }
}