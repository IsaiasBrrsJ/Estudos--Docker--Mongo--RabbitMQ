using TodoList.Core.Model;

namespace TodoList.Application.ViewModel
{
    public class CommentViewModel
    {
        public CommentViewModel(string comments, DateTime postedAt, Guid taskId)
        {
            Comments = comments;
            PostedAt = postedAt;
            TaskId = taskId;
        }

        public string Comments { get; private set; } = default!;
        public DateTime PostedAt { get; private set; }
        public Guid TaskId { get; private set; }
    }
}
