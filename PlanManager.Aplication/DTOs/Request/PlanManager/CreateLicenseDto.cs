using PlanManager.Domain.Enums;

namespace PlanManager.Aplication.DTOs.Request.PlanManager;

public class CreateLicenseDto {
	public string IdSign { get; set; }
	public string IdPlan { get; set; }
	public decimal Value { get; set; }
	public ELicenseType Type { get; set; }
	public DateOnly? Expire { get; set; }
	public int? ProlongationInDays { get; set; }
}