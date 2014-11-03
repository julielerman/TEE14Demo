using Shared.Interfaces;

namespace ContactManagement.Infrastructure.Interfaces {
  public interface IMessagePublisher {
    void Publish(IApplicationEvent applicationEvent);
  }
}