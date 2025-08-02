using PlanManager.Aplication.Interfaces.PlanManager;
using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.Repositories.PlanManager;

namespace PlanManager.Aplication.Services.PlanManager;

public class PlanService : IPlanService {
	private readonly IPlanRepository _planRepository;

	public PlanService(IPlanRepository planRepository) {
		_planRepository = planRepository;
	}

	public async Task<Plan?> GetPlanByNameAndCompany(string name, string idCompany) {
		return await _planRepository.GetByName(name, idCompany);
	}

	public async Task AddPlan(Plan plan) {
		await _planRepository.AddAsync(plan);
	}
}