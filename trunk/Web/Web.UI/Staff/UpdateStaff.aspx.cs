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

namespace Web.UI.Staff
{
    public partial class UpdateStaff : System.Web.UI.Page
    {
        List<string> acceptedExt = new List<string>
        {
            ".jpg", ".png", ".gif", ".jpeg"
        };
        protected void Page_Load(object sender, EventArgs e)
        {
            //set role
            using (MasterDbContext db = new MasterDbContext())
            {
                //find current user
                int idUser = Convert.ToInt32(Session["logined"].ToString()); ;
                var user = db.Employees.Find(idUser);
                //find role 
                var role = db.Positions.Find((int)user.PositionID);

                // check session
                if (Session["logined"] != null )
                {
                    // check role ?= Admin
                    if(role.Value != "Admin")
                        Response.Redirect("~/Staff/ListStaff.aspx");
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }

            }
            
            if (!Page.IsPostBack)
            {
                // get data source
                PositionList.DataSource = GetPosition();
                PositionList.DataValueField = "ID";
                PositionList.DataTextField = "Value";
                PositionList.DataBind();

                if (Request.QueryString["ID"] != null && string.IsNullOrEmpty(Request.QueryString["ID"].ToString()) == false && Request.HttpMethod == "GET")
                {
                    // get data
                    using (MasterDbContext db = new MasterDbContext())
                    {
                        var id = Convert.ToInt32(Request.QueryString["ID"].ToString());
                        var item = db.Employees.Find(id);

                        if (item != null)
                        {

                            // set data
                            txtName.Text = item.Name;
                            txtPass.Text = item.Password;
                            txtPhone.Text = item.Phone;
                            txtAdress.Text = item.Adress;

                            PositionList.SelectedIndex = PositionList.Items.IndexOf(PositionList.Items.FindByText(item.PositionID.ToString()));
                            txtSalary.Text = item.Salary.ToString();
                        }
                        else
                        {
                            Response.Redirect("~/ListStaff.aspx");
                        }
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
                    var item = db.Employees.Find(id);

                    if (item != null)
                    {
                        if (txtPass.Text != txtRePass.Text)
                        {
                            Response.Redirect("~/Staff/UpdateStaff.aspx");
                            return;
                        }

                        // set data
                        item.Name = txtName.Text;
                        item.Password = txtPass.Text;
                        item.Phone = txtPhone.Text;
                        item.Adress = txtAdress.Text;
                        item.PositionID = Convert.ToInt32(PositionList.SelectedValue);
                        item.Salary = decimal.Parse(txtSalary.Text);
                        item.UpdatedTime = DateTime.Now;
                        // upload solving
                        if (avatar.HasFile)
                        {
                            // kiem tra neu file ko fai file hinh
                            var ext = Path.GetExtension(avatar.PostedFile.FileName).ToLower();

                            if (acceptedExt.IndexOf(ext) < 0)
                                Response.Redirect("~/Staff/ListStaff.aspx");

                            // new file name
                            Random rd = new Random();
                            var fileName = DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss_") + Common.HashMD5(rd.Next(1, 9999999).ToString()) + ext;

                            // save file
                            avatar.PostedFile.SaveAs(HttpContext.Current.Server.MapPath("~/Uploads/Staff/" + fileName));

                            item.Avata = fileName;
                        }

                        // save
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();

                        Response.Redirect("~/Staff/ListStaff.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Staff/ListStaff.aspx");
                    }
                }
                else
                {
                    if (txtPass.Text != txtRePass.Text)
                    {
                        Response.Redirect("~/Staff/UpdateStaff.aspx");
                        return;
                    }


                    var staff = new Employee();
                    staff.Name = txtName.Text;
                    staff.Password = txtPass.Text;
                    staff.Phone = txtPhone.Text;
                    staff.Adress = txtAdress.Text;
                    staff.PositionID = Convert.ToInt32(PositionList.SelectedValue);
                    staff.Salary = decimal.Parse(txtSalary.Text);


                    // upload solving
                    if (avatar.HasFile)
                    {
                        // kiem tra neu file ko fai file hinh
                        var ext = Path.GetExtension(avatar.PostedFile.FileName).ToLower();

                        if (acceptedExt.IndexOf(ext) < 0)
                            Response.Redirect("~/Staff/ListStaff.aspx");

                        // new file name
                        Random rd = new Random();
                        var fileName = DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss_") + Common.HashMD5(rd.Next(1, 9999999).ToString()) + ext;

                        // save file
                        avatar.PostedFile.SaveAs(HttpContext.Current.Server.MapPath("~/Uploads/Staff/" + fileName));

                        staff.Avata = fileName;


                    }

                    // save
                    db.Employees.Add(staff);
                    db.SaveChanges();

                    Response.Redirect("~/Staff/ListStaff.aspx");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtAdress.Text = "";
            txtPass.Text = "";
            txtPhone.Text = "";
            txtSalary.Text = "";
            PositionList.SelectedIndex = 0;
        }

        private DataTable GetPosition()
        {

            DataTable data = new DataTable();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterDbContext"].ToString());


            try
            {
                con.Open();
                string query = "select * from Positions";
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