using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Dto.Extensions
{
    public static class DtoExtensions
    {
        public static IServiceCollection LoadDtoExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
            services.AddFluentValidationAutoValidation();
            return services;
        }
    }
}
