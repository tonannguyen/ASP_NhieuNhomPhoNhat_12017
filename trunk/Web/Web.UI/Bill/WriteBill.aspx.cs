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
                double type, id;

				if (!IsPostBack)
                {
                    staffList.DataSource = GetStaff();
                    staffList.DataValueField = "ID";
                    staffList.DataTextField = "Name";
                    staffList.DataBind();
                    //// type
                    typeList.DataSource = GetType();
                    typeList.DataValueField = "ID";
                    typeList.DataTextField = "Name";
                    typeList.DataBind();
					//// flower
					flowerList.DataSource = GetFlower(Convert.ToDouble(typeList.Text));
					flowerList.DataValueField = "ID";
					flowerList.DataTextField = "Name";
					flowerList.DataBind();
					//// price
					price.InnerHtml = GetPriceFlower(Convert.ToDouble(flowerList.Text)) + " VNĐ";

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
                string query = "select * from Employees  where Active = 1";
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

        private DataTable GetFlower(double type)
        {

            DataTable data = new DataTable();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterDbContext"].ToString());
            try
            {
                con.Open();
                string query = "select * from Flowers where TypeID = "+type+ " AND Active = 1";
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
        

        private Double GetPriceFlower(double id)
        {

            double result = 0 ;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterDbContext"].ToString());
            try
            {
                con.Open();
                string query = "select Price from Flowers where ID = " + id + " AND Active = 1";
                SqlCommand cmd = new SqlCommand(query, con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    bool success = dr.Read();
                    if (success)
                    {
                        result = Convert.ToDouble(dr.GetValue(0));
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
                string query = "select * from Types where Active = 1";

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
            flowerList.DataSource = GetFlower(Convert.ToDouble(typeList.Text));
            flowerList.DataValueField = "ID";
            flowerList.DataTextField = "Name";
            flowerList.DataBind();
        }

        protected void flowerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            price.InnerHtml = GetPriceFlower(Convert.ToDouble(flowerList.Text))+ " VNĐ";

			if (quantity.ToString() != null)
            {
                totalPrice.InnerHtml =( GetPriceFlower(Convert.ToDouble(flowerList.Text)) * Convert.ToDouble(quantity.Text))+ " VNĐ";
			}
        }

        protected void quantity_TextChanged(object sender, EventArgs e)
        {
			try
			{
				totalPrice.InnerHtml = "" + (GetPriceFlower(Convert.ToDouble(flowerList.Text)) * Convert.ToDouble(quantity.Text)) + " VNĐ";
			}
			catch { }
        }

		protected void writeBill(object sender, EventArgs e)
		{
			
		}
		protected void saveBill(object sender, EventArgs e)
		{

		}

	}
}