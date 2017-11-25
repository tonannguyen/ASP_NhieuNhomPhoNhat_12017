using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Model
{
    public class Flower
    {
        [Key]
        public int ID { get; set; }
        public int TypeID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }

        //mapping
        public virtual Type Type { get; set; }
        public virtual ICollection<Item> Items { get; set; }

        public Flower()
        {
            this.Name = "";
            this.Price = 0;
            this.Quantity = 0;
            this.Image = "";
            this.Description = "";
            this.CreatedTime = DateTime.Now;
            this.UpdatedTime = DateTime.Now;
            this.Items = new HashSet<Item>();
        }

    }
}
