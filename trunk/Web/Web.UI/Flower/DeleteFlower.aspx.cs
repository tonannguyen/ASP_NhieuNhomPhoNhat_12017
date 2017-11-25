using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Model;

namespace Web.UI
{
    public partial class DeleteFlower : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["logined"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            // kiem tra neu co GET ID thi load data va set data
            if (Request.QueryString["ID"] != null && string.IsNullOrEmpty(Request.QueryString["ID"].ToString()) == false && Request.HttpMethod == "GET")
            {
                using (MasterDbContext db = new MasterDbContext())
                {
                    var id = Convert.ToInt32(Request.QueryString["ID"].ToString());
                    var item = db.Flowers.Find(id);

                    if (item != null)
                    {
                        // set data
                        db.Flowers.Remove(item);
                        db.SaveChanges();
                        Response.Redirect("~/Flower/ListFlower.aspx");
                    }
                    
                }
            }
            
        }
    }
}