using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Megaminds
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            LoginPage.Userv = null;
            LoginPage.Rolev = null;
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            HttpContext ctx = HttpContext.Current;
            String appPath = ctx.Request.AppRelativeCurrentExecutionFilePath;
            Exception exception = ctx.Server.GetLastError();

            string errorInfo = exception.InnerException.Message;

            System.Web.UI.Page page = System.Web.HttpContext.Current.Handler as System.Web.UI.Page;
            if (page != null)
            {
                Label label = page.FindControl("statusbuttonclick") as Label;
                label.Text = String.Format(errorInfo);
            }
            HttpContext.Current.ClearError();
            HttpContext.Current.Application.Add("test", exception.InnerException.Message.ToString());
            Server.Transfer(appPath, false);
            //Response.Redirect(appPath, false);
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}