﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Majorizor.Resources;
using Majorizor.Resources.DataAccess;

namespace Majorizor.UserGroups.Advisors
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

            StudentInformation.getStudentByID(7);
        }
    }
}