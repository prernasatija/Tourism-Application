using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Megaminds
{
    public partial class FooterUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 month = DateTime.Now.Month;
            if (month <= 6)
            {
                semester.Text = "Spring ";
            }
            else
            {
                semester.Text = "Fall ";
            }
            year.Text = Convert.ToString(DateTime.Now.Year);
        }
    }
}