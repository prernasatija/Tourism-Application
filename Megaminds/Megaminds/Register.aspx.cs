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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pass.Attributes["type"] = "password";
                conPass.Attributes["type"] = "password";
                string imageServiceurl = "http://venus.eas.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetVerifierString/7";
                XmlDocument doc1 = new XmlDocument();
                doc1.Load(imageServiceurl);
                XmlNode node = doc1.FirstChild;
                Session["imagetext"] = node.InnerText;
                String imageBaseUrl = "http://venus.eas.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/";
                imageBaseUrl += node.InnerText;
                Image1.ImageUrl = imageBaseUrl;
            }

            
        }

        protected void submit_Click(object sender, EventArgs e)
        {

            string imgtext = (string)Session["imagetext"];
            if (imagetext.Text == imgtext)
            {
                string p1 = pass.Text;
                string p2 = conPass.Text;
                if (!p1.Equals(p2))
                {
                    loginMsg.Text = "Passwords don't match";
                }
                else
                {
                    if (addNewUser(user.Text, pass.Text, "member"))
                    {
                       // Session["user"] = user.Text;
                       // Session["role"] = "member";
                        LoginPage.Userv = user.Text;
                        LoginPage.Rolev = "member";

                        Response.Redirect("Default.aspx");
                        //loginMsg.Text = "Sign up Successful";
                    }
                    else { loginMsg.Text = "Username already exists."; }
                }
            }
            else
            {
                loginMsg.Text = "Incorrect text entered for image.";
            }
            
        }

        public bool addNewUser(string username, string password, string role)
        {
            string location = Path.Combine(Request.PhysicalApplicationPath, @"App_Data/roles.xml");
            if (File.Exists(location))
            {
                string encryptedPass = MyEncryption.Crypto.Encrypt(password, "mypassword");
                FileStream fs = new FileStream(location,  FileMode.Open);
                XmlDocument doc = new XmlDocument();
                doc.Load(fs);
                
                XmlNode rootNode = doc.DocumentElement;
                XmlNodeList credentials = rootNode.ChildNodes;
                foreach (XmlNode credential in credentials)
                {
                    XmlNodeList allChild = credential.ChildNodes;
                    XmlNode user = allChild.Item(0);
                    if(user.FirstChild.Value == username)
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