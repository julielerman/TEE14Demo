using System;
using System.Data.Entity;
using SalesDomain;

namespace SalesOrder.Persistence {
  public class OrderAggregateContext : DbContext {
    public OrderAggregateContext() {
      Database.Log = Console.WriteLine;
    }

    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
      modelBuilder.Entity<Order>().Ignore(o => o.NewContactCustomerName);
      modelBuilder.Entity<Order>().Ignore(o => o.NewContactSource);
      modelBuilder.Entity<Customer>().Ignore(c => c.Contact);
      base.OnModelCreating(modelBuilder);
    }
  }
}