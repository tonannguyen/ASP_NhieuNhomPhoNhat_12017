using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Model;

namespace Web.UI
{
    public partial class Root : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // get user
            using (MasterDbContext db = new MasterDbContext())
            {
                try
                {
                    var id = Convert.ToInt32(Session["logined"].ToString()); ;
                    var item = db.Employees.Find(id);
                    if (item != null)
                    {
                        avt.Attributes["src"] = "/Uploads/Staff/" + item.Avata;
                        lblName.Text = item.Name;
                    }
                }
                catch { }
                
                
            }
            

        }
    }
}