using System.Web;
using System.Web.Http;
using ContactManagementTests.DependencyResolution;
using StructureMapContainer;

namespace ContactManagementServicesAPI {
  public class WebApiApplication : HttpApplication {
    protected void Application_Start() {
      GlobalConfiguration.Configure(WebApiConfig.Register);
      IocContainer.Container = IoC.Container;
    }
  }
}