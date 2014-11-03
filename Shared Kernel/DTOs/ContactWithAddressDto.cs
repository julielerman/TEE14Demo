using System;
using Shared.ValueObjects;

namespace Shared.DTOs {
  public class ContactWithAddressDto {
    private ContactWithAddressDto(Guid contactId, Name contactName, Address address, string source) {
      ContactId = contactId;
      FirstName = contactName.FirstName;
      LastName = contactName.LastName;
      PrimaryAddress = address;
      Source = source;
    }

    protected ContactWithAddressDto() {
      ContactId = Guid.Empty;
    }

    public Guid ContactId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Address PrimaryAddress { get; set; }
    public string Source { get; set; }

    public static ContactWithAddressDto Create(Guid contactId, Name contactName, Address address, string source) {
      return new ContactWithAddressDto(contactId, contactName, address, source);
    }
  }
}