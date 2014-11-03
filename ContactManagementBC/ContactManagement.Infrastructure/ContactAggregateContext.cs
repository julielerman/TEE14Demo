using System;
using System.Data.Entity;
using ContactManagement.Core.Model;

namespace ContactManagement.Infrastructure {
  public class ContactAggregateContext : DbContext {
    public ContactAggregateContext() {
      Database.Log = Console.WriteLine;
    }

    public DbSet<Contact> Contacts { get; set; }
  }
}