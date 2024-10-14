using TodoList.Core.BaseResult;

namespace TodoList.Core.Model
{
    public class Comment : EntityBase
    {
        public Comment(string comments, Guid taskId)
        {
            Comments = comments;
            PostedAt = DateTime.Now;
            TaskId = taskId;
            IsDeleted = false;
        }

        public string Comments { get; private set; } = default!;
        public DateTime PostedAt { get; private set; }
        public virtual TaskTodo TaskTodo { get; private set; }
        public Guid TaskId { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public ResultViewModel DeleteComment(Guid CommentId)
        {
            if (CommentId == Guid.Empty || IsDeleted)
                return ResultViewModel.Failure("Erro ao deletar");

            IsDeleted = true;
            DeletedAt = DateTime.Now;

            return ResultViewModel.Success("Task deletada com sucesso");
        }
    }
}
