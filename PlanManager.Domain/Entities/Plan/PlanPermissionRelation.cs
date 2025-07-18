using PlanManager.Domain.ValueObjects;

namespace PlanManager.Domain.Entities.Plan;

public class PlanPermissionRelation : Entity {
	public Id IdPlanPermission { get; private set; }
	public PlanPermission? PlanPermission { get; set; }
	public Id IdPlan { get; private set; }
	public Plan? Plan { get; set; }

	public PlanPermissionRelation() {

	}

	public PlanPermissionRelation(Id idPlanPermission, Id idPlan) {
		IdPlanPermission = idPlanPermission;
		IdPlan = idPlan;
	}
}