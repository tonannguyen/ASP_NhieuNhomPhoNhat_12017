﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Model
{
    public class Staff
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int UserRole { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Avata { get; set; }
        public int PositionID { get; set; }
        public float Salary { get; set; }
        public float Bonus { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }

        //mapping
        public virtual Position Position { get; set; }

        public Staff()
        {
            this.Name = "";
            this.Password = "";
            this.Phone = "123456";
            this.Adress = "HCM";
            this.Avata = "";
            this.PositionID = 1;
            this.Salary = 0;
            this.Bonus = 0;
            this.CreatedTime = DateTime.Now;
            this.UpdatedTime = DateTime.Now;
        }
    }
}
