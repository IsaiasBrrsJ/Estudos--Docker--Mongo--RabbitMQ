using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoList.Application.AddTask.Command;
using TodoList.Application.Task.Querie;
using TodoList.Core.Repositories;


namespace TodoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskTodoController : ControllerBase
    {

        private readonly IMediator _mediator;


        public TaskTodoController(IMediator mediator)
        {
            _mediator = mediator;
       
        }

        [HttpPost("Add-Task")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] TaskAdd taskAdd)
        {
             var result =await _mediator.Send(taskAdd);

            if(!result.IsSuccess)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpGet("Get-All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            var getAll = new GetAll();

           var result = await _mediator.Send(getAll); 

            if(!result.IsSuccess)
                return BadRequest(result);
         

            return Ok(result);
        }

    }
}
