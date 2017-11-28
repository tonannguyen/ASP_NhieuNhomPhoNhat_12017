using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Model;

namespace Web.UI
{
    public partial class DetailFlower : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["logined"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            // get data source
            

            // kiem tra neu co GET ID thi load data va set data
            if (Request.QueryString["ID"] != null && string.IsNullOrEmpty(Request.QueryString["ID"].ToString()) == false && Request.HttpMethod == "GET")
            {
                // get data
                using (MasterDbContext db = new MasterDbContext())
                {
                    var id = Convert.ToInt32(Request.QueryString["ID"].ToString());
                    var item = db.Flowers.Find(id);
                    var type = db.Types.Find(item.TypeID);

                    if (item != null)
                    {
                        // set data
                        image.Attributes["src"] = "/Uploads/Flowers/" + item.Image;
                        lblName.Text = item.Name;
                        lblType.Text = type.Name;
                        lblPrice.Text = item.Price.ToString();
                        lblQuantity.Text = item.Quantity.ToString();
                        lblDescription.Text = item.Description;
                    }
                    else
                    {
                        Response.Redirect("~/ListFlower.aspx");
                    }
                }
            }

        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ListFlower.aspx");
        }


    }

}