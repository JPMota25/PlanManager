using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Enums;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Api.Middlewares;

public class ExceptionMiddleware {
	private readonly RequestDelegate _next;
	private readonly ILogger<ExceptionMiddleware> _logger;
	private readonly IServiceProvider _services;

	public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IServiceProvider services) {
		_services = services;
		_next = next;
		_logger = logger;
	}

	public async Task InvokeAsync(HttpContext context) {
		try {
			await _next(context);
		}
		catch (Exception ex) {
			_logger.LogError(ex, "Unhandled exception.");
			context.Response.StatusCode = 500;
			await context.Response.WriteAsync("Unexpected error occurred.");
		}
	}

	private async Task CreateLogError(EAction action, ELogCode code, string message) {
		using var scope = _services.CreateScope();
		var logService = scope.ServiceProvider.GetRequiredService<ILogActivityService>();
		await logService.CreateLog(ELogType.Error, action, code, Id.Empty, new Description(message));
	}
}