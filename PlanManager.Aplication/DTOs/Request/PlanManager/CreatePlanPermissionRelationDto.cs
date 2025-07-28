using PlanManager.Aplication.DTOs.Request.ValueObjects;

namespace PlanManager.Aplication.DTOs.Request;

public class CreatePlanPermissionRelationDto {
	public IdDto Plan { get; set; }
	public IdDto PlanPermission { get; set; }
}