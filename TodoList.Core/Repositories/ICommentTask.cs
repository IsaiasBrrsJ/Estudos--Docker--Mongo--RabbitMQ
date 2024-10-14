using TodoList.Core.BaseResult;
using TodoList.Core.Model;

namespace TodoList.Core.Repositories
{
    public interface  ICommentTask
    {
        Task<Guid> AddAsync(Comment comment);
        Task<Comment> GetCommentByDate(DateTime dateTime, Guid TaskId);
        Task UpdateAsync(Comment comment);
        Task DeleteAsync(Guid commentId);
        Task<IEnumerable<Comment>> GetAllCommentByIdAsync(Guid TaskId);
    }
}
