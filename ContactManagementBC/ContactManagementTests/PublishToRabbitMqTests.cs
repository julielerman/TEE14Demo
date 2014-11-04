using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ContactManagement.Core.Model;
using ContactManagement.Infrastructure;
using ContactManagementTests.DependencyResolution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.ValueObjects;
using StructureMapContainer;

namespace ContactManagementTests {
  [TestClass]
  public class PublishToRabbitMqTests {
    public PublishToRabbitMqTests() {
      IocContainer.Container = IoC.Container;
      //Database.SetInitializer(new NullDatabaseInitializer<ContactAggregateContext>());
    }

    [TestMethod]
    public void CanSendMessageToQueueOnSuccessfulContactInsert() {
      Contact contact = Contact.Create(new Name("Julie", "Lerman"), "Friend Referral");
      var repo = new ContactAggregateRepository();
      repo.PersistNewContact(contact);

      Assert.Inconclusive("Check status of RabbitMQ Manager for this message");
    }

    [TestMethod]
    public void CanSendMessageToQueueOnSuccessfulContactNameUpdate() {
      Contact contact = Contact.Create(new Name("Spamson", "Lerman"), "Friend Referral");
      var repo = new ContactAggregateRepository();
      repo.PersistNewContact(contact);
      contact.FixName(new Name("Sampson", "Lerman"));

      repo.PersistChangeToContact(contact);

      Assert.Inconclusive("Check status of RabbitMQ Manager for a create message and an update message");
    }

    [TestMethod]
    public void WillNotSendMessageToQueueOnSuccessfulContactAddressUpdate() {
      Contact contact = Contact.Create(new Name("George", "Jetson"), "Spacely Sprockets Referral");
      var repo = new ContactAggregateRepository();
      repo.PersistNewContact(contact);
      contact.CreateNewAddress("123 SkyPad Apartments", "", "Orbit City", "Orbit", "n/a", "");
      repo.PersistChangeToContact(contact);

      Assert.Inconclusive(@"Check status of RabbitMQ Manager for a create message, 
                          but no update message because name was not changed");
    }

    [TestMethod]
    public void WillNotSendMessageToQueueOnFailedContactUpdate() {
      Contact contact = Contact.Create(new Name("Unpersisted", "Contact"), "Friend Referral");
      var repo = new ContactAggregateRepository();
      contact.FixName(new Name("WasNeverPersisted", "Contact"));
      //note, did not persist the new Contact, so reupdate will fail
      try {
        repo.PersistChangeToContact(contact);
      }
      catch (DbUpdateConcurrencyException) {
        //swallow this exception so we can be sure that when it happens, the message won't get pushed into the queue
      }

      Assert.Inconclusive("There should be no messages in the queue at all");
    }
  }
}