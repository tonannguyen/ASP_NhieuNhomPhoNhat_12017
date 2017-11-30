using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Model
{
    public class Position
    {
        [Key]
        public int ID { get; set; }
        public string Value { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public bool Active { get; set; }


        //mapping
        public virtual ICollection<Employee> Employee { get; set; }

        public Position()
        {
            this.Value = "";
            this.CreatedTime = DateTime.Now;
            this.UpdatedTime = DateTime.Now;
            this.Active = true;

        }
    }
}
