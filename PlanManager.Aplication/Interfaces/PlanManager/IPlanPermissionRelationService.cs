using PlanManager.Domain.Entities.PlanManager;

namespace PlanManager.Aplication.Interfaces.PlanManager;

public interface IPlanPermissionRelationService
{
    Task<bool> VerifyPlanPermissionRelationIfExists(PlanPermissionRelation permissionRelation);
    Task AddPlanPermissionRelation(PlanPermissionRelation permissionRelation);
}