using MediatR;
using TodoList.Application.ViewModel;
using TodoList.Core.BaseResult;
using TodoList.Core.Model;

namespace TodoList.Application.Comments.Querie
{
    public class GetAllCommentByIdTask : IRequest<ResultViewModel<IEnumerable<CommentViewModel>>>
    {
        public Guid TaskId { get; set; }    

        public IEnumerable<CommentViewModel> ToViewModel(IEnumerable<Comment> comment)
        {
            return comment.Select(x => new CommentViewModel(x.Comments, x.PostedAt, x.TaskId)).ToList();
        }
    }
}
