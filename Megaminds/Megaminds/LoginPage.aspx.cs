using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.IO;
using System.Xml;
using MyEncryption;

namespace Megaminds
{
    public partial class LoginPage : System.Web.UI.Page
    {
        public static string userv;
        public static string rolev = "";

        public static string Userv
        {
            get { return userv; }
            set { userv = value; }

        }
        public static string Rolev
        {
            get { return rolev; }
            set { rolev = value; }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            pass.Attributes["type"] = "password";
        }

        protected void member_Click(object sender, EventArgs e)
        {
            if (isValidCredentials(user.Text, pass.Text, "member"))
            {
                //Session["user"] = user.Text;
                //Session["role"] = "member";
                LoginPage.Userv = user.Text;
                LoginPage.Rolev = "member";
                FormsAuthentication.RedirectFromLoginPage(user.Text, persistent.Checked);
            }
            else
                loginMsg.Text = "Invalid Credentials";
        }

        protected void staff_Click(object sender, EventArgs e)
        {
            if (isValidCredentials(user.Text, pass.Text, "staff"))
            {
                //Session["user"] = user.Text;
                //Session["role"] = "staff";
                LoginPage.Userv = user.Text;
                LoginPage.Rolev = "staff";
                Response.Redirect("protected/Staff.aspx"); ;
            }
            else
                loginMsg.Text = "Invalid Credentials";
        }

        protected void manager_Click(object sender, EventArgs e)
        {
            if (isValidCredentials(user.Text, pass.Text, "manager"))
            {
                //Session["user"] = user.Text;
                //Session["role"] = "manager";
                LoginPage.Userv = user.Text;
                LoginPage.Rolev = "manager";
                Response.Redirect("protected/Manager.aspx");
            }
            else
                loginMsg.Text = "Invalid Credentials";
        }

        protected void admin_Click(object sender, EventArgs e)
        {
            if (isValidCredentials(user.Text, pass.Text, "admin"))
            {
                //Session["user"] = user.Text;
                //Session["role"] = "admin";
                LoginPage.Userv = user.Text;
                LoginPage.Rolev = "admin";
                Response.Redirect("protected/Admin.aspx");
            }
            else
                loginMsg.Text = "Invalid Credentials";
        }

        private bool isValidCredentials(string username, string password, string roleAsked)
        {
            string location = Path.Combine(Request.PhysicalApplicationPath, @"App_Data/roles.xml");
            if (File.Exists(location))
            {
                string encryptedPass = MyEncryption.Crypto.Encrypt(password, "mypassword");
                FileStream fs = new FileStream(location, FileMode.Open);
                XmlDocument doc = new XmlDocument();
                doc.Load(fs);
                fs.Close();
                XmlNode rootNode = doc.DocumentElement;
                XmlNodeList credentials = rootNode.ChildNodes;
                foreach (XmlNode credential in credentials)
                {
                    XmlNodeList allChild = credential.ChildNodes;
                    XmlNode user = allChild.Item(0);
                    if (user.FirstChild.Value == username)
                    {
                        XmlNode pass = allChild.Item(1);
                        XmlNode role = allChild.Item(2);
                        if (pass.FirstChild.Value == encryptedPass)
                        {
                            if (role.FirstChild.Value == roleAsked)
                            {

                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }
    }
}