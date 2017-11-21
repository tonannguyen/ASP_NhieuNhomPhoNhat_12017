using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Model
{
    public class Type
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }

        //mapping
        public virtual ICollection<Flower> Flowers { get; set; }
        public Type()
        {
            this.Name = "";
            this.CreatedTime = DateTime.Now;
            this.UpdatedTime = DateTime.Now;
            this.Flowers = new HashSet<Flower>();
        }
    }
}
