using System;
using Shared.DTOs;
using Shared.Interfaces;

namespace ContactManagement.Infrastructure.ApplicationEvents {
  public class ContactUpdatedEvent : IApplicationEvent {
    public ContactUpdatedEvent(ContactDto contact, bool isNew) : this() {
      Contact = contact;
      IsNew = isNew;
    }

    public ContactUpdatedEvent() {
      DateTimeEventOccurred = DateTime.Now;
    }

    public ContactDto Contact { get; private set; }
    public bool IsNew { get; private set; }
    public DateTime DateTimeEventOccurred { get; set; }

    public string EventType {
      get { return "ContactUpdatedEvent"; }
    }
  }
}