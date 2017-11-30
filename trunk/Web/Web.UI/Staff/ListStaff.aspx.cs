using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UI
{
    public partial class ListStaff : System.Web.UI.Page
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
                        "st.ID AS ID",
                        "st.Name AS 'Name'",
                        "st.Phone AS 'Phone'",
                        "st.Adress AS 'Adress'",
                        "pos.Value AS 'Position'",
                        "st.Salary AS 'Salary'",
                        "st.Bonus AS 'Bonus'",
                        "st.CreatedTime AS 'Created Time'",
                        "st.UpdatedTime AS 'Updated Time'",
                    };
                    string query = "select " + String.Join(",", selectedCol) + " from Employees st INNER JOIN Positions pos ON st.PositionID = pos.ID where st.Active = 1";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(data);

                    GridViewStaff.DataSource = data;
                    GridViewStaff.DataBind();

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
    }
}