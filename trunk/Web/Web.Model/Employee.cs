using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Model
{
    public class Employee
    {

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Avata { get; set; }
        public int PositionID { get; set; }
        public decimal Salary { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public bool Active { get; set; }

        //mapping
        public virtual Position Position { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }

        public Employee()
        {
            this.Name = "";
            this.Password = "";
            this.Phone = "";
            this.Adress = "";
            this.Avata = "";
            this.PositionID = 1;
            this.Salary = 0;
            this.CreatedTime = DateTime.Now;
            this.UpdatedTime = DateTime.Now;
            this.Bills = new HashSet<Bill>();
            this.Active = true;
        }

    }
}
