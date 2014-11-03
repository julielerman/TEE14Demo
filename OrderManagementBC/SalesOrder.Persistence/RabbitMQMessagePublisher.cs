using System;
using CustomerManagement.Infrastructure.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace CustomerManagement.Core.Services
{
  public class RabbitMqMessagePublisher : IMessagePublisher {
   
    public void Publish(Shared.Interfaces.IApplicationEvent applicationEvent) {

      var factory = new ConnectionFactory();

      IConnection conn = factory.CreateConnection(); //uses defaults 
      using (IModel channel = conn.CreateModel()) {
        channel.ExchangeDeclare("CustomerUpdate", ExchangeType.Direct);
        channel.QueueDeclare("MyMSDNSampleQueue", false, false, false, null);
        channel.QueueBind("MyMSDNSampleQueue", "CustomerUpdate", "", null);
        IBasicProperties props = channel.CreateBasicProperties();
        string json = JsonConvert.SerializeObject(applicationEvent, Formatting.None);

        byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes(json);
        channel.BasicPublish("CustomerUpdate", "", props, messageBodyBytes);
      }
    }

  }
}

