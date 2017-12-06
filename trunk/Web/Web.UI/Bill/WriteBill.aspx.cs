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
		List<ClassWriteBill> listData;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["logined"] != null)
            {
                double type, id;

				if (!IsPostBack)
                {
					listData = new List<ClassWriteBill>();
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

			if (lb_staff.Text == "")
			{
				lb_staff.Text = staffList.SelectedItem.ToString();
				lb_transaction.Text = transaction_type.SelectedItem.ToString();
				lb_fl_Type.Text = typeList.SelectedItem.ToString();
				lb_fl_Name.Text = flowerList.SelectedItem.ToString();
				lb_quantity.Text = quantity.Text;
				lb_Price.Text = price.InnerText;
				lb_TotalPrice.Text = totalPrice.InnerText;
				using (MasterDbContext db = new MasterDbContext())
				{
					var bill = new Bill();
					string timeCreate = bill.saveBill(Convert.ToInt32(staffList.SelectedValue),Convert.ToInt32(transaction_type.SelectedValue));
					db.Bills.Add(bill);
					db.SaveChanges();
					double billId = GetBillID(timeCreate);
					billID_hint.Value = billId.ToString();

				}
			}
			else
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
				}

			}



		}


	}
}


//ClassWriteBill cellData = new ClassWriteBill(
//	typeList.SelectedItem.ToString(),
//	flowerList.SelectedItem.ToString(),
//	quantity.Text,
//	price.InnerText,
//	totalPrice.InnerText
//	);
//ClassWriteBill cellData2 = new ClassWriteBill();
//listData.Add(cellData2);


//				for (int i = 1; i <= listData.Count; i++)
//				{
//					// Create new row and add it to the table.
//					TableRow tRow = new TableRow();
//tb_change.Rows.Add(tRow);
//						TableCell type_cell = new TableCell();
//TableCell name_cell = new TableCell();
//TableCell quantity_cell = new TableCell();
//TableCell price_cell = new TableCell();
//TableCell total_price_cell = new TableCell();
//listData.ForEach(x => {
//						name_cell.Text = x.name;
//						type_cell.Text = x.type;
//						quantity_cell.Text = x.quantity;
//						price_cell.Text = x.price;
//						total_price_cell.Text = x.totalPrice;
//					});
//						tRow.Cells.Add(type_cell);
//						tRow.Cells.Add(name_cell);
//						tRow.Cells.Add(quantity_cell);
//						tRow.Cells.Add(price_cell);
//						tRow.Cells.Add(total_price_cell);
					
//				}