

using RabbitMQ.Client;
using System.Text;

namespace E_Commerce_Business.Concrete
{
   public class RabbitMQHelper
   {

      private readonly ConnectionFactory _factory;
      private readonly IModel _channel;


      public RabbitMQHelper()
      {
         _factory = new ConnectionFactory();
         _factory.Uri = new Uri("amqps://qokjomwv:KDmB2WxHJMyBo_xHeQvB6BA2A98tKFqR@puffin.rmq2.cloudamqp.com/qokjomwv");
         var connection = _factory.CreateConnection();
         _channel = connection.CreateModel();
         _channel.QueueDeclare(queue: "Deneme", durable: false, exclusive: false, autoDelete: false, arguments: null);
      }


      public void DenemePublish(string email, string passwordResetLink)
      {
         string message = "bu bir ilk midir rabbit";
         var body = Encoding.UTF8.GetBytes(message);
         _channel.BasicPublish(exchange: "", routingKey: "password_reset_request", basicProperties: null, body: body);
      }



   }
}
