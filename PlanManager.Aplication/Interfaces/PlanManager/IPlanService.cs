using PlanManager.Domain.Entities.PlanManager;

namespace PlanManager.Aplication.Interfaces.PlanManager;

public interface IPlanService {
	Task<Plan?> GetPlanByNameAndCompany(string name, string idCompany);
	Task AddPlan(Plan plan);
}