using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlanManager.HangFire.Extensions;
using PlanManager.HangFire.Jobs;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile(Path.Combine(builder.Environment.ContentRootPath, "appsettings.json"), optional: false);

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddHangfire(cfg =>
	cfg.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"), new SqlServerStorageOptions {
		PrepareSchemaIfNecessary = true
	}));

builder.Services.AddHangfireServer();
builder.Services.AddHostedService<RegisterRecurringJobs>();

var app = builder.Build();

app.UseHangfireDashboard("/hangfire");

app.Run();