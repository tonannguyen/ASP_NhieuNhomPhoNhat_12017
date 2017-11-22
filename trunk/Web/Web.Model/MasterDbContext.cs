using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Model
{
    public class MasterDbContext : DbContext
    {
        public MasterDbContext()
            : base("name=MasterDbContext") // base tro toi connection string trong web.config
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        //table
        public virtual DbSet<Flower> Flowers { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Revenue> Revenues { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Item> Items { get; set; }
    }
}
