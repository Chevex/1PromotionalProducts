using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace _1PromotionalProducts
{
    public partial class CatalogPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Entities db = new Entities();

            if (!User.Identity.IsAuthenticated)
            {
                btnEditCatalog.Visible = false;
            }
            else
            {
                btnEditCatalog.Visible = true;
            }

            if (!this.IsPostBack)
            {
                string catalogName = Request.QueryString["cn"];

                var catalog = db.Catalogs.Single(x => x.Name == catalogName);
                this.Title = catalog.Name;
                pagetitle.InnerText = catalog.Name;
                hlCatalogLink.Text = "Click Here To View The Catalog";
                hlCatalogLink.NavigateUrl = catalog.URL;
                catalogpagecontent.InnerHtml = catalog.Description;
            }
        }

        protected void btnEditCatalog_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditCatalog.aspx?cn=" + Request.QueryString["cn"], true);
        }
    }
}