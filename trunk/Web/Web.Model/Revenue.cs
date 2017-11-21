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
        public float QuantityOfDate { get; set; }
        public float QuantityOfWeek { get; set; }
        public float QuantityOfMonth { get; set; }
        public float QuantityOfQuater { get; set; }
        public float QuantityOfYear { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }

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
        }
    }
}
