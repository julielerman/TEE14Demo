using System;
using Shared.Interfaces;

namespace ContactManagement.Core.DomainEvents {
  public class ContactNameFixedEvent : IDomainEvent {
    public ContactNameFixedEvent() {
      DateTimeEventOccurred = DateTime.Now;
    }

    public string EventType {
      get { return "ContactNameFixedEvent"; }
    }

    public DateTime DateTimeEventOccurred { get; set; }
  }
}