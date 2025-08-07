using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlanManager.Infrastructure.Data;

namespace PlanManager.HangFire.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		// Exemplo: banco de dados, serviços, etc.
		services.AddDbContext<PlanManagerDbContext>(options =>
			options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

		return services;
	}
}