namespace Web.Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Web.Model.MasterDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Web.Model.MasterDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if(context.Positions.Any() == false)
            {
                var pos = new Position();
                pos.Value = "Admin";
                context.Positions.Add(pos);
            }

            if(context.Employees.Any() == false)
            {
                var staff = new Employee();
                staff.Name = "Admin";
                staff.Password = "123456";
                
                staff.Phone = "123456";
                staff.PositionID = 1;
                staff.Salary = 1;
                staff.Bonus = 1;
                context.Employees.Add(staff);
            }

           /* if (context.Flowers.Any() == false)
            {
                var flower = new Flower();
                flower.TypeID = 1;
                flower.Name = "a";
                flower.Price = 0;
                flower.Quantity = 0;
                flower.Image = "";
                flower.Description = "";
                context.Flowers.Add(flower);
            }*/
        }
    }
}
