namespace SmartGroceryList2._0.Data.Migrations
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SmartGroceryList2._0.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SmartGroceryList2._0.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            string content = File.ReadAllText(@"C:\Users\rdeulley\source\repos\SmartGroceryList2.0\SmartGroceryList2.0.Data\JSONobj\Products.json");
            List<Product> Products = JsonConvert.DeserializeObject<List<Product>>(content);
            context.Products.AddOrUpdate(p => p.Id, Products.ToArray());

        }
    }
}
