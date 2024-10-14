using MediatR;
using TodoList.Application.Extension;
using TodoList.Application.ViewModel;
using TodoList.Core.BaseResult;
using TodoList.Core.Repositories;

namespace TodoList.Application.Comments.Querie
{
    public class GetAllCommentByIdTaskHandler : IRequestHandler<GetAllCommentByIdTask, ResultViewModel<IEnumerable<CommentViewModel>>>
    {
        private readonly ICommentTask _commentTask;
        public GetAllCommentByIdTaskHandler(ICommentTask commentTask)
        {
            _commentTask = commentTask;
        }

        public async Task<ResultViewModel<IEnumerable<CommentViewModel>>> Handle(GetAllCommentByIdTask request, CancellationToken cancellationToken)
        {
            var result = await _commentTask.GetAllCommentByIdAsync(request.TaskId);

            if (!result.HasValueInColletion())
                return ResultViewModel<IEnumerable<CommentViewModel>>.Success(Enumerable.Empty<CommentViewModel>(), "List is empty");
            

            var resultToView = request.ToViewModel(result);

            return ResultViewModel<IEnumerable<CommentViewModel>>.Success(resultToView, "List items");

        }
    }
}
