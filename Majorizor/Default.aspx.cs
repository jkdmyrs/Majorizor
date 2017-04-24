using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Majorizor
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Application["CurrentUser"] != null)
            {
                Hashtable userHash = (Hashtable)Application["CurrentUser"];
                pageHeader.InnerText = "Hello, " + userHash["userName"].ToString() + ", " + pageHeader.InnerText;
            }
        }
    }
}