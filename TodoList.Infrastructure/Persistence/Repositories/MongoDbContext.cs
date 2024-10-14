using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using TodoList.Core.Model;

namespace TodoList.Infrastructure.Persistence.Repositories
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _mongoDb;

        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MONGO:Connection"]);

            _mongoDb = client.GetDatabase(configuration["Mongo:Database"]);
           
        }

        public IMongoCollection<TaskTodo> Tasks => _mongoDb.GetCollection<TaskTodo>("Task");

    }
}
