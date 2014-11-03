using CustomerManagement.Core.Model.ApplicationEvents;
using CustomerManagement.Infrastructure.Interfaces;
using Shared.Interfaces;

namespace CustomerManagement.Core.Services {
  public class CustomerUpdatedService : IHandle<CustomerUpdatedEvent> {
    private readonly IMessagePublisher _messagePublisher;


    public CustomerUpdatedService(IMessagePublisher messagePublisher) {
      _messagePublisher = messagePublisher; //rabbitmq here
    }

    public void Handle(CustomerUpdatedEvent customerUpdatedEvent) {
      _messagePublisher.Publish(customerUpdatedEvent);
    }
  }
}