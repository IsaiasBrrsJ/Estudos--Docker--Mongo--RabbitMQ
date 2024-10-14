using MediatR;
using TodoList.Application.ViewModel;
using TodoList.Core.BaseResult;
using TodoList.Core.Model;

namespace TodoList.Application.Task.Querie
{
    public class GetAll : IRequest<ResultViewModel<IEnumerable<TaskViewModel>>>
    {
        public IEnumerable<TaskViewModel> ToViewModel(IEnumerable<TaskTodo> todoTask)
        {
            return todoTask.Select(x => new TaskViewModel(x.Title, x.UserName, x.Email, x.Description));
        }
    }
}
