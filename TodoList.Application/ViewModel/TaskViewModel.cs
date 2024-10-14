namespace TodoList.Application.ViewModel
{
    public class TaskViewModel 
    {
        public TaskViewModel(string title, string userName, string email, string description)
        {
            Title = title;
            UserName = userName;
            Email = email;
            Description = description;
        }

        public string Title { get; private set; } = default!;
        public string UserName { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public string Description { get; private set; } = default!;
    }
}
