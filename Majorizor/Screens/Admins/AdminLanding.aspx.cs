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
            try
            {
                if (Resources.UserGroups.userHasAccess(UserGroup.ADMIN, (UserGroup)Session["UserGroup"]) != true)
                    Response.Redirect("~/Default.aspx");
            }
            catch (System.NullReferenceException)
            {
                Response.Redirect("~/Default.aspx");
            }

            List<User> users = Resources.User.GetAllUsers();
            buildUserTableHtml(users);
        }

        private void buildUserTableHtml(List<User> users)
        {
            //constants for ASP controls
            const string indexChange = "userGroup_ItemChanged";

            StringWriter htmlString = new StringWriter();
            using (HtmlTextWriter writer = new HtmlTextWriter(htmlString))
            {
                foreach(User user in users)
                {
                    string name = user.firstName + " " + user.lastName;
                    string email = user.email;

                    //tr
                    writer.RenderBeginTag(HtmlTextWriterTag.Tr);

                    //td 1
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.Write(name);
                    writer.RenderEndTag(); //td 1 end

                    //td 2
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.Write(email);
                    writer.RenderEndTag(); //td 2 end

                    //td 3
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.AddAttribute("ID", "i" + user.userID);
                    writer.AddAttribute("runat", "server");
                    writer.AddAttribute("OnSelectedIndexChanged", indexChange);
                    writer.AddAttribute("AutoPostBack", "True");
                    writer.RenderBeginTag("asp:DropDownList");
                    switch (user.userGroup)
                    {
                        case UserGroup.USER:
                            writer.AddAttribute("Value", "USER");
                            writer.AddAttribute("Selected", "True");
                            writer.RenderBeginTag("asp:ListItem");
                            writer.Write("User");
                            writer.RenderEndTag();
                            writer.AddAttribute("Value", "ADVISOR");
                            writer.RenderBeginTag("asp:ListItem");
                            writer.Write("Advisor");
                            writer.RenderEndTag();
                            writer.AddAttribute("Value", "ADMIN");
                            writer.RenderBeginTag("asp:ListItem");
                            writer.Write("Admin");
                            writer.RenderEndTag();
                            break;
                        case UserGroup.ADVISOR:
                            writer.AddAttribute("Value", "USER");
                            writer.RenderBeginTag("asp:ListItem");
                            writer.Write("User");
                            writer.RenderEndTag();
                            writer.AddAttribute("Value", "ADVISOR");
                            writer.AddAttribute("Selected", "True");
                            writer.RenderBeginTag("asp:ListItem");
                            writer.Write("Advisor");
                            writer.RenderEndTag();
                            writer.AddAttribute("Value", "ADMIN");
                            writer.RenderBeginTag("asp:ListItem");
                            writer.Write("Admin");
                            writer.RenderEndTag();
                            break;
                        case UserGroup.ADMIN:
                            writer.AddAttribute("Value", "USER");
                            writer.RenderBeginTag("asp:ListItem");
                            writer.Write("User");
                            writer.RenderEndTag();
                            writer.AddAttribute("Value", "ADVISOR");
                            writer.RenderBeginTag("asp:ListItem");
                            writer.Write("Advisor");
                            writer.RenderEndTag();
                            writer.AddAttribute("Value", "ADMIN");
                            writer.AddAttribute("Selected", "True");
                            writer.RenderBeginTag("asp:ListItem");
                            writer.Write("Admin");
                            writer.RenderEndTag();
                            break;
                        default:
                            break;
                    }
                    writer.RenderEndTag();
                    writer.RenderEndTag(); //td 3 end

                    //td 4
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, "glyphicon glyphicon-remove");
                    writer.AddAttribute("data-toggle", "tooltop");
                    writer.AddAttribute(HtmlTextWriterAttribute.Title, "Delte User");
                    writer.AddAttribute("href", "#");
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.RenderBeginTag(HtmlTextWriterTag.Span);
                    writer.RenderEndTag();
                    writer.RenderEndTag();
                    writer.RenderEndTag(); //td 4 end

                    writer.RenderEndTag(); //tr end

                }
            }
            userTable_PlcHldr.Controls.Add(new Literal { Text = htmlString.ToString() });
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