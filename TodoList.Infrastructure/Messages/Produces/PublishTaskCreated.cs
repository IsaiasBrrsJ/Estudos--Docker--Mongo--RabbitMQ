using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using TodoList.Core.Services;

namespace TodoList.Infrastructure.Messages.Produces
{
    public class PublishMessage : IPublishMessage
    {
      
        private readonly ConnectionFactory _connectionFactory;
        private const string QUEUENAME = "TASKCREATED";
        private const string EXCHANGE = "TASK_CREATED_DIRECT";
        private const string ROUTINGKEY = "MinhaSenhaUmDoisTres";
        public PublishMessage()
        {
            _connectionFactory = new ConnectionFactory() { HostName = "localhost" };
        }
        public async Task publish<T>(T message) where T : class
        {
           using(var  connection = _connectionFactory.CreateConnection())
           using(var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: EXCHANGE, ExchangeType.Direct);

                var messageSerialized = JsonSerializer.Serialize<T>(message);

                var body = Encoding.UTF8.GetBytes(messageSerialized);


                channel.BasicPublish(exchange: EXCHANGE, routingKey: ROUTINGKEY, basicProperties: null, body: body);

            }
        }
    }

}
