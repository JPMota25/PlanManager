namespace PlanManager.Aplication.DTOs.Request.PlanManager;

public class CreatePlanPermissionRelationDto {
	public string IdPlan { get; set; }
	public string IdPlanPermission { get; set; }
    public string IdCompany { get; set; }
}