using PlanManager.Domain.Entities.PlanManager;

namespace PlanManager.Aplication.Interfaces.PlanManager;

public interface IPlanPermissionService {
	Task AddPlanPermission(PlanPermission planPermission);
	Task<bool> VerifyIfPlanPermissionIsUniqueByName(string name);
}