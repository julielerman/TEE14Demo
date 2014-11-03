using System.Data.Entity.Migrations;
using OrderManagement.DataMirroring.DataPersistence;

namespace OrderManagement.DataMirroring.Migrations {
  internal sealed class Configuration : DbMigrationsConfiguration<ContactsContext> {
    public Configuration() {
      AutomaticMigrationsEnabled = false;
    }
  }
}