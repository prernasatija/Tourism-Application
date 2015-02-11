using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Megaminds
{
    public partial class HeaderUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            update_time(sender, e);
        }

        protected void update_time(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            string d = date.Month + "/" + date.Day + "/" + date.Year;
            int hours = date.Hour;
            string am = "AM";
            if (hours >= 12)
            {
                am = "PM";
                if (hours != 12)
                    hours -= 12;
            }
            string t = hours + ":" + date.Minute + ":" + date.Second;
            time.Text = d + " " + t + " " + am;
        }
    }
}