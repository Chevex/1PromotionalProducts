using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace _1PromotionalProducts
{
    public partial class EditPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Entities db = new Entities();

            CKFinder.FileBrowser fileBrowser = new CKFinder.FileBrowser();
            fileBrowser.BasePath = "/ckfinder/";
            fileBrowser.SetupCKEditor(rteBody);

            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Default.aspx", true);
            }

            if (!this.IsPostBack)
            {
                var pageName = Request.QueryString["f"];
                rteBody.Text = db.Variables.Single(x => x.Name == pageName).Value;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var pageName = Request.QueryString["f"];
            Entities db = new Entities();
            var pageVariable = db.Variables.Single(x => x.Name == pageName);
            pageVariable.Value = rteBody.Text;
            db.SaveChanges();

            Response.Redirect(pageVariable.Name + ".aspx", true);
        }
    }
}