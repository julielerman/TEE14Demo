using System.Data.Entity.Migrations;
using ContactManagement.Infrastructure;

namespace CustomerManagement.Infrastructure.Migrations {
  internal sealed class Configuration : DbMigrationsConfiguration<ContactAggregateContext> {
    public Configuration() {
      AutomaticMigrationsEnabled = false;
      ContextKey = "CustomerManagement.Infrastructure.CustomerAggregateContext";
    }

    protected override void Seed(ContactAggregateContext context) {
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
    }
  }
}