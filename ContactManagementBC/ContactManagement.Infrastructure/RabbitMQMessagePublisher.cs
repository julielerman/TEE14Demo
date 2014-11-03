using System.Text;
using ContactManagement.Infrastructure.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Shared.Interfaces;

namespace ContactManagement.Infrastructure {
  public class RabbitMqMessagePublisher : IMessagePublisher {
    
    public void Publish(IApplicationEvent applicationEvent) {
      var factory = new ConnectionFactory();

      IConnection conn = factory.CreateConnection(); //uses defaults 
      using (IModel channel = conn.CreateModel()) {
        channel.ExchangeDeclare("ContactUpdate", ExchangeType.Direct);
        channel.QueueDeclare("BarcelonaQueue", false, false, false, null);
        channel.QueueBind("BarcelonaQueue", "ContactUpdate", "", null);
        IBasicProperties props = channel.CreateBasicProperties();
        string json = JsonConvert.SerializeObject(applicationEvent, Formatting.None);

        byte[] messageBodyBytes = Encoding.UTF8.GetBytes(json);
        channel.BasicPublish("ContactUpdate", "", props, messageBodyBytes);
      }
    }

   
  }
}