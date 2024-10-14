using MediatR;
using TodoList.Core.BaseResult;
using TodoList.Core.Repositories;
using TodoList.Core.Services;

namespace TodoList.Application.AddTask.Command
{
    public class AddTaskHandler : IRequestHandler<TaskAdd, ResultViewModel<Guid>>
    {
        private readonly ITaskTodo _taskTodo;
        private readonly IPublishMessage _publishMessage;
        private readonly ITaskPublishMongo _publishMongo;

        public AddTaskHandler(ITaskTodo taskTodo, IPublishMessage publishMessage, ITaskPublishMongo publishMongo)
        {
            _taskTodo = taskTodo;
            _publishMessage = publishMessage;
            _publishMongo = publishMongo;
        }

        public async Task<ResultViewModel<Guid>> Handle(TaskAdd request, CancellationToken cancellationToken)
        {
            var task = request.ToEntity();

            var id = await _taskTodo.AddAsync(task);

            if (id == Guid.Empty)
                return ResultViewModel<Guid>.Failure(Guid.Empty, "Falha ao criar task");

            
            await _publishMessage.publish(request);
            await _publishMongo.Add(task);
            

            return ResultViewModel<Guid>.Success(id, "Task criada com sucesso");


        }
    }
}
