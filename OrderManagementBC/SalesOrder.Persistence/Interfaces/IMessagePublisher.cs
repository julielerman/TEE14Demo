using Shared.Interfaces;

namespace CustomerManagement.Infrastructure.Interfaces {
  public interface IMessagePublisher {
    void Publish(IApplicationEvent applicationEvent);
  }
}