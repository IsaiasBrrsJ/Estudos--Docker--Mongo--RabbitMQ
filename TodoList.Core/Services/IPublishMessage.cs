namespace TodoList.Core.Services
{
    public interface IPublishMessage
    {
        Task publish<T>(T message) where T : class;
    }
}
