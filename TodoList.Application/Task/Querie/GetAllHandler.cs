using MediatR;
using TodoList.Application.Extension;
using TodoList.Application.ViewModel;
using TodoList.Core.BaseResult;
using TodoList.Core.Repositories;

namespace TodoList.Application.Task.Querie
{
    public class GetAllHandler : IRequestHandler<GetAll,ResultViewModel<IEnumerable<TaskViewModel>>>
    {
        private readonly ITaskTodo _taskTodo;

        public GetAllHandler(ITaskTodo taskTodo)
        {
            _taskTodo = taskTodo;
        }

        public async Task<ResultViewModel<IEnumerable<TaskViewModel>>> Handle(GetAll request, CancellationToken cancellationToken)
        {
            var result = await _taskTodo.GetAllAsync();

            var resultToView = request.ToViewModel(result);

            var message = resultToView.HasValueInColletion() ? "Registered Tasks" : "Tasks is Empty";

            return ResultViewModel<IEnumerable<TaskViewModel>>.Success(resultToView, message);
        }
    }
}
