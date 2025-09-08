using Microsoft.Extensions.Hosting;

namespace PlanManager.HangFire.Jobs;

public class RegisterRecurringJobs : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public RegisterRecurringJobs(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}