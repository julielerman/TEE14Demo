using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using ContactManagement.Core.Model;
using ContactManagement.Infrastructure;
using Newtonsoft.Json;
using Shared.DTOs;
using Shared.ValueObjects;

namespace ContactManagementServicesAPI.Controllers {
  public class ContactsController : ApiController {
    // GET api/<controller>
    public IEnumerable<Contact> Get() {
      using (var context = new ContactAggregateContext()) {
        return context.Contacts.ToList();
      }
    }

    public ContactWithAddressDto GetContactWithAddressDto(Guid id) {
      using (var context = new ContactAggregateContext()) {
        Contact c = context.Contacts.Find(id);
        return ContactWithAddressDto.Create(c.Id, c.Name, c.PrimaryAddress, c.Source);
      }
    }

    // GET api/<controller>/5
    public Address GetPrimaryAddressForContact(Guid id) {
      using (var context = new ContactAggregateContext()) {
        return context.Contacts.Find(id).PrimaryAddress;
      }
    }

    // POST api/<controller>
    //public Guid Post(HttpRequestMessage request) {
    //  var str = Request.Content.ReadAsStringAsync().Result;
    //  var c = Newtonsoft.Json.JsonConvert.DeserializeObject<ContactWithAddressDto>(str);
    //  return Guid.Empty;
    //}

    public Guid Post(HttpRequestMessage request) {
      var repo = new ContactAggregateRepository();
      string str = Request.Content.ReadAsStringAsync().Result;
      var c = JsonConvert.DeserializeObject<ContactWithAddressDto>(str);

      Contact contact = Contact.Create(new Name(c.FirstName, c.LastName), "Sales");
      var cA = c.PrimaryAddress;
      contact.CreateNewAddress(cA.Street1, cA.Street2, cA.City, cA.Region, cA.Country, cA.PostalCode);
      if (repo.PersistNewContact(contact)) {
        return contact.Id;
      }
      return Guid.Empty;
    }

    // PUT api/<controller>/5
    public void Put(int id, [FromBody] string value) {
    }

    // DELETE api/<controller>/5
    public void Delete(int id) {
    }
  }
}