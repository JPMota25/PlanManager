using PlanManager.Domain.Entities.PlanManager;

namespace PlanManager.Domain.Repositories.PlanManager;

public interface IPlanPermissionRepository : IRepository<PlanPermission>
{
    Task<bool> VerifyPlanPermissionIsUniqueByName(string name);
}