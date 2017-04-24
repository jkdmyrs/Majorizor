using System;
using System.Collections;

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