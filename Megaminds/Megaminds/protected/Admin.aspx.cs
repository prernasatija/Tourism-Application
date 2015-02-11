using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using MyEncryption;

namespace Megaminds
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string curRole = LoginPage.Rolev;
            if (curRole != null && curRole == "admin")
            {
                welcome.Text = "Welcome " + LoginPage.Userv + " to the Admin page";
                accessed.Visible = true;
                denied.Visible = false;
            }
            else
            {
                accessed.Visible = false;
                denied.Visible = true;
            }
        }

        protected void staff_Click(object sender, EventArgs e)
        {
            if (pass == conPass)
            {
                loginMsg.Text = "Passwords don't match";
            }
            else
            {
                if (addNewUser(user.Text, pass.Text, "staff"))
                {
                    loginMsg.Text = "Staff Successfully Added.";
                }
                else { loginMsg.Text = "Staff not added."; }
            }
        }

        protected void manager_Click(object sender, EventArgs e)
        {
            if (pass == conPass)
            {
                loginMsg.Text = "Passwords don't match";
            }
            else
            {
                if (addNewUser(user.Text, pass.Text, "manager"))
                {
                    loginMsg.Text = "Manager Successfully Added.";
                }
                else { loginMsg.Text = "Manager not Added."; }
            }
        }

        public bool addNewUser(string username, string password, string role)
        {
            string location = Path.Combine(Request.PhysicalApplicationPath, @"App_Data/roles.xml");
            if (File.Exists(location))
            {
                string encryptedPass = MyEncryption.Crypto.Encrypt(password, "mypassword");
                FileStream fs = new FileStream(location, FileMode.Open);
                XmlDocument doc = new XmlDocument();
                doc.Load(fs);

                XmlNode rootNode = doc.DocumentElement;
                XmlNodeList credentials = rootNode.ChildNodes;
                foreach (XmlNode credential in credentials)
                {
                    XmlNodeList allChild = credential.ChildNodes;
                    XmlNode user = allChild.Item(0);
                    if (user.FirstChild.Value == username)
                    {
                        fs.Close();
                        return false;
                    }
                }
                XmlElement newUserCredential = doc.CreateElement("credential");
                XmlElement newUser = doc.CreateElement("Username");
                newUser.InnerText = username;
                XmlElement newPass = doc.CreateElement("Password");
                newPass.InnerText = encryptedPass;
                XmlElement newRole = doc.CreateElement("Role");
                newRole.InnerText = role;
                newUserCredential.AppendChild(newUser);
                newUserCredential.AppendChild(newPass);
                newUserCredential.AppendChild(newRole);
                rootNode.AppendChild(newUserCredential);

                fs.Close();
                File.Delete(location);
                fs = new FileStream(location, FileMode.CreateNew);
                doc.Save(fs);
                fs.Close();
                return true;
            }
            return false;
        }
    }
}