namespace PlanManager.Aplication.DTOs.Request.PlanManager.PlanPermissionRelation;

public class RequestCreatePlanPermissionRelation
{
    public string IdPlan { get; set; }
    public string IdPlanPermission { get; set; }
    public string IdCompany { get; set; }
}