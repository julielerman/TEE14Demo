using System;
using Shared.ValueObjects;

namespace Shared.DTOs {
  public class ContactDto {
    private ContactDto(Guid contactId, Name contactName) {
      ContactId = contactId;
      FirstName = contactName.FirstName;
      LastName = contactName.LastName;
    }

    public Guid ContactId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }


    public static ContactDto Create(Guid contactId, Name contactName) {
      return new ContactDto(contactId, contactName);
    }
  }
}