namespace PlanManager.Aplication.DTOs.Response.PlanManager.Plan;

public class ResponsePlanCreated
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }
    public string IdCompany { get; set; }

    public ResponsePlanCreated(string id, string name, decimal value, string idCompany)
    {
        Id = id;
        Name = name;
        Value = value;
        IdCompany = idCompany;
    }
}