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
        public float Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }

        public bool Active { get; set; }


        //mapping
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Item> Items { get; set; }

        public Bill()
        {
            this.Type = 0;
            this.Quantity = 0;
            this.Price = 0;
            this.Items = new HashSet<Item>();
            this.CreatedTime = DateTime.Now;
            this.UpdatedTime = DateTime.Now;
            this.Active = true;
        }

    }
}
