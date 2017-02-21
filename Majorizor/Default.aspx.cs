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
            /*
            Example of how to access this.Application

            
            string x, y;
            Hashtable hashUser = (Hashtable)this.Application["CurrentUser"];

            x = hashUser["userName"].ToString();
            y= hashUser["userGroup"].ToString();
            */

            if (Application["CurrentUser"] != null)
            {
                Hashtable userHash = (Hashtable)this.Application["CurrentUser"];
                pageHeader.InnerText = "Hello, " + userHash["userName"].ToString() + ", " + pageHeader.InnerText;
            }
        }
    }
}