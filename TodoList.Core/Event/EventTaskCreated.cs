using TodoList.Core.Model;

namespace TodoList.Core.Event
{
    public class EventTaskCreated
    {
        public EventTaskCreated(string title, string userName, string email, string description, DateTime createAt)
        {
            Title = title;
            UserName = userName;
            Email = email;
            Description = description;
            CreateAt = createAt;
        }
        public string Title { get; private set; } = default!;
        public string UserName { get; private set; } = default!;
        public string Email { get; private set; }
        public string Description { get; private set; } = default!;
        public DateTime CreateAt { get; private set; }
    }
}
