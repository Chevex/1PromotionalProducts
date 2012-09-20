using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace _1PromotionalProducts
{
    public partial class Post : System.Web.UI.Page
    {
        LinkButton lbtnDelete;
        Random random = new Random();

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
            DataLayer dl = new DataLayer();
            int iPostID = Convert.ToInt32(Request.QueryString["bid"]);
            DataTable dtPost = dl.GetPost(iPostID);
            PostTitle.InnerText = dtPost.Rows[0].ItemArray[2].ToString();
            PostDate.InnerText = Convert.ToDateTime(dtPost.Rows[0].ItemArray[1]).ToString("D");
            PostBody.InnerHtml = dtPost.Rows[0].ItemArray[3].ToString();
            DataTable dtComments = dl.GetComments(iPostID);
            commentcount.InnerText = dtComments.Rows.Count.ToString();
            foreach (DataRow dr in dtComments.Rows)
            {
                comments.Controls.Add(new LiteralControl("<div style=\"background-color:#535684;margin-bottom:5px;padding:5px;\"><table style=\"width:100%;\"><td style=\"text-align:center;vertical-align:top;font-weight:bold;width:20%;border-right:solid 3px #313462;\">"));
                if (dr.ItemArray[4].ToString() != "nosite")
                {
                    comments.Controls.Add(new LiteralControl("<a href=\"" + dr.ItemArray[4].ToString() + "\">"));
                }
                comments.Controls.Add(new LiteralControl(dr.ItemArray[2].ToString()));
                if (dr.ItemArray[4].ToString() != "nosite")
                {
                    comments.Controls.Add(new LiteralControl("</a>"));
                }
                comments.Controls.Add(new LiteralControl("</td><td style=\"vertical-align:top;padding-left:10px;width:70%;\">" + dr.ItemArray[5].ToString() + "<br /><br />" + dr.ItemArray[3].ToString()));
                if (User.Identity.IsAuthenticated)
                {
                    comments.Controls.Add(new LiteralControl("</td><td style=\"vertical-align:middle;border-left:solid 3px #313462;text-align:center;width:10%;\">"));
                    lbtnDelete = new LinkButton();
                    lbtnDelete.ID = dr.ItemArray[0].ToString();
                    lbtnDelete.Text = "X";
                    lbtnDelete.CausesValidation = false;
                    lbtnDelete.OnClientClick = "return confirm('Are you sure you want to delete this comment?');";
                    lbtnDelete.Click += new EventHandler(lbtnDelete_Click);
                    comments.Controls.Add(lbtnDelete);
                }
                comments.Controls.Add(new LiteralControl("</td></tr></table></div>"));
            }

            if (!this.IsPostBack)
            {
                Session["CaptchaImageText"] = CaptchaImage.GenerateRandomCode(random);
            }
        }

        void lbtnDelete_Click(object sender, EventArgs e)
        {
            int iCommentID = Convert.ToInt32(((LinkButton)(sender)).ID);
            DataLayer dl = new DataLayer();
            dl.DeleteComment(iCommentID);
            Response.Redirect(Request.RawUrl, true);
        }

        protected void btnAddComment_Click(object sender, EventArgs e)
        {
            if (tbxCode.Text == Session["CaptchaImageText"].ToString())
            {
                int iBlogID = Convert.ToInt32(Request.QueryString["bid"]);
                string sWebsite = tbxWebsite.Text;
                if (tbxWebsite.Text.Length == 0)
                {
                    sWebsite = "nosite";
                }
                DataLayer dl = new DataLayer();
                dl.AddComment(tbxAuthor.Text, iBlogID, DateTime.Now, sWebsite, tbxComment.Text.Replace("\r", "<br />").Replace("\n", ""));
                Response.Redirect(Request.RawUrl, true);
            }
            else
            {
                CustomValidator1.IsValid = false;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string sID = Request.QueryString["bid"];
            Response.Redirect("AddEditPost.aspx?bid=" + sID, true);
        }
    }
}