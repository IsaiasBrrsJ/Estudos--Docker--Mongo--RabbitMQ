using TodoList.Core.Model;

namespace TodoList.Core.Repositories
{
    public interface ITaskTodo
    {
        Task<Guid> AddAsync(TaskTodo task);
        Task UpdateAsync(TaskTodo task);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<TaskTodo>> GetAllAsync();
        Task<TaskTodo> GetByIdAsync(Guid id);
    }
}
