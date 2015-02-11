using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml.Xsl;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace Megaminds.@protected
{
	public partial class Manager : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            string curRole = LoginPage.Rolev; 
            if (curRole != null && (curRole == "manager" || curRole == "admin"))
            {

                welcome.Text = "Welcome " + LoginPage.Userv + " to the Manager page";
                accessed.Visible = true;
                denied.Visible = false;
                
                string location = Path.Combine(Request.PhysicalApplicationPath, @"App_Data/roles.xml");
                XDocument xmldoc = XDocument.Load(location);
                location = Path.Combine(Request.PhysicalApplicationPath, @"App_Data/roles.xsl");
                XDocument xsldoc = XDocument.Load(location);


                XslCompiledTransform transform = new XslCompiledTransform();
                using (XmlReader reader = XmlReader.Create(new StringReader(xsldoc.ToString())))
                {
                    transform.Load(reader);
                }
                StringWriter results = new StringWriter();
                using (XmlReader reader = XmlReader.Create(new StringReader(xmldoc.ToString())))
                {
                    transform.Transform(reader, null, results);
                }
                mydiv.InnerHtml = results.ToString();


            }
            else
            {
                accessed.Visible = false;
                denied.Visible = true;
            }
		}
	}
}