using System;
using Shared.Interfaces;
using Shared.ValueObjects;

namespace SalesDomain.DomainEvents {
  [Obsolete]
  public class OrderCreatedWithContactButNoExistingCustomer : IDomainEvent {
    public OrderCreatedWithContactButNoExistingCustomer(Guid contactid, Address contactAddress) {
      DateTimeEventOccurred = DateTime.Now;
      ContactId = contactid;
      ContactAddress = contactAddress;
    }


    public Guid ContactId { get; private set; }
    public Address ContactAddress { get; private set; }

    public string EventType {
      get { return "OrderCreatedWithContactButNoExistingCustomer"; }
    }

    public DateTime DateTimeEventOccurred { get; private set; }
  }
}