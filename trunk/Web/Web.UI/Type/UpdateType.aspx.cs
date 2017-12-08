using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Model;

namespace Web.UI
{
    public partial class UpdateType : System.Web.UI.Page
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
                    var item = db.Types.Find(id);

                    if (item != null)
                    {
                        // set data
                        txtName.Text = item.Name;
                       
                    }
                    else
                    {
                        Response.Redirect("~/Type/List.aspx");
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
                    var item = db.Types.Find(id);

                    if (item != null)
                    {
                        // set data
                        item.Name = txtName.Text;
                        item.UpdatedTime = DateTime.Now;
                        // save
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();

                        Response.Redirect("~/Type/List.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Type/List.aspx");
                    }
                }
                else
                {

                    var type = new Web.Model.Type();
                    type.Name = txtName.Text;
                    type.Active = true;
                    
                    // save
                    db.Types.Add(type);
                    db.SaveChanges();

                    Response.Redirect("~/Type/List.aspx");
                }
            }
        }
    }
}