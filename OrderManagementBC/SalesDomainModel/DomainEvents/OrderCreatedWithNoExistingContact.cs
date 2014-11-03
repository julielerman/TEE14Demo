using System;
using Shared.Interfaces;

namespace SalesDomain.DomainEvents {
  public class OrderCreatedWithNoExistingContact : IDomainEvent {
    public OrderCreatedWithNoExistingContact() {
      DateTimeEventOccurred = DateTime.Now;
    }

    public string EventType {
      get { return "OrderCreatedWithNoExistingContact"; }
    }

    public DateTime DateTimeEventOccurred { get; private set; }
  }
}