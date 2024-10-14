using TodoList.Core.Model;

namespace TodoList.Core.Repositories
{
    public interface ITaskPublishMongo
    {
        Task Add(TaskTodo task); 
    }
}
