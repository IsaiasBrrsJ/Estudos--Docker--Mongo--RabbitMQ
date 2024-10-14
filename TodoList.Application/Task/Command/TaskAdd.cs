using MediatR;
using TodoList.Core.BaseResult;
using TodoList.Core.Model;

namespace TodoList.Application.AddTask.Command
{
    public class TaskAdd : IRequest<ResultViewModel<Guid>>
    {
        public string Title { get; set; } = default!;

        public string UserName { get; set; } = default!;

        public string email { get; set; } = default!;

        public string description { get; set; } = default!;

        public TaskTodo ToEntity()
            => new TaskTodo(Title, UserName, email, description);
    }
}
