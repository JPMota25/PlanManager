using PlanManager.Domain.DTOs.Response;
using PlanManager.Domain.Entities.PlanManager;

namespace PlanManager.Domain.Repositories.PlanManager;

public interface IPlanRepository : IRepository<Plan> {
	Task<Plan?> GetByName(string name, string idCompany);
	Task<IList<PlanDto>> ListPlans(string? id, string? name, string idCompany, int skip, int take);
}