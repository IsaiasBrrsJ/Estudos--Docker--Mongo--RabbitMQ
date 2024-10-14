using MediatR;
using TodoList.Core.BaseResult;
using TodoList.Core.Repositories;

namespace TodoList.Application.Comments.Command
{
    public class AddCommentHandler : IRequestHandler<AddComment, ResultViewModel<Guid>>
    {
        private readonly ICommentTask _commentTask;
        public AddCommentHandler(ICommentTask commentTask)
        {
            _commentTask = commentTask;
        }

        public async Task<ResultViewModel<Guid>> Handle(AddComment request, CancellationToken cancellationToken)
        {
            var commentsEntity = request.ToEntity();

           var result =  await _commentTask.AddAsync(commentsEntity);

            if (result == Guid.Empty)
                return ResultViewModel<Guid>.Failure(Guid.Empty, "Failed to insert comment");


            return ResultViewModel<Guid>.Success(result, "Comment successfully inserted");
        }
    }
}
