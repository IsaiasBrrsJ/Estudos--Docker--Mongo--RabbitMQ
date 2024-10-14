using System.Text.RegularExpressions;
using TodoList.Core.BaseResult;

namespace TodoList.Core.Model
{
    public class TaskTodo : EntityBase
    {
        public TaskTodo(string title, string userName,string email, string description) 
        {
            Title = title;
            UserName = userName;
            Email  = email;
            Description = description;
            CreateAt = DateTime.Now;
            IsCompleted = false;
            IsDeleted = false;
        } 

        public string Title { get; private set; } = default!;
        public string UserName { get; private set; } = default!;
        public string Email { get; private set; }
        public string Description { get; private set; } = default!;
        public virtual ICollection<Comment>? Comments { get; private set; } = default!;
        public DateTime CreateAt { get; private set; }
        public bool IsCompleted { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public ResultViewModel DeleteTask(Guid TaskId)
        {
            if (TaskId == Guid.Empty || IsDeleted)
                return ResultViewModel.Failure("Erro ao deletar");

            IsDeleted = true;
            DeletedAt = DateTime.Now;

            return ResultViewModel.Success("Task deletada com sucesso");
        }
        public ResultViewModel SetComplete()
        {
            if (IsCompleted)
               return ResultViewModel.Failure($"Erro ao finalizar Task, status atual: {IsCompleted}");

            IsCompleted = true;
            CompletedAt = DateTime.Now;

            return ResultViewModel.Success("Task finalizada com sucesso");
        }
       
        public ResultViewModel AddComment(Comment comment)
        {
            if(comment is null || String.IsNullOrWhiteSpace(comment.Comments))
                return ResultViewModel.Failure("Erro ao tentar inserir comentário");

            Comments!.Add(comment);

            return ResultViewModel<ICollection<Comment>>.Success(Comments, "Comentário incluso com sucesso");

        }
    }
}
