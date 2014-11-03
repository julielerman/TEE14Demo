using ContactManagement.Infrastructure;
using ContactManagement.Infrastructure.Interfaces;
using ContactManagement.Infrastructure.Services;
using Shared.Interfaces;
using StructureMap;
using StructureMap.Graph;

namespace ContactManagementTests.DependencyResolution {
  public static class IoC {
    private static IContainer _container;

    public static IContainer Container {
      get {
        if (_container == null) {
          Initialize();
        }
        return _container;
      }
    }


    public static void Initialize() {
      _container = new Container(cfg =>
      {
        cfg.Scan(scan =>
        {
          scan.TheCallingAssembly();
          scan.WithDefaultConventions();

          scan.AssemblyContainingType<IApplicationEvent>();
          scan.ConnectImplementationsToTypesClosing(typeof (IHandle<>));
        });

        cfg.For<IMessagePublisher>().Use<RabbitMqMessagePublisher>();
        cfg.For<ContactUpdatedService>().Use<ContactUpdatedService>();
      });
    }
  }
}