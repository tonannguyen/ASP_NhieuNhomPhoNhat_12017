﻿using System;
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

                if(IsPostBack)
                try {
                    load_data();
                }
                catch { }
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
                    try
                    {
                        flowerList.DataSource = GetFlower(Convert.ToDouble(typeList.Text));
                        flowerList.DataValueField = "ID";
                        flowerList.DataTextField = "Name";
                        flowerList.DataBind();
                        price.InnerHtml = GetPriceFlower(Convert.ToDouble(flowerList.Text)) + " VNĐ";
                    }
                    catch { }
					//// price
					

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
		private Double GetBillID(string createTime)
		{

			double result = 0;
			SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterDbContext"].ToString());
			try
			{
				con.Open();
				string query = "select ID from Bills where Active = 1 AND CreatedTime = '"+ createTime + "'";
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

        private DataTable GetItems(int billID)
        {

            DataTable data = new DataTable();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterDbContext"].ToString());


            try
            {
                con.Open();
                string query = "select t1.FlowerID , t1.Quantity, t2.Price , ((t1.Quantity)*(t2.Price)) AS 'ToTal Price'  from Items t1 JOIN Flowers t2 ON t1.FlowerID = t2.ID  where t1.Active = 1 AND t1.BillID =" + billID;

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
                try
                {
                    totalPrice.InnerHtml = (GetPriceFlower(Convert.ToDouble(flowerList.Text)) * Convert.ToDouble(quantity.Text)) + " VNĐ";
                }
                catch { }
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

                if (lb_staff.Text == "")
                {
                    lb_staff.Text = staffList.SelectedItem.ToString();
                    lb_transaction.Text = transaction_type.SelectedItem.ToString();
                    using (MasterDbContext db = new MasterDbContext())
                    {
                        try
                        {
                            var bill = new Bill();
                            string timeCreate = bill.saveBill(Convert.ToInt32(staffList.SelectedValue), Convert.ToInt32(transaction_type.SelectedValue));
                            db.Bills.Add(bill);
                            db.SaveChanges();
                            double billId = GetBillID(timeCreate);
                            billID_hint.Value = billId.ToString();
                            int id_bill = Convert.ToInt32(billID_hint.Value);
                            var item = new Item();
                            item.BillID = id_bill;
                            item.Quantity = Convert.ToInt32(quantity.Text);
                            item.FlowerID = Convert.ToInt32(flowerList.SelectedValue);
                            db.Items.Add(item);
                            db.SaveChanges();
                            load_data();
                        }
                        catch { }
                    }
                }
                else
                {
                    try
                    {
                        using (MasterDbContext db = new MasterDbContext())
                        {
                            int id_bill = Convert.ToInt32(billID_hint.Value);
                            var item = new Item();
                            item.BillID = id_bill;
                            item.Quantity = Convert.ToInt32(quantity.Text);
                            item.FlowerID = Convert.ToInt32(flowerList.SelectedValue);
                            db.Items.Add(item);
                            db.SaveChanges();
                            load_data();
                        }
                    }
                    catch { }
                }
		}

        private void load_data()
        {
            DataTable dataItems = GetItems(Convert.ToInt32(billID_hint.Value));
            if (Session["logined"] != null)
            {
              
                try
                {
                    gv_change.DataSource = dataItems;
                    gv_change.DataBind();

                }
                catch
                {

                }

            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }

        }
	}
}