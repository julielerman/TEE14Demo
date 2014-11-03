using System.Data.Entity;
using SalesDomain;

namespace SalesOrder.Persistence {
  internal class ReferenceDataContext : DbContext {
    private DbSet<Contact> Contacts { get; set; }
  }
}