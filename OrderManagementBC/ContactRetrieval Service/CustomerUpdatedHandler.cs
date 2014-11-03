using OrderManagement.DataMirroring.DataPersistence;
using OrderManagement.DataMirroring.Models;
using Shared.Interfaces;

namespace OrderManagement.DataMirroring {
  public class ContactUpdatedHandler : IHandle<ContactUpdatedEvent> {
    public void Handle(ContactUpdatedEvent contactUpdatedEvent) {
      Contact contact = contactUpdatedEvent.Contact;
      using (var mgr = new SimpleRepo()) {
        if (contactUpdatedEvent.IsNew) {
          mgr.InsertContact(contact);
        }
        else {
          mgr.UpdateContact(contact);
        }
      }
    }
  }

  //class CustomerUpdatedHandlerImpl : ContactUpdatedHandler
  //{
  //}
}