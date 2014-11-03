using System;
using CustomerManagement.Core.Services;
using Shared.Interfaces;

namespace CustomerManagement.Core.Model.ApplicationEvents {
  public class CustomerUpdatedEvent : IApplicationEvent {
    public CustomerUpdatedEvent(CustomerDto customer, bool isNew) : this() {
      Customer = customer;
      IsNew = isNew;
    }

    public CustomerUpdatedEvent() {
      DateTimeEventOccurred = DateTime.Now;
    }

    public CustomerDto Customer { get; private set; }
    public bool IsNew { get; private set; }
    public DateTime DateTimeEventOccurred { get; set; }

    public string EventType {
      get { return "CustomerUpdatedEvent"; }
    }
  }
}