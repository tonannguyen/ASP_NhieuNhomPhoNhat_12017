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
    public partial class UpdateFlower : System.Web.UI.Page
    {
        List<string> acceptedExt = new List<string>
        {
            ".jpg", ".png", ".gif", ".jpeg" 
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["logined"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            // get data source
            typeList.DataSource = GetType();
            typeList.DataValueField = "ID";
            typeList.DataTextField = "Name";
            typeList.DataBind();

            // kiem tra neu co GET ID thi load data va set data
            if (Request.QueryString["ID"] != null && string.IsNullOrEmpty(Request.QueryString["ID"].ToString()) == false && Request.HttpMethod == "GET")
            {
                // get data
                using (MasterDbContext db = new MasterDbContext())
                {
                    var id = Convert.ToInt32(Request.QueryString["ID"].ToString());
                    var item = db.Flowers.Find(id);

                    if (item != null)
                    {
                        // set data
                        txtName.Text = item.Name;
                        txtPrice.Text = item.Price.ToString();
                        txtQuantity.Text = item.Quantity.ToString();
                        typeList.SelectedIndex = typeList.Items.IndexOf(typeList.Items.FindByText(item.TypeID.ToString()));
                        description.InnerText = item.Description;
                    }
                    else
                    {
                        Response.Redirect("~/ListFlower.aspx");
                    }
                }
            }
        }

        protected void btnSaveClick(object sender, EventArgs e)
        {
            // if co ID thi sua, else add
            using (MasterDbContext db = new MasterDbContext())
            {
                if (Request.QueryString["ID"] != null && string.IsNullOrEmpty(Request.QueryString["ID"].ToString()) == false)
                {
                    // edit
                    var id = Convert.ToInt32(Request.QueryString["ID"].ToString());
                    var item = db.Flowers.Find(id);

                    if (item != null)
                    {
                        // set data
                        item.Name = txtName.Text;
                        item.Price = decimal.Parse(txtPrice.Text);
                        item.Quantity = Convert.ToInt32(txtQuantity.Text);
                        item.TypeID = Convert.ToInt32(typeList.SelectedValue);
                        item.Description = description.InnerText;


                        // upload solving
                        if (image.HasFile)
                        {
                            // kiem tra neu file ko fai file hinh
                            var ext = Path.GetExtension(image.PostedFile.FileName).ToLower();

                            if (acceptedExt.IndexOf(ext) < 0)
                                Response.Redirect("~/Flower/ListFlower.aspx");

                            // new file name
                            Random rd = new Random();
                            var fileName = DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss_") + Common.HashMD5(rd.Next(1, 9999999).ToString()) + ext;

                            // save file
                            image.PostedFile.SaveAs(HttpContext.Current.Server.MapPath("~/Uploads/Flowers/" + fileName));

                            item.Image = fileName;
                        }

                        // save
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();

                        Response.Redirect("~/Flower/ListFlower.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Flower/ListFlower.aspx");
                    }
                }
                else
                {

                    var flower = new Flower();
                    flower.Name = txtName.Text;
                    flower.Price = decimal.Parse(txtPrice.Text);
                    flower.Quantity = Convert.ToInt32(txtQuantity.Text);
                    flower.TypeID = Convert.ToInt32(typeList.SelectedValue);
                    flower.Description = description.InnerText;


                    // upload solving
                    if (image.HasFile)
                    {
                        // kiem tra neu file ko fai file hinh
                        var ext = Path.GetExtension(image.PostedFile.FileName).ToLower();

                        if (acceptedExt.IndexOf(ext) < 0)
                            Response.Redirect("~/Flower/ListFlower.aspx");

                        // new file name
                        Random rd = new Random();
                        var fileName = DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss_") + Common.HashMD5(rd.Next(1, 9999999).ToString()) + ext;

                        // save file
                        image.PostedFile.SaveAs(HttpContext.Current.Server.MapPath("~/Uploads/Flowers/" + fileName));

                        flower.Image = fileName;


                    }

                    // save
                    db.Flowers.Add(flower);
                    db.SaveChanges();

                    Response.Redirect("~/Flower/ListFlower.aspx");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            description.InnerText = "";
            typeList.SelectedIndex = 0;
        }

        private DataTable GetType()
        {

            DataTable data = new DataTable();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterDbContext"].ToString());


            try
            {
                con.Open();
                string query = "select * from Types";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(data);
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }

            return data;
        }
    }
}