using PlanManager.Aplication.Interfaces.PlanManager;
using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.Repositories.PlanManager;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Services.PlanManager;

public class PlanService : IPlanService {
	private readonly IPlanRepository _planRepository;

	public PlanService(IPlanRepository planRepository) {
		_planRepository = planRepository;
	}

	public async Task<Plan?> GetPlanByName(Name name) {
		return await _planRepository.GetByName(name);
	}

	public async Task AddPlan(Plan plan) {
		await _planRepository.AddAsync(plan);
		await _planRepository.SaveChangesAsync();
	}
}