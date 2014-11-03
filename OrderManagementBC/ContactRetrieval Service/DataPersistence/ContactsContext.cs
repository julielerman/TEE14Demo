using System.Data.Entity;
using OrderManagement.DataMirroring.Models;

namespace OrderManagement.DataMirroring.DataPersistence {
  public class ContactsContext : DbContext {
    public DbSet<Contact> Contacts { get; set; }
  }
}