using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Security;

namespace _1PromotionalProducts
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Entities db = new Entities();

            Page.Title += " | 1PromotionalProducts.com";

            if (!Page.User.Identity.IsAuthenticated)
            {
                btnEditCatList1.Visible = false;
                btnEditCatList2.Visible = false;
                loggedincontrols.Visible = false;
                logincontrols.Visible = true;
            }
            else
            {
                btnEditCatList1.Visible = true;
                btnEditCatList2.Visible = true;
                logincontrols.Visible = false;
                loggedincontrols.Visible = true;
            }

            if (!this.IsPostBack)
            {
                if (Page.User.Identity.IsAuthenticated)
                {
                    loginviewer.Visible = true;
                }
                else
                {
                    loginviewer.Visible = false;
                }
                var catalogs = db.Catalogs;
                catlist1title.InnerText = db.Variables.Single(x => x.Name == "leftSleaveTitle").Value;
                catlist2title.InnerText = db.Variables.Single(x => x.Name == "rightSleaveTitle").Value;

                int iMargin = 35;
                foreach (var catalog in catalogs.Where(x => x.Sleave == "Left"))
                {
                    string sCatalogName = catalog.Name;
                    string sCatalogURL = catalog.URL;
                    if (catalog.ShowDescription)
                        sCatalogURL = "Catalog.aspx?cn=" + sCatalogName;

                    catlist1.InnerHtml += "<a style=\"margin-left:" + iMargin.ToString() + "px;\" href=\"" + sCatalogURL + "\" >" + sCatalogName + "</a><br />";
                    iMargin += 10;
                }

                iMargin = 35;
                foreach (var catalog in catalogs.Where(x => x.Sleave == "Right"))
                {
                    string sCatalogName = catalog.Name;
                    string sCatalogURL = catalog.URL;
                    if (catalog.ShowDescription)
                        sCatalogURL = "Catalog.aspx?cn=" + sCatalogName;

                    catlist2.InnerHtml += "<a style=\"margin-right:" + iMargin.ToString() + "px;\" href=\"" + sCatalogURL + "\" >" + sCatalogName + "</a><br />";
                    iMargin += 7;
                }
            }
        }

        protected void btnShowLogin_Click(object sender, ImageClickEventArgs e)
        {
            if (loginviewer.Visible == false)
            {
                loginviewer.Visible = true;
            }
            else
            {
                loginviewer.Visible = false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Entities db = new Entities();

            if (tbxUsername.Text.ToUpper() == "ADMIN")
            {
                string sPassword = db.Variables.Single(x => x.Name == "Password").Value;
                if (tbxPassword.Text == sPassword)
                {
                    FormsAuthentication.SetAuthCookie("Admin", false);
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    CustomValidator1.IsValid = false;
                }
            }
        }

        protected void btnEditCatList1_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditList.aspx?a=l", true);
        }

        protected void btnEditCatList2_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditList.aspx?a=r", true);
        }
    }
}