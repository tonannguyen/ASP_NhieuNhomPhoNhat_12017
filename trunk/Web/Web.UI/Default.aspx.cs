using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Model;

namespace Web.UI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["logined"] != null)
            {
                name.Text = "Welcome";
            }
            else
                Response.Redirect("http://google.com");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("logined");
            Response.Redirect("~/Login.aspx");
        }
    }
}