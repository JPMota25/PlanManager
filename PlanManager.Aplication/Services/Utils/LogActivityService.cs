using Microsoft.AspNetCore.Http;
using PlanManager.Aplication.Interfaces;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Entities.Utils;
using PlanManager.Domain.Repositories.Utils;
using PlanManager.Domain.ValueObjects;
using SlotMe.Domain.Enums;

namespace PlanManager.Aplication.Services.Utils;

public class LogActivityService : ILogActivityService {
	private readonly ILogActivityRepository _logActivityRepository;
	private readonly IHttpContextAccessor _httpContextAccessor;

	public LogActivityService(ILogActivityRepository logActivityRepository, IHttpContextAccessor httpContextAccessor) {
		_logActivityRepository = logActivityRepository;
		_httpContextAccessor = httpContextAccessor;
	}


	public async Task CreateLog(ELogType type, EAction action, ELogCode code, Id objectId, Description description) {
		var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst("UserId");
		var userId = new Id(userIdClaim != null ? userIdClaim.Value : "76207e5b-3fc5-4ad6-a7c0-c7bb7d1cfcae");
		if (userId == Id.Empty)
			throw new Exception("Usuário não autenticado.");
		var create = new LogActivity(userId, type, action, code, objectId, description);
		await _logActivityRepository.AddAsync(create);
		await _logActivityRepository.SaveChangesAsync();
	}
}