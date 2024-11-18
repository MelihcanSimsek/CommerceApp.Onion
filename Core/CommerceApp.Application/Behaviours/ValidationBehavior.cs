using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Application.Behaviours
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validator;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
        {
            this.validator = validator;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failtures = validator.Select(p => p.Validate(context))
                .SelectMany(c => c.Errors)
                .GroupBy(x => x.ErrorMessage)
                .Select(v => v.First())
                .Where(a => a != null)
                .ToList();
            if (failtures.Any()) throw new ValidationException(failtures);

            return next();
        }
    }

}
