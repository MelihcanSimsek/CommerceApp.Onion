using CommerceApp.Application.Bases;
using CommerceApp.Application.Behaviours;
using CommerceApp.Application.Exceptions;
using CommerceApp.Application.Features.Products.Rules;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);

            services.AddTransient<ExceptionMiddleware>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));
            return services;
        }

        private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services,Assembly assembly,Type type)
        {
            var rules = assembly.GetTypes().Where(p => p.IsSubclassOf(type) && type != p).ToList();
            foreach (var rule in rules)
                services.AddTransient(rule);

            return services;
        }
    }
}
