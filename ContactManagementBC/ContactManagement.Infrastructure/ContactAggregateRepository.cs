using System;
using System.Data.Entity;
using System.Linq;
using ContactManagement.Core.DomainEvents;
using ContactManagement.Core.Model;
using ContactManagement.Infrastructure.ApplicationEvents;
using Shared;
using Shared.DTOs;

namespace ContactManagement.Infrastructure {
  public class ContactAggregateRepository {
    public bool PersistNewContact(Contact contact) {
      using (var context = new ContactAggregateContext()) {
        context.Contacts.Add(contact);
        try {
          int response = context.SaveChanges();
          if (response > 0) {
            PublishContactPersistedEvent(contact, true);
          }
          return true;
        }
        catch (Exception ex) {
          throw ex;
        }
      }
    }


    public bool PersistChangeToContact(Contact contact) {
      using (var context = new ContactAggregateContext()) {
        context.Contacts.Attach(contact);
        context.Entry(contact).State = EntityState.Modified;
        try {
          int response = context.SaveChanges();
          if (response > 0) {
            if (contact.Events.OfType<ContactNameFixedEvent>().Any()) {
              PublishContactPersistedEvent(contact, false);
            }
            return true;
          }
          return false;
        }
        catch (Exception ex) {
          throw ex;
        }
      }
    }

    private void PublishContactPersistedEvent(Contact contact, bool isNew) {
      var dto = ContactDto.Create(contact.Id, contact.Name);
      DomainEvents.Raise(new ContactUpdatedEvent(dto, isNew));
    }
  }
}