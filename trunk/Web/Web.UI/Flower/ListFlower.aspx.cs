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
    public partial class ListFlower : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["logined"] != null)
            {
                DataTable data = new DataTable();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterDbContext"].ToString());


                try
                {
                    con.Open();
                    string[] selectedCol = new string[] {
                        "fl.ID AS ID",
                        "fl.Name AS 'Name'",
                        "tp.Name AS 'Type'",
                        "fl.Price AS 'Price'",
                        "fl.Quantity AS 'Quantity'",
                        "fl.Description AS 'Description'",
                        "fl.CreatedTime AS 'Created Time'",
                        "fl.UpdatedTime AS 'Updated Time'",
                    };
                    string query = "select " + String.Join(",", selectedCol) + " from Flowers fl INNER JOIN Types tp ON fl.TypeID = tp.ID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(data);

                    GridViewListFlower.DataSource = data;
                    GridViewListFlower.DataBind();
                }
                catch
                {

                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}