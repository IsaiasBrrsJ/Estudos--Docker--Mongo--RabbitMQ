using Newtonsoft.Json;


namespace EventNotificationTask.Model
{
    public class EventTaskCreated
    {
       
        public string Title { get;  set; } = default!;

        public string UserName { get; set; } = default!;

        public string email { get; set; } = default!;

        public string description { get; set; } = default!;


    }
}
