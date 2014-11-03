using System;
using OrderManagement.DataMirroring.Models;

namespace OrderManagement.DataMirroring.DataPersistence {
  public class SimpleRepo : IDisposable {
    public void Dispose() {
    }

    public void InsertContact(Contact contact) {
      using (var context = new ContactsContext()) {
        context.Contacts.Add(contact);
        context.SaveChanges();
      }
    }

    public void UpdateContact(Contact contact) {
      using (var context = new ContactsContext()) {
        context.Database.ExecuteSqlCommand(
          "exec ReplaceContact {0}, {1}, {2}",
          contact.ContactId, contact.FirstName, contact.LastName);
      }
    }
  }
}