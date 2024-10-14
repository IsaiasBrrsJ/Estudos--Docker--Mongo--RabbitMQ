using Microsoft.EntityFrameworkCore;
using TodoList.Core.Model;
using TodoList.Core.Repositories;

namespace TodoList.Infrastructure.Persistence.Repositories
{
    internal class CommentRepository : ICommentTask
    {
        private readonly TodoContext _todoContext;

        public CommentRepository(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public async Task<Guid> AddAsync(Comment comment)
        {
            await _todoContext.AddAsync(comment);
            await _todoContext.SaveChangesAsync();  
            
            return comment.Id;
        }

        public Task DeleteAsync(Guid commentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Comment>> GetAllCommentByIdAsync(Guid TaskId)
        {
           var result = await _todoContext.Comment
                                          .Where(x => x.TaskId == TaskId)
                                          .ToListAsync();


            return result;
        }

        public async Task<Comment> GetCommentByDate(DateTime dateTime, Guid TaskId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
