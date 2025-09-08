namespace PlanManager.Aplication.DTOs.Response;

public class PlanPermissionRelationCreatedDto
{
    public string Id { get; set; }
    public string Plan { get; set; }
    public string PlanPermission { get; set; }
    public DateTime CreatedAt { get; set; }

    public PlanPermissionRelationCreatedDto(string id, string plan, string planPermission, DateTime createdAt)
    {
        Id = id;
        Plan = plan;
        PlanPermission = planPermission;
        CreatedAt = createdAt;
    }
}