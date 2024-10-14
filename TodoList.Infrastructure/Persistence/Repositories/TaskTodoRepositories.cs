using Microsoft.EntityFrameworkCore;
using TodoList.Core.Model;
using TodoList.Core.Repositories;

namespace TodoList.Infrastructure.Persistence.Repositories
{
    internal class TaskTodoRepositories : ITaskTodo
    {
        private readonly TodoContext _context;
        public TaskTodoRepositories(TodoContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(TaskTodo task)
        {
             await _context.AddAsync(task);
             await _context.SaveChangesAsync();

            return task.Id;
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TaskTodo>> GetAllAsync()
        {
           var result =  await _context.TaskTodo.ToListAsync();

           return result;
        }

        public Task<TaskTodo> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TaskTodo task)
        {
            throw new NotImplementedException();
        }
    }
}
