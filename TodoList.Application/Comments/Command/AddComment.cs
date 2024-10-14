using MediatR;
using TodoList.Core.BaseResult;
using TodoList.Core.Model;

namespace TodoList.Application.Comments.Command
{
    public class AddComment : IRequest<ResultViewModel<Guid>>
    {

        public string Comments { get; set; } = default!;
        public Guid TaskId { get; set; }

        public Comment ToEntity() { 
          return new Comment(Comments, TaskId); 
        }


      
    }
}
