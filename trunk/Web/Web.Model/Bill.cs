using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Model
{
    public class Bill
    {
        [Key]
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int Type { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; }
        public string CreatedTime { get; set; }
        public string UpdatedTime { get; set; }

        public bool Active { get; set; }


        //mapping
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Item> Items { get; set; }

        public Bill()
        {
			this.EmployeeID = 0;
			this.Type = 0;
			this.Quantity = 0;
			this.Price = 0;
			this.Items = new HashSet<Item>();
            this.CreatedTime = DateTime.Now.ToString();
            this.UpdatedTime = DateTime.Now.ToString();
            this.Active = true;
        }
		public string saveBill(int employeeID, int type)
		{
			this.EmployeeID = employeeID;
			this.Quantity = 0;
			this.Price = 0;
			this.Type = type;
			this.CreatedTime = DateTime.Now.ToString();
			this.UpdatedTime = DateTime.Now.ToString();
			this.Active = true;
			return this.CreatedTime;
		}

	}
}
