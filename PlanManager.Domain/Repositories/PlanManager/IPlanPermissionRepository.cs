using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Domain.Repositories.PlanManager;

public interface IPlanPermissionRepository : IRepository<PlanPermission> {
	Task<bool> VerifyPlanPermissionIsUniqueByName(Name name);
}