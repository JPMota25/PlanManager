using PlanManager.Domain.Entities.PlanManager;

namespace PlanManager.Domain.Repositories.PlanManager;

public interface IPlanRepository : IRepository<Plan> {
	Task<Plan?> GetByName(string name, string idCompany);
}