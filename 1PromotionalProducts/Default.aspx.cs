using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1PromotionalProducts
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["visited"] == null)
            {
                flashautoplay.Visible = true;
                flashnoauto.Visible = false;
                Response.Cookies["visited"].Value = "visited";
                Response.Cookies["visited"].Expires = DateTime.Now.AddYears(1);
            }
            else
            {
                flashautoplay.Visible = false;
                flashnoauto.Visible = true;
            }
        }
    }
}