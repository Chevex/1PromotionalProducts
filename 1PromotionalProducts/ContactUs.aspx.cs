using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Mail;

namespace _1PromotionalProducts
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                btnEdit.Visible = false;
            }
            else
            {
                btnEdit.Visible = true;
            }

            Entities db = new Entities();
            contactinfo.InnerHtml = db.Variables.Single(x => x.Name == "contactus").Value;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if ((tbxPhone.Text == "") && (tbxEmail.Text == ""))
            {
                CustomValidator1.IsValid = false;
            }
            else
            {
                SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
                MailMessage mm;

                mm = new MailMessage();
                mm.BodyFormat = MailFormat.Html;
                mm.To = "Jane@1PromotionalProducts.com";
                mm.From = "NoReply@1PromotionalProducts.com";
                mm.Subject = "New message generated from 1PromotionalProducts.com";
                mm.Body = "*** THIS IS AN AUTOMATED EMAIL. DO NOT REPLY. ***<br /><br />";
                mm.Body += "Name: " + tbxName.Text;
                if (tbxEmail.Text != "")
                {
                    mm.Body += "<br /><br />Reply Email: " + tbxEmail.Text;
                }
                if (tbxPhone.Text != "")
                {
                    mm.Body += "<br /><br />Phone Number: " + tbxPhone.Text;
                }
                mm.Body += "<br /><br />Comment/Question:<br />" + tbxBody.Text.Replace("\r", "<br />").Replace("\n", "");

                SmtpMail.Send(mm);

                Response.Redirect("Default.aspx", true);
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditPage.aspx?f=contactus", true);
        }
    }
}