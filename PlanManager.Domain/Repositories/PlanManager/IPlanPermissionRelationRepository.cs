using PlanManager.Domain.Entities.PlanManager;

namespace PlanManager.Domain.Repositories.PlanManager;

public interface IPlanPermissionRelationRepository : IRepository<PlanPermissionRelation> {
	Task<PlanPermissionRelation?> VerifyPlanPermissionRelation(PlanPermissionRelation permissionRelation);
}