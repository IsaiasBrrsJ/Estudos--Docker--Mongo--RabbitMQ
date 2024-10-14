using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TodoList.Core.Repositories;
using TodoList.Core.Services;
using TodoList.Infrastructure.Messages.Produces;
using TodoList.Infrastructure.Persistence.Repositories;

namespace TodoList.Infrastructure
{
    public static class InfrastructureModules
    {
        public static IServiceCollection AddInfrasctructure(this IServiceCollection service)
        {
            service
                .AddInjectionDependency()
                .AddBaseDb();


            return service;
        }

        private static IServiceCollection AddBaseDb(this IServiceCollection service)
        {
            service
                .AddDbContext<TodoContext>(x =>
                {
                    x.UseInMemoryDatabase("TaskTodo");
                });

            service
                .AddSingleton<MongoDbContext>();


            return service;
        }

        private static IServiceCollection AddInjectionDependency(this IServiceCollection service)
        {
            service
                .AddScoped<ITaskTodo, TaskTodoRepositories>()
                .AddScoped<ICommentTask, CommentRepository>()
                .AddScoped<IPublishMessage, PublishMessage>()
                .AddScoped<ITaskPublishMongo, TaskPublishMongo>();
               


            return service;
        }
    }
}
