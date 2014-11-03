using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.MessagePatterns;
using Shared;

namespace OrderManagement.DataMirroring {
  /// <summary>
  ///   Class to encapsulate recieving messages from RabbitMQ
  ///   Derived from sample code on Pluralsight "RabbitMQ for .NET Developers" course
  /// </summary>
  public class RabbitListener : IDisposable {
    public delegate void OnReceiveMessage(string message);

    private const string QueueName = "BarcelonaQueue";
    private const bool IsDurable = true;


    private readonly IModel _channel;
    private string _exchangeName;
    private Subscription _subscription;


    public RabbitListener() {
      var factory = new ConnectionFactory();
      IConnection conn = factory.CreateConnection(); //uses defaults 
      _channel = conn.CreateModel();
      _exchangeName = "ContactUpdate";
      _channel.ExchangeDeclare(_exchangeName, ExchangeType.Direct);
      _channel.QueueDeclare(QueueName, false, false, false, null);
      _channel.QueueBind(QueueName, _exchangeName, "", null);

      IBasicProperties props = _channel.CreateBasicProperties();

      _channel.BasicQos(0, 1, false);
    }

    public bool Enabled { get; set; }

    public void Dispose() {
      if (_channel != null)
        _channel.Dispose();
      GC.SuppressFinalize(this);
    }

    public void Start() {
      _subscription = new Subscription(_channel, QueueName, true);

      var consumer = new ConsumeDelegate(Poll);
      consumer.Invoke();
    }

    private void Poll() {
      while (Enabled) {
        Console.WriteLine("Waiting for messages!");
        //Get next message
        BasicDeliverEventArgs deliveryArgs = _subscription.Next();
        //Deserialize message
        string message = Encoding.Default.GetString(deliveryArgs.Body);

        //Handle Message
        Console.WriteLine("Message Recieved - {0}", message);
        var contactUpdatedEvent = JsonConvert.DeserializeObject<ContactUpdatedEvent>(message);
        DomainEvents.Raise(contactUpdatedEvent);
        // _subscription.Ack(); <--this will remove the message
      }
    }

    private delegate void ConsumeDelegate();
  }
}