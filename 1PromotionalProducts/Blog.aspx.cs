using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace _1PromotionalProducts
{
    public partial class Blog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                admin.Visible = true;
            }
            else
            {
                admin.Visible = false;
            }
            int iPageNumber = 0;
            if (Request.QueryString["p"] != null)
            {
                iPageNumber = Convert.ToInt32(Request.QueryString["p"]);
            }
            DataLayer dl = new DataLayer();
            int iMaxPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(dl.GetPostCount()) / 5m));
            pageNav1.NumPages = iMaxPages;
            pageNav2.NumPages = iMaxPages;
            DataTable dtPosts = dl.GetPostsBy_Page(iPageNumber);
            if (dtPosts.Rows.Count > 0)
            {
                blogs.InnerHtml = "";
                blogs.Controls.Add(new LiteralControl("<hr /><br />"));
            }
            foreach (DataRow dr in dtPosts.Rows)
            {
                blogs.Controls.Add(new LiteralControl("<div style=\"font-size:25px;\"><a href=\"Post.aspx?bid=" + dr.ItemArray[0].ToString() + "\">" + dr.ItemArray[2].ToString() + "</a></div>" + Convert.ToDateTime(dr.ItemArray[1]).ToString("D") + "<br /><br/>"));
                string sPostSummary = dr.ItemArray[3].ToString();
                if (sPostSummary.Contains('~'))
                {
                    sPostSummary = sPostSummary.Remove(sPostSummary.IndexOf('~'));
                }
                blogs.Controls.Add(new LiteralControl(sPostSummary + "<br /><a href=\"Post.aspx?bid=" + dr.ItemArray[0].ToString() + "\">(Read More)</a><br /><br /><hr /><br />"));
            }
        }

        protected void btnAddNewBlog_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEditPost.aspx", true);
        }
    }
}