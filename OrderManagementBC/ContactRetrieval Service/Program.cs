using System.Data.Entity;
using OrderManagement.DataMirroring.DataPersistence;
using OrderManagement.DataMirroring.DependencyResolution;
using StructureMapContainer;

namespace OrderManagement.DataMirroring {
  public static class Program {
    public static void Main() {
      IocContainer.Container = IoC.Container;
      Database.SetInitializer<ContactsContext>(null);
      var mqListener = new RabbitListener {Enabled = true};
      mqListener.Start();
    }
  }
}