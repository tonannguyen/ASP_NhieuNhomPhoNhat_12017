using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Model
{
    public class Item
    {
        [Key]
        public int ID { get; set; }
        public int BillID { get; set; }
        public int FlowerID { get; set; }
        public float Quantity { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }

        //mapping
        public virtual Bill Bill { get; set; }
        public virtual Flower Flower { get; set; }

        public Item()
        {
            this.BillID = 1;
            this.Quantity = 0;
            this.CreatedTime = DateTime.Now;
            this.UpdatedTime = DateTime.Now;
            
           
        }

    }
}
