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
    public partial class WriteBill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["logined"] != null)
            {
                int type, id;
                if (!IsPostBack)
                {
                    staffList.DataSource = GetStaff();
                    staffList.DataValueField = "ID";
                    staffList.DataTextField = "Name";
                    staffList.DataBind();
                    ////
                    typeList.DataSource = GetType();
                    typeList.DataValueField = "ID";
                    typeList.DataTextField = "Name";
                    typeList.DataBind();
                }
                ////
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        private DataTable GetStaff()
        {

            DataTable data = new DataTable();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterDbContext"].ToString());


            try
            {
                con.Open();
                string query = "select * from Employees";
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

        private DataTable GetFlower(int type)
        {

            DataTable data = new DataTable();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterDbContext"].ToString());
            try
            {
                con.Open();
                string query = "select * from Flowers where TypeID = "+type;
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
        

        private String GetPriceFlower(int id)
        {

            String result = "";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterDbContext"].ToString());
            try
            {
                con.Open();
                string query = "select Price from Flowers where ID = " + id;
                SqlCommand cmd = new SqlCommand(query, con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    bool success = dr.Read();
                    if (success)
                    {
                        result = dr.GetValue(0).ToString();
                    }
                }
                
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }

            return result;
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



        protected void typeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            flowerList.DataSource = GetFlower(Convert.ToInt32(typeList.Text));
            flowerList.DataValueField = "ID";
            flowerList.DataTextField = "Name";
            flowerList.DataBind();
        }

        protected void flowerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            price.InnerHtml = GetPriceFlower(Convert.ToInt32(flowerList.Text))+"";
            if (quantity.ToString() != null)
            {
                totalPrice.InnerHtml = "" + price.ToString();
            }
        }

        protected void quantity_TextChanged(object sender, EventArgs e)
        {
           // totalPrice.InnerHtml = "" + (Convert.ToInt32(price.ToString()) * Convert.ToInt32(quantity.ToString()));
        }
    }
}