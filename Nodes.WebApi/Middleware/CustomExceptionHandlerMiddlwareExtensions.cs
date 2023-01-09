using System;
using Microsoft.AspNetCore.Builder;

namespace Nodes.WebApi.Middleware
{
	public static class CustomExceptionHandlerMiddlwareExtensions
	{
		public static IApplicationBuilder UseCustomExceptionHandler(this
			IApplicationBuilder builder)
		{
			return builder.UseMiddleware<CustomExceptionHandlerMiddlware>();
		}
	}
}

