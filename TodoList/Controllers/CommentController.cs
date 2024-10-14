using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Application.Comments.Command;
using TodoList.Application.Comments.Querie;

namespace TodoList.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Add-Comment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] AddComment comment)
        {
           var result = await _mediator.Send(comment);
        
          if(!result.IsSuccess)
                return BadRequest(result);


          return Ok(result);    
        }

        [HttpGet("Task/{id:Guid}/All-Comments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll([FromRoute] Guid  id)
        {
            var commentById = new GetAllCommentByIdTask() { TaskId = id };

           var result = await _mediator.Send(commentById);

            if(!result.Data!.Any())
                return NotFound(result);
        
            
            return Ok(result);
        }
        

    }
}
