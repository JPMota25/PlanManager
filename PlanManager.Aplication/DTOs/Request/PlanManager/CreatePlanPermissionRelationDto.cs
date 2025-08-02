namespace PlanManager.Aplication.DTOs.Request.PlanManager;

public class CreatePlanPermissionRelationDto {
	public string IdPlan { get; set; }
	public string IdPlanPermission { get; set; }

	public CreatePlanPermissionRelationDto(string idPlan, string idPlanPermission) {
		IdPlan = idPlan;
		IdPlanPermission = idPlanPermission;
	}
}