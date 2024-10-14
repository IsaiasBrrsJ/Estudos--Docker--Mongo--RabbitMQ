using TodoList.Core.Model;
using TodoList.Core.Repositories;

namespace TodoList.Infrastructure.Persistence.Repositories
{
    internal class TaskPublishMongo : ITaskPublishMongo
    {
        private readonly MongoDbContext _dbContext;

        public TaskPublishMongo(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(TaskTodo task)
        {
            await _dbContext.Tasks.InsertOneAsync(task);
        }
    }
}
