using EventNotificationTask.Model;

namespace EventNotificationTask.Service
{
    public interface IServiceEmail
    {
        Task SendEmailAsync(EventTaskCreated email, string template);
    }
}
