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
        public decimal TotalBuy { get; set; }
        public decimal TotalSale { get; set; }
        public decimal QuantityOfDate { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public bool Active { get; set; }


        public Revenue()
        {
            this.YearID = DateTime.Now.Year.ToString();
            this.TotalBuy = 0;
            this.TotalSale = 0;
            this.QuantityOfDate = 0;
            this.CreatedTime = DateTime.Now;
            this.UpdatedTime = DateTime.Now;
            this.Active = true;
        }
    }
}
