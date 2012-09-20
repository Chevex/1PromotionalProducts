using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace _1PromotionalProducts
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Default.aspx", true);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Entities db = new Entities();

            var passwordVariable = db.Variables.Single(x => x.Name == "Password");

            if (tbxCurrentPassword.Text == passwordVariable.Value)
            {
                passwordVariable.Value = tbxNewPassword.Text;
                db.SaveChanges();

                Response.Redirect("Default.aspx", true);
            }
        }
    }
}