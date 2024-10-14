using EventNotificationTask.Model;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System.Text;

namespace EventNotificationTask.Service
{
    public class ServiceBus : BackgroundService, IServiceBus
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly ILogger<ServiceBus> _logger;
        private readonly IConnection _connection;
        private IModel _channel = null!;
        private readonly IServiceEmail _serviceEmail;
        private const string QUEUENAME = "TASKCREATED";
        private const string EXCHANGE = "TASK_CREATED_DIRECT";
        private const string ROUTINGKEY = "MinhaSenhaUmDoisTres";

        public ServiceBus(ILogger<ServiceBus> logger, IServiceEmail email)
        {
            _logger = logger;
             _serviceEmail = email; 
        }
       
        public async Task Consumer()
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };

                var connection = factory.CreateConnection();
                _channel = connection.CreateModel();
                
                    _channel.ExchangeDeclare(exchange: EXCHANGE, type: ExchangeType.Direct);

                    _channel.QueueBind(queue: QUEUENAME,
                                  exchange: EXCHANGE,
                                  routingKey: ROUTINGKEY);


                    _logger.LogInformation("Conexão OK");

                    EventingBasicConsumer consumer = new(_channel);
                    EventTaskCreated eventTask = null!;

                    consumer.Received += async (sender, e) =>
                    {
                        var body = e.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);

                         eventTask = JsonConvert.DeserializeObject<EventTaskCreated>(message)!;

                        var template = EmailTemplate.GenerateTemplate(eventTask);
                      
                        _logger.LogInformation(message);

                       await _serviceEmail.SendEmailAsync(eventTask, template);

                        _logger.LogInformation("Email enviado com sucesso");
                       

                       _channel.BasicAck(e.DeliveryTag, false);
                    };
                   
                    _channel.BasicConsume(queue: QUEUENAME, autoAck: false, consumer: consumer);


                  
            }
            catch (RabbitMQClientException ex) 
            {
                _logger.LogError(ex.Message);
            }

           
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                 await Consumer();


                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
            await Task.FromResult(0);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }


    }
}
