namespace PlanManager.Aplication.DTOs.Request.PlanManager.Plan;

public class RequestPlanReport
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string IdCompany { get; set; }
    public int Skip { get; set; }
    public int Take { get; set; }
}