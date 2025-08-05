namespace PlanManager.Aplication.DTOs.Request.PlanManager;

public class CreatePlanDto {
	public string Name { get; set; }
	public decimal Value { get; set; }
	public string IdCompany { get; set; }

	public CreatePlanDto(string name, decimal value, string idCompany) {
		Name = name;
		Value = value;
		IdCompany = idCompany;
	}
}