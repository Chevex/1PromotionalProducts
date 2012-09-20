using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace _1PromotionalProducts
{
    public partial class EditCatalog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CKFinder.FileBrowser fileBrowser = new CKFinder.FileBrowser();
            fileBrowser.BasePath = "/ckfinder/";
            fileBrowser.SetupCKEditor(rteBody);

            Entities db = new Entities();

            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Default.aspx", true);
            }

            if (!this.IsPostBack)
            {
                string sFileName = Request.QueryString["cn"];
                var catalog = db.Catalogs.Single(x => x.Name == sFileName);
                this.Title = "Edit " + catalog.Name;
                pagetitle.InnerText = "Edit " + catalog.Name;
                rteBody.Text = catalog.Description;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Entities db = new Entities();

            string sFileName = Request.QueryString["cn"];
            var catalog = db.Catalogs.Single(x => x.Name == sFileName);
            catalog.Description = rteBody.Text;
            db.SaveChanges();

            Response.Redirect("Catalog.aspx?cn=" + sFileName, true);
        }
    }
}