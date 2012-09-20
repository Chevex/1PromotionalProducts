using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace _1PromotionalProducts
{
    public partial class EditList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Entities db = new Entities();

            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Default.aspx", true);
            }

            if (!this.IsPostBack)
            {
                if (Request.QueryString["a"] == "l")
                {
                    pagetitle.InnerText = "Edit Left Sleeve";
                    leftalign.Visible = true;
                    rightalign.Visible = false;
                    var sleaveTitleVariable = db.Variables.Single(x => x.Name == "leftSleaveTitle");
                    var catalogs = db.Catalogs.Where(x => x.Sleave == "Left");
                    tbxListTitle1.Text = sleaveTitleVariable.Value;
                    foreach (var catalog in catalogs)
                        lbxCatalogs1.Items.Add(catalog.Name);
                    if (lbxCatalogs1.Items.Count == 10)
                    {
                        btnNewCatalog1.Enabled = false;
                        lbxCatalogs1.SelectedIndex = 0;
                        lbxCatalogs1_SelectedIndexChanged(null, null);
                    }
                    else
                    {
                        btnNewCatalog1_Click(null, null);
                    }
                }
                else
                {
                    pagetitle.InnerText = "Edit Right Sleeve";
                    leftalign.Visible = false;
                    rightalign.Visible = true;
                    var sleaveTitleVariable = db.Variables.Single(x => x.Name == "rightSleaveTitle");
                    var catalogs = db.Catalogs.Where(x => x.Sleave == "Right");
                    tbxListTitle2.Text = sleaveTitleVariable.Value;
                    foreach (var catalog in catalogs)
                        lbxCatalogs2.Items.Add(catalog.Name);
                    if (lbxCatalogs2.Items.Count == 10)
                    {
                        btnNewCatalog2.Enabled = false;
                        lbxCatalogs2.SelectedIndex = 0;
                        lbxCatalogs1_SelectedIndexChanged(null, null);
                    }
                    else
                    {
                        btnNewCatalog1_Click(null, null);
                    }
                }
            }
        }

        protected void btnNewCatalog1_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["a"] == "l")
            {
                cbxDeleteCatalog1.Checked = false;
                cbxDeleteCatalog1.Visible = false;
                tbxCatalogName1.Text = "";
                tbxCatalogURL1.Text = "";
                hlEditCatalog1.Visible = false;
                cbxShowDescription1.Visible = true;
            }
            else
            {
                cbxDeleteCatalog2.Checked = false;
                cbxDeleteCatalog2.Visible = false;
                tbxCatalogName2.Text = "";
                tbxCatalogURL2.Text = "";
                hlEditCatalog2.Visible = false;
                cbxShowDescription2.Visible = true;
            }

            cbxDeleteCatalog1_CheckedChanged(null, null);
        }

        protected void lbxCatalogs1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Entities db = new Entities();

            if (Request.QueryString["a"] == "l")
            {
                var catalog = db.Catalogs.Single(x => x.Name == lbxCatalogs1.SelectedItem.Text);
                cbxDeleteCatalog1.Visible = true;
                cbxDeleteCatalog1.Checked = false;
                tbxCatalogName1.Text = catalog.Name;
                tbxCatalogURL1.Text = catalog.URL;
                hlEditCatalog1.Visible = true;
                cbxShowDescription1.Visible = true;
                cbxShowDescription1.Checked = catalog.ShowDescription;
                hlEditCatalog1.NavigateUrl = "EditCatalog.aspx?cn=" + lbxCatalogs1.SelectedItem.ToString().Replace(" ", "").Replace("&", "");
            }
            else
            {
                var catalog = db.Catalogs.Single(x => x.Name == lbxCatalogs2.SelectedItem.Text);
                cbxDeleteCatalog2.Visible = true;
                cbxDeleteCatalog2.Checked = false;
                tbxCatalogName2.Text = catalog.Name;
                tbxCatalogURL2.Text = catalog.URL;
                hlEditCatalog2.Visible = true;
                cbxShowDescription2.Visible = true;
                cbxShowDescription2.Checked = catalog.ShowDescription;
                hlEditCatalog2.NavigateUrl = "EditCatalog.aspx?cn=" + lbxCatalogs2.SelectedItem.ToString().Replace(" ", "").Replace("&", "");
            }
        }

        protected void cbxDeleteCatalog1_CheckedChanged(object sender, EventArgs e)
        {
            if (Request.QueryString["a"] == "l")
            {
                if (cbxDeleteCatalog1.Checked)
                {
                    tbxCatalogName1.Enabled = false;
                    tbxCatalogURL1.Enabled = false;
                    cbxShowDescription1.Enabled = false;
                }
                else
                {
                    tbxCatalogName1.Enabled = true;
                    tbxCatalogURL1.Enabled = true;
                    cbxShowDescription1.Enabled = true;
                }
            }
            else
            {
                if (cbxDeleteCatalog2.Checked)
                {
                    tbxCatalogName2.Enabled = false;
                    tbxCatalogURL2.Enabled = false;
                    cbxShowDescription2.Enabled = false;
                }
                else
                {
                    tbxCatalogName2.Enabled = true;
                    tbxCatalogURL2.Enabled = true;
                    cbxShowDescription2.Enabled = true;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Entities db = new Entities();

            if (Request.QueryString["a"] == "l")
            {
                if (!cbxDeleteCatalog1.Visible)
                {
                    var newCatalog = new Catalog
                    {
                        Name = tbxCatalogName1.Text,
                        URL = tbxCatalogURL1.Text,
                        Sleave = "Left",
                        ShowDescription = cbxShowDescription1.Checked
                    };
                    db.Catalogs.AddObject(newCatalog);
                    lbxCatalogs1.Items.Add(tbxCatalogName1.Text);
                }
                else
                {
                    if (cbxDeleteCatalog1.Checked)
                    {
                        int iIndex = lbxCatalogs1.SelectedIndex;
                        lbxCatalogs1.Items.RemoveAt(iIndex);
                        var catalog = db.Catalogs.Single(x => x.Name == tbxCatalogName1.Text);
                        db.Catalogs.DeleteObject(catalog);
                    }
                    else
                    {
                        var catalog = db.Catalogs.Single(x => x.Name == lbxCatalogs1.SelectedItem.Text);
                        catalog.Name = tbxCatalogName1.Text;
                        catalog.URL = tbxCatalogURL1.Text;
                        catalog.ShowDescription = cbxShowDescription1.Checked;

                        int iIndex = lbxCatalogs1.SelectedIndex;
                        lbxCatalogs1.Items.RemoveAt(iIndex);
                        lbxCatalogs1.Items.Insert(iIndex, tbxCatalogName1.Text);
                    }
                }
                db.SaveChanges();
                imgRefresh1_Click(null, null);
            }
            else
            {
                if (!cbxDeleteCatalog2.Visible)
                {
                    var newCatalog = new Catalog
                    {
                        Name = tbxCatalogName2.Text,
                        URL = tbxCatalogURL2.Text,
                        Sleave = "Right",
                        ShowDescription = cbxShowDescription2.Checked
                    };
                    db.Catalogs.AddObject(newCatalog);
                    lbxCatalogs1.Items.Add(tbxCatalogName2.Text);
                }
                else
                {
                    if (cbxDeleteCatalog2.Checked)
                    {
                        int iIndex = lbxCatalogs2.SelectedIndex;
                        lbxCatalogs2.Items.RemoveAt(iIndex);
                        var catalog = db.Catalogs.Single(x => x.Name == tbxCatalogName2.Text);
                        db.Catalogs.DeleteObject(catalog);
                    }
                    else
                    {
                        var catalog = db.Catalogs.Single(x => x.Name == lbxCatalogs2.SelectedItem.Text);
                        catalog.Name = tbxCatalogName2.Text;
                        catalog.URL = tbxCatalogURL2.Text;
                        catalog.ShowDescription = cbxShowDescription2.Checked;

                        int iIndex = lbxCatalogs2.SelectedIndex;
                        lbxCatalogs2.Items.RemoveAt(iIndex);
                        lbxCatalogs2.Items.Insert(iIndex, tbxCatalogName2.Text);
                    }
                }
                db.SaveChanges();
                imgRefresh2_Click(null, null);
            }
        }

        protected void imgRefresh1_Click(object sender, ImageClickEventArgs e)
        {
            Entities db = new Entities();
            var sleaveTitleVariable = db.Variables.Single(x => x.Name == "leftSleaveTitle");
            sleaveTitleVariable.Value = tbxListTitle1.Text;
            db.SaveChanges();
            Response.Redirect(Request.RawUrl, true);
        }

        protected void imgRefresh2_Click(object sender, ImageClickEventArgs e)
        {
            Entities db = new Entities();
            var sleaveTitleVariable = db.Variables.Single(x => x.Name == "rightSleaveTitle");
            sleaveTitleVariable.Value = tbxListTitle2.Text;
            db.SaveChanges();
            Response.Redirect(Request.RawUrl, true);
        }
    }
}