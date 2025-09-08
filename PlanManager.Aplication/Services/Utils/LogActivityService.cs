using Microsoft.AspNetCore.Http;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Entities.Utils;
using PlanManager.Domain.Enums;
using PlanManager.Domain.Repositories.Utils;

namespace PlanManager.Aplication.Services.Utils;

public class LogActivityService : ILogActivityService
{
    private readonly ILogActivityRepository _logActivityRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LogActivityService(ILogActivityRepository logActivityRepository, IHttpContextAccessor httpContextAccessor)
    {
        _logActivityRepository = logActivityRepository;
        _httpContextAccessor = httpContextAccessor;
    }


    public async Task CreateLog(ELogType type, EAction action, ELogCode code, string objectId, string description)
    {
        var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst("UserId");
        var userId = userIdClaim != null ? userIdClaim.Value : "Sistema";
        if (userId == Guid.Empty.ToString())
            throw new Exception("Usuário não autenticado.");
        var create = new LogActivity(userId, type, action, code, objectId, description);
        await _logActivityRepository.AddAsync(create);
    }
}