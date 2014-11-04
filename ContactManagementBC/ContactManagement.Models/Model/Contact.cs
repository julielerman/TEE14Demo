using System;
using System.Collections.Generic;
using ContactManagement.Core.DomainEvents;
using Shared;
using Shared.Interfaces;
using Shared.ValueObjects;

namespace ContactManagement.Core.Model {
  public class Contact : WritableEntity {
    private Contact(Name name, string source) {
      Id = Guid.NewGuid();
      Name = name;
      InitialDate = DateTime.UtcNow;

      Source = source;
      PrimaryAddress = Address.DefaultAddress();
      Events = new List<IDomainEvent>();
    }

    //Entity Framework concession, also for JSON.Net
    private Contact() {
    }

    public Name Name { get; private set; }
    public DateTime InitialDate { get; private set; }
    public String Source { get; private set; }
    public Address PrimaryAddress { get; private set; }

    public ICollection<IDomainEvent> Events { get; set; }

    public static Contact Create(Name name, string source) {
      return new Contact(name, source);
    }

    public void CreateNewAddress(string street1, string street2, string city, string region, string country,
      string postalCode) {
      PrimaryAddress = Address.CreateAddress(street1, street2,
        city, region,
        country, postalCode);
    }


    public void FixName(Name newName) {
      Name = newName;
      Events.Add(new ContactNameFixedEvent());
    }
  }
}