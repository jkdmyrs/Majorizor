using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Majorizor.Resources
{
    public class ExceptionHandler
    {
        public Exception e { get; private set; }
        public PlaceHolder ph { get; private set; }

        public ExceptionHandler(Exception _e, PlaceHolder _ph)
        {
            e = _e;
            ph = _ph;
        }

        public void Handle()
        {
            StringWriter htmlString = new StringWriter();
            using (HtmlTextWriter writer = new HtmlTextWriter(htmlString))
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "alert alert-danger");
                writer.AddAttribute("role", "alert");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                writer.RenderBeginTag(HtmlTextWriterTag.Strong);
                writer.Write("Error: ");
                writer.RenderEndTag();
                writer.Write(e.Message);
                writer.RenderEndTag();
            }
            ph.Controls.Add(new Literal { Text = htmlString.ToString() });
        }

    }
}