using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UI.Type
{
    public partial class ListType : System.Web.UI.Page
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
                    
                    string query = "select * from Types";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(data);

                    
                    GridViewListType.DataSource = data;
                    GridViewListType.DataBind();
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