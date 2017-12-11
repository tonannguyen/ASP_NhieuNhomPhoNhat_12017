using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Model
{
    public class Revenue
    {
        [Key]
        public int ID { get; set; }
        public string YearID { get; set; }
        public decimal QuantityOfDate { get; set; }
        public decimal QuantityOfWeek { get; set; }
        public decimal QuantityOfMonth { get; set; }
        public decimal QuantityOfQuater { get; set; }
        public decimal QuantityOfYear { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public bool Active { get; set; }


        public Revenue()
        {
            this.YearID = DateTime.Now.Date.ToString();
            this.QuantityOfDate = 0;
            this.QuantityOfWeek = 0;
            this.QuantityOfMonth = 0;
            this.QuantityOfQuater = 0;
            this.QuantityOfYear = 0;
            this.CreatedTime = DateTime.Now;
            this.UpdatedTime = DateTime.Now;
            this.Active = true;
        }
    }
}
