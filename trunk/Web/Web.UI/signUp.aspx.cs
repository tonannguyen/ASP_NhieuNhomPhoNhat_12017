using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Web.UI
{
    public partial class signUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            SqlConnection con = Common.Connect;

            con.Open();

            // get dât
            string user = "";
            string pass = "";

            // mã hóa pass
            pass = Common.HashPassword(pass, ConfigurationManager.AppSettings["ProtectedKey"].ToString());

            string query = string.Format("INSERT INTO ??(??) VALUES ('{0}', '{1}')", user, pass);
            

            SqlCommand cmd = new SqlCommand("", con);
        }
    }
}