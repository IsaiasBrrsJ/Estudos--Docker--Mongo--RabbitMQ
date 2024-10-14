using EventNotificationTask.Model;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;


namespace EventNotificationTask.Service
{
    public class SendEmailService : IServiceEmail
    {
        private readonly string Key;
        private readonly string FromEmail;

        public  SendEmailService([FromServices]IConfiguration configuration)
        {
            Key = configuration["SendGrid:Key"]!;
            FromEmail = configuration["SendGrid:FromEmail"]!;
        }
        public  async Task SendEmailAsync(EventTaskCreated email, string template)
        {
           
                var client = new SendGridClient(Key);
                var sendMessage = new SendGridMessage();

                sendMessage.SetFrom(FromEmail, "Task - ADM ");
                sendMessage.AddTo(email.email, email.UserName);
                sendMessage.SetSubject("TASK Criada");

                sendMessage.AddContent(
                                        MimeType.Html,
                                        template
                                      );

                var response = await client.SendEmailAsync(sendMessage);

        }
    }
}
