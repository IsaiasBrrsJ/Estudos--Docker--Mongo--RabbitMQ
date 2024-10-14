using RabbitMQ.Client;

namespace EventNotificationTask.Service
{
    public interface IServiceBus
    {
      Task Consumer();

    }
}
