using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ProductManagement.Core;
using ProductManagement.Persistence;

namespace ProductsServicesAPI.Controllers {
  public class ProductsController : ApiController {
    // GET api/<controller>
    public IEnumerable<Product> Get() {
      using (var context = new ProductContext()) {
        return context.Products.ToList();
      }
    }

    // GET api/<controller>/5
    public string Get(int id) {
      return "value";
    }


    //public Guid NewContact([FromBody]ContactWithAddressDto contactWithAddress) {
    //  var repo = new ContactAggregateRepository();
    //  var contact = Contact.Create(new Name(contactWithAddress.FirstName, contactWithAddress.LastName), "Sales");
    //  var cA = contactWithAddress.PrimaryAddress;
    //  contact.CreateNewAddress(cA.Street1, cA.Street2, cA.City, cA.Region, cA.Country, cA.PostalCode);
    //  if (repo.PersistNewContact(contact)) { return contact.Id; }
    //  else {
    //    return Guid.Empty;
    //  }
    //}

    // PUT api/<controller>/5
    public void Put(int id, [FromBody] string value) {
    }

    // DELETE api/<controller>/5
    public void Delete(int id) {
    }
  }
}