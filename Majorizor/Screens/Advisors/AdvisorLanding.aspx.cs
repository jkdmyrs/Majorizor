using System;
using System.IO;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Majorizor.Resources;
using Majorizor.Resources.Majors;
using Majorizor.Resources.Minors;

namespace Majorizor.Screens.Advisors
{
    public partial class AdvisorLanding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID;
            try
            {
                userID = (int)Session["UserID"];
                if (UserGroups.userHasAccess(UserGroup.ADVISOR, new User(userID)) != true)
                    Response.Redirect("~/Default.aspx");
            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Default.aspx");
            }

            try
            {
                userID = (int)Session["UserID"];
                Advisor currAdvisor = new Advisor(userID);
                buildAdviseePanelHtml(currAdvisor.AdviseeIDs);
            } catch (Exception ex)
            {
                string error = ex.Message;
                // TODO - C# Bootstrap exception framework???? Maybe something like this exists. 
                // Otherwise it would be neat to eventually build a class to take (errorType, error message) as
                // parameters, and to add popup error messages built in clean bootstrap html.
            }
        }

        /// <summary>
        /// Builds Advisee Panels
        /// 
        /// TODO - Change this to use an ASP:Repeater instead
        /// </summary>
        /// <param name="IDs"></param>
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

                    if (student.major1.majorType == MajorType.NONE)
                        major = "N/A";
                    else if (student.major1.majorType != MajorType.NONE & student.major2.majorType == MajorType.NONE)
                        major = student.major1.majorName;
                    else
                        major = student.major1.majorName + ", " + student.major2.majorName;

                    if (student.minor1.minorType == MinorType.NONE)
                        minor = "N/A";
                    else if (student.minor1.minorType != MinorType.NONE & student.minor2.minorType == MinorType.NONE)
                        minor = student.minor1.minorName;
                    else
                        minor = student.minor1.minorName + ", " + student.minor2.minorName;

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