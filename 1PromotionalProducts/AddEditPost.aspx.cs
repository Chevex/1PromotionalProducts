using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace _1PromotionalProducts
{
    public partial class AddEditPost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Default.aspx", true);
            }

            if (!this.IsPostBack)
            {
                if (Request.QueryString["bid"] != null)
                {
                    cbxDeletePost.Visible = true;
                    int iPostID = Convert.ToInt32(Request.QueryString["bid"]);
                    DataLayer dl = new DataLayer();
                    DataTable dtPost = dl.GetPost(iPostID);
                    tbxTitle.Text = dtPost.Rows[0].ItemArray[2].ToString();
                    //rteBody.Value = dtPost.Rows[0].ItemArray[3].ToString();
                }
                else
                {
                    cbxDeletePost.Visible = false;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataLayer dl = new DataLayer();
            if (Request.QueryString["bid"] != null)
            {
                int iPostID = Convert.ToInt32(Request.QueryString["bid"]);
                if (cbxDeletePost.Checked)
                {
                    dl.DeletePost(iPostID);
                    Response.Redirect("Blog.aspx", true);
                }
                else
                {
                    //dl.UpdatePost(iPostID, tbxTitle.Text, rteBody.Value);
                    Response.Redirect("Post.aspx?bid=" + iPostID.ToString(), true);
                }
            }
            else
            {
                DateTime dtDate = DateTime.Now;
                //dl.AddPost(dtDate, tbxTitle.Text, rteBody.Value);
                DataSet ds = dl.CustomSelectQuery("select BlogID from [1ppBlogs] where Title='" + tbxTitle.Text.Replace("'", "''") + "' AND Date='" + dtDate.ToString() + "'");
                Response.Redirect("Post.aspx?bid=" + ds.Tables[0].Rows[0].ItemArray[0].ToString(), true);
            }
        }
    }
}