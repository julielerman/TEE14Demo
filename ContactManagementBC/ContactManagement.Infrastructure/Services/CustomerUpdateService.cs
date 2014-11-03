using ContactManagement.Infrastructure.ApplicationEvents;
using ContactManagement.Infrastructure.Interfaces;
using Shared.Interfaces;

namespace ContactManagement.Infrastructure.Services {
  public class ContactUpdatedService : IHandle<ContactUpdatedEvent> {
    private readonly IMessagePublisher _messagePublisher;


    public ContactUpdatedService(IMessagePublisher messagePublisher) {
      _messagePublisher = messagePublisher; //rabbitmq here
    }

    public void Handle(ContactUpdatedEvent contactUpdatedEvent) {
      _messagePublisher.Publish(contactUpdatedEvent);
    }
  }
}