using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Domain.Repositories.PlanManager;

public interface IPlanRepository : IRepository<Plan> {
	Task<Plan?> GetByName(Name name);
}