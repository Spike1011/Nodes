using System;
using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Notes.Application.Common.Behaviors;

namespace Notes.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(
			this IServiceCollection services)
		{
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
			services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
			services.AddTransient(typeof(IPipelineBehavior<,>),
				typeof(ValidatorBehavior<,>));
            return services;
		}
	}
}

