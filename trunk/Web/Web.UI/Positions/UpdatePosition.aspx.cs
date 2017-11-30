using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Model;

namespace Web.UI.Positons
{
    public partial class UpdatePostion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["logined"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (Request.QueryString["ID"] != null && string.IsNullOrEmpty(Request.QueryString["ID"].ToString()) == false && Request.HttpMethod == "GET")
            {
                // get data
                using (MasterDbContext db = new MasterDbContext())
                {
                    var id = Convert.ToInt32(Request.QueryString["ID"].ToString());
                    var item = db.Positions.Find(id);

                    if (item != null)
                    {
                        // set data
                        txtName.Text = item.Value;

                    }
                    else
                    {
                        Response.Redirect("~/Positions/ListPosition.aspx");
                    }
                }
            }
        }



        protected void btnSaveClick(object sender, EventArgs e)
        {
            using (MasterDbContext db = new MasterDbContext())
            {
                if (Request.QueryString["ID"] != null && string.IsNullOrEmpty(Request.QueryString["ID"].ToString()) == false)
                {
                    // edit
                    var id = Convert.ToInt32(Request.QueryString["ID"].ToString());
                    var item = db.Positions.Find(id);

                    if (item != null)
                    {
                        // set data
                        item.Value = txtName.Text;

                        // save
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();

                        Response.Redirect("~/Positions/ListPosition.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Positions/ListPosition.aspx");
                    }
                }
                else
                {

                    var pos = new Web.Model.Position();
                    pos.Value = txtName.Text;
                    pos.Active = true;

                    // save
                    db.Positions.Add(pos);
                    db.SaveChanges();

                    Response.Redirect("~/Positions/ListPosition.aspx");
                }
            }
        }
    }

    

}