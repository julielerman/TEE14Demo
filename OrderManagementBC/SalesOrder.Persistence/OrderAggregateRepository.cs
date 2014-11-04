using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SalesDomain;
using SalesDomain.DomainEvents;
using Shared.DTOs;

namespace SalesOrder.Persistence {
  public class OrderAggregateRepository {
    public async Task<bool> Update(Order order) {
      using (var context = new OrderAggregateContext()) {
        //ef will mark every thing in graph as Added
        if (order.Validate()) {
          context.Orders.Add(order);
          order.SetModifiedDate();
          // context.Orders.Add(order);
          try {
            if (order.Events.OfType<OrderCreatedWithNoExistingContact>().Any()) {
              //call service to get new contact back to put contactid into customer
              await GetNewContactIdFromContactApi(order);
            }
            context.SaveChanges();
            return true;
          }

          catch (Exception ex) {
            throw ex;
          }
        }
        return false;
      }
    }

    public async Task<Guid> GetNewContactIdFromContactApi(Order order) {
      // string uriString = "http://localhost:57596/api/contacts/";
      var client = new HttpClient();
      client.BaseAddress = new Uri("http://localhost:57596/");
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      ContactWithAddressDto contact = ContactWithAddressDto.Create(Guid.Empty, order.NewContactCustomerName,
        order.ShippingAddress, order.NewContactSource);
      HttpResponseMessage response = await client.PostAsJsonAsync("api/contacts", contact);

      if (response.IsSuccessStatusCode) {
        // Get the URI of the created resource.
        string resultJson = response.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<Guid>(resultJson);
      }
      return Guid.Empty;
    }
  }
}