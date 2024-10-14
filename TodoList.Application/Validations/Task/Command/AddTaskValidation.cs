using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using TodoList.Application.AddTask.Command;

namespace TodoList.Application.Validations.Task.Command
{
    public class AddTaskValidation : AbstractValidator<TaskAdd>
    {
        public AddTaskValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Nome não pode ser vazio ou nulo");
        }
    }
}
