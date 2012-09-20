using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace _1PromotionalProducts
{
    public partial class CapabilityStatement : System.Web.UI.Page
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
            capabilitystatement.InnerHtml = db.Variables.Single(x => x.Name == "capabilitystatement").Value;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditPage.aspx?f=capabilitystatement", true);
        }
    }
}