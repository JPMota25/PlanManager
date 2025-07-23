using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Interfaces.PlanManager;

public interface IPlanPermissionService {
	Task AddPlanPermission(PlanPermission planPermission);
	Task<bool> VerifyIfPlanPermissionIsUniqueByName(Name name);
}