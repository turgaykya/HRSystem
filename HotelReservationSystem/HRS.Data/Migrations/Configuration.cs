namespace HRS.Data.Migrations
{
    using HRS.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HRS.Data.Concrete.EntityFramework.HRSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(HRS.Data.Concrete.EntityFramework.HRSContext context)
        {
            context.Pricing.AddOrUpdate(new Pricing() { WeekType = 1, Price = 100 },
                new Pricing() { WeekType = 2, Price = 130 });

        }
    }
}
