using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

public sealed class PermissionRequirement : IAuthorizationRequirement
{
    public string Key { get; }
    public PermissionRequirement(string key) => Key = key;
}

public sealed class PermissionHandler : AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext ctx, PermissionRequirement req)
    {
        var perms = ctx.User?.FindAll("action").Select(c => c.Value).ToHashSet(StringComparer.OrdinalIgnoreCase)
                    ?? new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        // Se vier em um único claim "perms" como JSON array
        var json = ctx.User?.FindFirst("actions")?.Value;
        if (!string.IsNullOrWhiteSpace(json))
        {
            try
            {
                var arr = System.Text.Json.JsonSerializer.Deserialize<string[]>(json) ?? Array.Empty<string>();
                foreach (var p in arr) perms.Add(p);
            }
            catch { /* ignora se não for JSON */ }
        }

        if (perms.Contains(req.Key))
            ctx.Succeed(req);

        return Task.CompletedTask;
    }
}

public sealed class PermissionPolicyProvider : IAuthorizationPolicyProvider
{
    private const string Prefix = "action:";
    private readonly DefaultAuthorizationPolicyProvider _fallback;

    public PermissionPolicyProvider(IOptions<AuthorizationOptions> options)
        => _fallback = new DefaultAuthorizationPolicyProvider(options);

    public Task<AuthorizationPolicy?> GetDefaultPolicyAsync() => _fallback.GetDefaultPolicyAsync();
    public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() => _fallback.GetFallbackPolicyAsync();

    public Task<AuthorizationPolicy?> GetPolicyAsync(string name)
    {
        if (name.StartsWith(Prefix, StringComparison.OrdinalIgnoreCase))
        {
            var key = name.Substring(Prefix.Length);
            var policy = new AuthorizationPolicyBuilder()
                .AddRequirements(new PermissionRequirement(key))
                .Build();
            return Task.FromResult<AuthorizationPolicy?>(policy);
        }
        return _fallback.GetPolicyAsync(name);
    }
}