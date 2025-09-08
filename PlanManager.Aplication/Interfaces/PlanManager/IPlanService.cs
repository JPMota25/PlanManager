using PlanManager.Aplication.Commands.PlanManager.Plans.PlanQuery;
using PlanManager.Domain.DTOs.Response;
using PlanManager.Domain.Entities.PlanManager;

namespace PlanManager.Aplication.Interfaces.PlanManager;

public interface IPlanService
{
    Task<Plan?> GetPlanByNameAndCompany(string name, string idCompany);
    Task AddPlan(Plan plan);
    Task<IList<PlanDto>> ListPlans(PlanQueryCommand command);
}