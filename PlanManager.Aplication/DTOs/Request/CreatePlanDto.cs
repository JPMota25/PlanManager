namespace PlanManager.Aplication.DTOs.Request;

public class CreatePlanDto {
	public NameDto Name { get; set; }
	public ValueDto Value { get; set; }
	public IdDto IdCompany { get; set; }
}