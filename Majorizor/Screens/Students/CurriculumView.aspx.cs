using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Majorizor.Resources;

namespace Majorizor.Screens.Students
{
    public partial class ViewSchedule : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void button_curriculum_click(object sender, EventArgs e)
        {
            Student activeUser = Student.GetStudentByID((int)Session["userID"]);

            if (activeUser.major1.majorType == Resources.Majors.MajorType.CE) {
                
                }
        }
    }
}