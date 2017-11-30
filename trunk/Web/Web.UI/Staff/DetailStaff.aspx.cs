using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Model;

namespace Web.UI.Staff
{
    public partial class DetailStaff : System.Web.UI.Page
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
                    var item = db.Employees.Find(id);
                    var pos = db.Positions.Find(item.PositionID);

                    if (item != null)
                    {
                        // set data
                        image.Attributes["src"] = "/Uploads/Staff/" + item.Avata;
                        lblName.Text = item.Name;
                        lblPhone.Text = item.Name;
                        lblAdress.Text = item.Name;
                        lblPositon.Text = pos.Value;
                        lblSalary.Text = item.Salary.ToString();
                        
                    }
                    else
                    {
                        Response.Redirect("~/ListStaff.aspx");
                    }
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Staff/ListStaff.aspx");
        }

    }
}