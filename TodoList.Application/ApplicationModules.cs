using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Application.AddTask.Command;

namespace TodoList.Application
{
    public static class ApplicationModules
    {
        public static IServiceCollection ApplicationService(this IServiceCollection services, IActionFilter filter)
        {

            services
                .AddFilters(filter)
                .Validations()
                .AddMediatR();


            return services;
        }

        private static IServiceCollection AddMediatR(this IServiceCollection services)
        {

            services.AddMediatR(x =>
            {
                x.RegisterServicesFromAssemblyContaining<TaskAdd>();
            });


            return services;
        }

        private static IServiceCollection Validations(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();

            services.AddValidatorsFromAssemblyContaining<TaskAdd>();


            return services;
        }
        private static IServiceCollection AddFilters(this IServiceCollection services, IActionFilter filter)
        {
        

            services
                .AddControllers(x =>
                {
                    x.Filters.Add(filter);
                })
                .ConfigureApiBehaviorOptions(x =>
                {
                    x.SuppressModelStateInvalidFilter = true;
                });
           
            return services;
        }

    }
}
