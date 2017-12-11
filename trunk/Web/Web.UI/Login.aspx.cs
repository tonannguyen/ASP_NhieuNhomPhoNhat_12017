using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Web.UI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterDbContext"].ToString());

            con.Open();
            string query = "select count(*) from Employees where Name='" + txtUserName.Text + "' and Password='" + Common.HashPassword(txtPassword.Text, "ps") + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            string output = cmd.ExecuteScalar().ToString();

            if (output == "1")
            {
                string query1 = "select ID from Employees where Name='" + txtUserName.Text + "'";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                using (SqlDataReader dr = cmd1.ExecuteReader())
                {
                    bool success = dr.Read();
                    if (success)
                    {
                        Session["logined"] = dr.GetValue(0).ToString();
                    }
                }
               
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                Response.Write("Login Faild");
            }
        }
    }
}