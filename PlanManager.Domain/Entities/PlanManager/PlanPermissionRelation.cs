namespace PlanManager.Domain.Entities.PlanManager;

public class PlanPermissionRelation : Entity {
	public string IdPlanPermission { get; private set; }
	public PlanPermission? PlanPermission { get; set; }
	public string IdPlan { get; private set; }
	public Plan? Plan { get; set; }

	public PlanPermissionRelation() { }

	public PlanPermissionRelation(string idPlanPermission, string idPlan) : base(true) {
		IdPlanPermission = idPlanPermission;
		IdPlan = idPlan;
	}
}