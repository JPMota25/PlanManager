using PlanManager.Aplication.Interfaces.PlanManager;
using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.Repositories.PlanManager;

namespace PlanManager.Aplication.Services.PlanManager;

public class SignService : ISignService {
	private readonly ISignRepository _signRepository;

	public SignService(ISignRepository signRepository) {
		_signRepository = signRepository;
	}

	public async Task<bool> VerifyIfSignExists(Sign sign) {
		var result = await _signRepository.GetSign(sign);
		return result != null;
	}

	public async Task AddSign(Sign sign) {
		await _signRepository.AddAsync(sign);
	}
}