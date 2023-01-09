using System;
using FluentValidation;
using MediatR;

namespace Notes.Application.Common.Behaviors
{
    public class ValidatorBehavior<TRequest, TResponce>
        : IPipelineBehavior<TRequest, TResponce> where TRequest : IRequest<TResponce>
    {

        private readonly IEnumerable<IValidator<TRequest>> _validator;

        public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validator) =>
            _validator = validator;

        public Task<TResponce> Handle(TRequest request, RequestHandlerDelegate<TResponce> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validator
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null)
                .ToList();
            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }
            return next();
        }
    }
}

