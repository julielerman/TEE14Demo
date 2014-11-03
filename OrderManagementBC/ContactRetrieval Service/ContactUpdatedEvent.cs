using System;
using OrderManagement.DataMirroring.Models;
using Shared.Interfaces;

namespace OrderManagement.DataMirroring {
  public class ContactUpdatedEvent : IApplicationEvent {
    public ContactUpdatedEvent(Contact contact, bool isNew) : this() {
      Contact = contact;
      IsNew = isNew;
    }

    private ContactUpdatedEvent() {
      DateTimeEventOccurred = DateTime.Now;
    }

    public Contact Contact { get; private set; }
    public bool IsNew { get; private set; }
    public DateTime DateTimeEventOccurred { get; set; }

    public string EventType {
      get { return "ContactUpdatedEvent"; }
    }
  }
}