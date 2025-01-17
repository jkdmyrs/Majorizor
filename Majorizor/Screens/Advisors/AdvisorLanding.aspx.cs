﻿using System;
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
                    Response.Redirect("~/Default.aspx", false);
            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Default.aspx", false);
            }

            try
            {
                userID = (int)Session["UserID"];
                Advisor currAdvisor = new Advisor(userID);
                buildAdviseePanelHtml(currAdvisor.AdviseeIDs);
            }
            catch (Exception ex)
            {
                ExceptionHandler handler = new ExceptionHandler(ex, error_box);
                handler.Handle();
            }
        }

        /// <summary>
        /// Builds Advisee Panels
        /// 
        /// TODO - Change this to use an ASP:Repeater instead
        ///      - NOTE: I tried to do this, but it seems like setting the width attribute to the 
        ///        progress bar was challenging to do with a repeater
        /// </summary>
        /// <param name="IDs"></param>
        private void buildAdviseePanelHtml(List<int> IDs)
        {
            StringWriter htmlString = new StringWriter();
            using (HtmlTextWriter writer = new HtmlTextWriter(htmlString))
            {
                foreach (int ID in IDs)
                {
                    // Setup variables needed for the HTMLTextWriter 'writer'
                    Student student = new Student(ID);
                    int progress;
                    
                    try
                    {
                        ProgressTracker tracker = new ProgressTracker(ID);
                        progress = tracker.CalculateProgress();
                    }
                    catch (DivideByZeroException e)
                    {
                        progress = 0;
                        ExceptionHandler handler = new ExceptionHandler(e, error_box);
                        handler.Handle(true);
                    }

                    // panel panel-primary
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, "panel panel-primary");
                    writer.RenderBeginTag(HtmlTextWriterTag.Div);

                    // panel heading
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, "panel-heading");
                    writer.RenderBeginTag(HtmlTextWriterTag.Div);
                    writer.Write(student.FullNameStr());
                    writer.RenderEndTag(); //end panel-heading

                    // panel-body
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, "panel-body");
                    writer.RenderBeginTag(HtmlTextWriterTag.Div);

                    // row
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, "row");
                    writer.RenderBeginTag(HtmlTextWriterTag.Div);

                        // col-md-4 #1
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "col-md-4");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                            // majors
                            writer.RenderBeginTag(HtmlTextWriterTag.H4);
                            writer.Write("Majors: ");
                            writer.RenderEndTag();
                            writer.Write(student.MajorsStr());
                            // minors
                            writer.RenderBeginTag(HtmlTextWriterTag.H4);
                            writer.Write("Minors: ");
                            writer.RenderEndTag();
                            writer.Write(student.MinorsStr());

                        writer.RenderEndTag();//col-md-4 - #1

                        // col-md-4 #2
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "col-md-4");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                            // year
                            writer.RenderBeginTag(HtmlTextWriterTag.H4);
                            writer.Write("Year: ");
                            writer.RenderEndTag();
                            writer.Write(student.year);
                            // graduation
                            writer.RenderBeginTag(HtmlTextWriterTag.H4);
                            writer.Write("Expected Graduation: ");
                            writer.RenderEndTag();
                            writer.Write(student.graduation);
                        writer.RenderEndTag();//col-md-4 - #2

                        // col-md-4 #3
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "col-md-4");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                            // button1
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
                            // button3
                            writer.AddAttribute(HtmlTextWriterAttribute.Type, "button");
                            writer.AddAttribute(HtmlTextWriterAttribute.Class, "btn btn-default");
                            writer.AddAttribute(HtmlTextWriterAttribute.Value, "View Schedule");
                            writer.RenderBeginTag(HtmlTextWriterTag.Input);
                            writer.RenderEndTag();
                            // button4
                            writer.AddAttribute(HtmlTextWriterAttribute.Type, "button");
                            writer.AddAttribute(HtmlTextWriterAttribute.Class, "btn btn-default");
                            writer.AddAttribute(HtmlTextWriterAttribute.Value, "Notes");
                            writer.RenderBeginTag(HtmlTextWriterTag.Input);
                            writer.RenderEndTag();

                        writer.RenderEndTag();//end col-md-4 - #3

                    writer.RenderEndTag();//end row
                    
                    // <br />
                    writer.WriteBreak();

                    // progress
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, "progress");
                    writer.RenderBeginTag(HtmlTextWriterTag.Div);
                    if (progress < 20)
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "progress-bar progress-bar-danger");
                        writer.AddAttribute(HtmlTextWriterAttribute.Style, "width:" + progress + "%");
                        writer.AddAttribute("role", "progressbar");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write(progress + "%");
                        writer.RenderEndTag();
                    }
                    else if (progress <80)
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "progress-bar progress-bar-warning");
                        writer.AddAttribute(HtmlTextWriterAttribute.Style, "width:" + progress + "%");
                        writer.AddAttribute("role", "progressbar");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write(progress + "%");
                        writer.RenderEndTag();
                    }
                    else
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "progress-bar progress-bar-success progress-bar-striped active");
                        writer.AddAttribute(HtmlTextWriterAttribute.Style, "width:" + progress + "%");
                        writer.AddAttribute("role", "progressbar");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.Write(progress + "%");
                        writer.RenderEndTag();
                    }

                    writer.RenderEndTag(); //end progress

                    writer.RenderEndTag(); //end panel-body

                    writer.RenderEndTag(); //end panel panel-primary
                }
            }
            AdviseeInfo_PlcHldr.Controls.Add(new Literal { Text = htmlString.ToString() });
        }

    }
}