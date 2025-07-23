using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Interfaces.PlanManager;

public interface IPlanService {
	Task<Plan?> GetPlanByName(Name name);
	Task AddPlan(Plan plan);
}