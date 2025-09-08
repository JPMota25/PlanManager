namespace PlanManager.Aplication.DTOs.Response.PlanManager.PlanPermissionRelation;

public class ResponsePlanPermissionRelationCreated
{
    public string Id { get; set; }
    public string Plan { get; set; }
    public string PlanPermission { get; set; }
    public DateTime CreatedAt { get; set; }

    public ResponsePlanPermissionRelationCreated(string id, string plan, string planPermission, DateTime createdAt)
    {
        Id = id;
        Plan = plan;
        PlanPermission = planPermission;
        CreatedAt = createdAt;
    }
}