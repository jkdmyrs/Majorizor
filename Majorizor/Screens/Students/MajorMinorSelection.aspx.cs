using System;
using Majorizor.Resources;
using Majorizor.Resources.Majors;
using Majorizor.Resources.Minors;
using Majorizor.Resources.DataAccess;
using System.Web.UI.WebControls;

namespace Majorizor.Screens.Students
{
    public partial class MajorMinorSelection : System.Web.UI.Page
    {
        Student student;
        MajorMinorManager manager;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (UserGroups.userHasAccess(UserGroup.USER, new User((int)Session["UserID"])) != true)
                    Response.Redirect("~/Default.aspx", false);
            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Default.aspx", false);
            }

            try
            {
                student = new Student((int)Session["UserID"]);
                manager = new MajorMinorManager(student);

                if (!IsPostBack)
                {
                    bindAllData();
                }
            }
            catch (IndexOutOfRangeException)
            {
                Response.Redirect("~/Screens/Students/SetStudentInformation.aspx");
            }
            catch (Exception ex)
            {
                ExceptionHandler handler = new ExceptionHandler(ex, error_box);
                handler.Handle();
            }
        }



        private void bindAllData()
        {

            ddl_majors.DataSource = StudentPageRepository.LoadMajorsDdl(student.userID);
            ddl_majors.DataBind();
            ddl_minors.DataSource = StudentPageRepository.LoadMinorsDdl(student.userID);
            ddl_minors.DataBind();

            if (student.major1.majorType == MajorType.NONE)
            {
                text_major1.Text = "";
                btn_addMajor1.Visible = true;
                btn_dropMajor1.Visible = false;
            }
            else
            {
                text_major1.Text = student.major1.majorName;
                btn_addMajor1.Visible = false;
                btn_dropMajor1.Visible = true;
            }

            if (student.major2.majorType == MajorType.NONE)
            {
                text_major2.Text = "";
                btn_addMajor2.Visible = true;
                btn_dropMajor2.Visible = false;
            }
            else
            {
                text_major2.Text = student.major2.majorName;
                btn_addMajor2.Visible = false;
                btn_dropMajor2.Visible = true;
            }

            if (student.minor1.minorType == MinorType.NONE)
            {
                text_minor1.Text = "";
                btn_addMinor1.Visible = true;
                btn_dropMinor1.Visible = false;
            }
            else
            {
                text_minor1.Text = student.minor1.minorName;
                btn_addMinor1.Visible = false;
                btn_dropMinor1.Visible = true;
            }

            if (student.minor2.minorType == MinorType.NONE)
            {
                text_minor2.Text = "";
                btn_addMinor2.Visible = true;
                btn_dropMinor2.Visible = false;
            }
            else
            {
                text_minor2.Text = student.minor2.minorName;
                btn_addMinor2.Visible = false;
                btn_dropMinor2.Visible = true;
            }
        }

        protected void ddl_majors_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            string majorName = ddl.SelectedValue;
            if (manager.MajorAvailable())
            {
                switch (majorName)
                {
                    case "Software Engineering":
                        student = manager.SetMajor(MajorType.SE);
                        break;
                    case "Electrical Engineering":
                        student = manager.SetMajor(MajorType.EE);
                        break;
                    case "Computer Engineering":
                        student = manager.SetMajor(MajorType.CE);
                        break;
                    case "Math":
                        student = manager.SetMajor(MajorType.MA);
                        break;
                    case "Computer Science":
                        student = manager.SetMajor(MajorType.CS);
                        break;
                }
                bindAllData();
            }
        }

        protected void ddl_minors_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            string minorName = ddl.SelectedValue;
            if (manager.MinorAvailable())
            {
                switch (minorName)
                {
                    case "Software Engineering":
                        student = manager.SetMinor(MinorType.SE);
                        break;
                    case "Electrical Engineering":
                        student = manager.SetMinor(MinorType.EE);
                        break;
                    case "Math":
                        student = manager.SetMinor(MinorType.MA);
                        break;
                    case "Computer Science":
                        student = manager.SetMinor(MinorType.CS);
                        break;
                }
                bindAllData();
            }
        }

        protected void btn_dropMajor1_Click(object sender, EventArgs e)
        {
            student = manager.DropMajor1();
            bindAllData();
        }

        protected void btn_dropMajor2_Click(object sender, EventArgs e)
        {
            student = manager.DropMajor2();
            bindAllData();
        }

        protected void btn_dropMinor1_Click(object sender, EventArgs e)
        {
            student = manager.DropMinor1();
            bindAllData();
        }

        protected void btn_dropMinor2_Click(object sender, EventArgs e)
        {
            student = manager.DropMinor2();
            bindAllData();
        }

        protected void next_Click(object sender, EventArgs e)
        {
            try
            {
                if (manager.HasMajor())
                    Response.Redirect("~/Screens/Students/StudentLanding.aspx");
                else
                {
                    throw new Exception("You must select atleast one Major before continuing.");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler handler = new ExceptionHandler(ex, error_box);
                handler.Handle(true);
            }
        }
    }
}