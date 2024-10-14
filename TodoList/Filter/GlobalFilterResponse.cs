using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TodoList.API.Filter
{
    public class GlobalFilterResponse : IActionFilter
    {
        public static Task<GlobalFilterResponse> Create()
       => Task.FromResult(new GlobalFilterResponse());
        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid) {

                var messageError = context.ModelState.Values
                   .SelectMany(x => x.Errors)
                   .Select(x => x.ErrorMessage).ToList();

               context.Result = new BadRequestObjectResult(messageError);
            }
        }
    }
}
