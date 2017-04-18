using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Majorizor.Resources;
using Majorizor.Resources.DataAccess;
using System.IO;

namespace Majorizor.Screens.Advisors
{
    public partial class AdvisorLanding : System.Web.UI.Page
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
                Advisor currAdvisor = new Advisor(base.Session["UserName"].ToString());
                buildAdviseePanelHtml(currAdvisor.AdviseeIDs);
            } catch (Exception ex)
            {
                string error = ex.Message;
                // TODO - C# Bootstrap exception framework???? Maybe something like this exists. 
                // Otherwise it would be neat to eventually build a class to take (errorType, error message) as
                // parameters, and to add popup error messages built in clean bootstrap html.
            }
        }

        private void buildAdviseePanelHtml(List<int> IDs)
        {
            StringWriter htmlString = new StringWriter();
            using (HtmlTextWriter writer = new HtmlTextWriter(htmlString))
            {
                foreach (int ID in IDs)
                {
                    //Setup variables needed for the HTMLTextWriter 'writer'
                    Student student = new Student(ID);
                    string name;
                    string major;
                    string minor;
                    name = student.firstName + " " + student.lastName;
                    major = (student.major2 == Major.NONE) ? 
                        major = student.major1.ToString() : 
                        major = student.major1 + ", " + student.major2;
                    if (student.minor1 == Minor.NONE)
                        minor = "N/A";
                    else if (student.minor1 != Minor.NONE & student.minor2 == Minor.NONE)
                        minor = student.minor1.ToString();
                    else
                        minor = student.minor1 + ", " + student.minor2;

                    //TODO - Calculate Progress
                    int progress = 15;

                    //panel panel-primary
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, "panel panel-primary");
                    writer.RenderBeginTag(HtmlTextWriterTag.Div);

                    //panel heading
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, "panel-heading");
                    writer.RenderBeginTag(HtmlTextWriterTag.Div);
                    writer.Write(name);
                    writer.RenderEndTag(); //end panel-heading

                    //panel-body
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, "panel-body");
                    writer.RenderBeginTag(HtmlTextWriterTag.Div);

                    //row
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, "row");
                    writer.RenderBeginTag(HtmlTextWriterTag.Div);

                        //col-md-4 #1
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "col-md-4");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                            //majors
                            writer.RenderBeginTag(HtmlTextWriterTag.H4);
                            writer.Write("Majors: ");
                            writer.RenderEndTag();
                            writer.Write(major);
                            //minors
                            writer.RenderBeginTag(HtmlTextWriterTag.H4);
                            writer.Write("Minors: ");
                            writer.RenderEndTag();
                            writer.Write(minor);

                        writer.RenderEndTag();//col-md-4 - #1

                        //col-md-4 #2
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "col-md-4");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                            //year
                            writer.RenderBeginTag(HtmlTextWriterTag.H4);
                            writer.Write("Year: ");
                            writer.RenderEndTag();
                            writer.Write(student.year);
                            //graduation
                            writer.RenderBeginTag(HtmlTextWriterTag.H4);
                            writer.Write("Expected Graduation: ");
                            writer.RenderEndTag();
                            writer.Write(student.graduation);
                        writer.RenderEndTag();//col-md-4 - #2

                        //col-md-4 #3
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "col-md-4");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                            //button1
                            writer.AddAttribute(HtmlTextWriterAttribute.Type, "button");
                            writer.AddAttribute(HtmlTextWriterAttribute.Class, "btn btn-primary");
                            writer.AddAttribute(HtmlTextWriterAttribute.Value, "Select Majors/Minors");
                            writer.RenderBeginTag(HtmlTextWriterTag.Input);
                            writer.RenderEndTag();
                            // <br />
                            writer.WriteBreak();
                            // <br />
                            writer.WriteBreak();
                            //button2
                            writer.AddAttribute(HtmlTextWriterAttribute.Type, "button");
                            writer.AddAttribute(HtmlTextWriterAttribute.Class, "btn btn-default");
                            writer.AddAttribute(HtmlTextWriterAttribute.Value, "View Progress");
                            writer.RenderBeginTag(HtmlTextWriterTag.Input);
                            writer.RenderEndTag();
                            //button3
                            writer.AddAttribute(HtmlTextWriterAttribute.Type, "button");
                            writer.AddAttribute(HtmlTextWriterAttribute.Class, "btn btn-default");
                            writer.AddAttribute(HtmlTextWriterAttribute.Value, "View Schedule");
                            writer.RenderBeginTag(HtmlTextWriterTag.Input);
                            writer.RenderEndTag();
                            //button4
                            writer.AddAttribute(HtmlTextWriterAttribute.Type, "button");
                            writer.AddAttribute(HtmlTextWriterAttribute.Class, "btn btn-default");
                            writer.AddAttribute(HtmlTextWriterAttribute.Value, "Notes");
                            writer.RenderBeginTag(HtmlTextWriterTag.Input);
                            writer.RenderEndTag();

                        writer.RenderEndTag();//end col-md-4 - #3

                    writer.RenderEndTag();//end row
                    
                    // <br />
                    writer.WriteBreak();

                    //progress
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, "progress");
                    writer.RenderBeginTag(HtmlTextWriterTag.Div);
                    //TODO : conditionals for different progresses;
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, "progress-bar progress-bar-warning");
                    writer.AddAttribute(HtmlTextWriterAttribute.Style, "width:"+progress+"%");
                    writer.AddAttribute("role", "progressbar");
                    writer.RenderBeginTag(HtmlTextWriterTag.Div);
                    writer.Write(progress+"%");
                    writer.RenderEndTag();

                    writer.RenderEndTag(); //end progress

                    writer.RenderEndTag(); //end panel-body

                    writer.RenderEndTag(); //end panel panel-primary
                }
            }
            AdviseeInfo_PlcHldr.Controls.Add(new Literal { Text = htmlString.ToString() });
        }

    }
}