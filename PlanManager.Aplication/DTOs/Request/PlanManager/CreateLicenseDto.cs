using PlanManager.Aplication.DTOs.Request.ValueObjects;
using PlanManager.Domain.Enums;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.DTOs.Request.PlanManager;

public class CreateLicenseDto {
	public IdDto IdSign { get; set; }
	public IdDto IdPlan { get; set; }
	public ValueDto Value { get;  set; }
	public ELicenseType Type { get;  set; }
	public ExpireDate? ExpireDate { get; set; }
	public CreateLicenseDto(IdDto idSign, IdDto idPlan, ValueDto value, ELicenseType type, ExpireDate? expireDate) {
		IdSign = idSign;
		IdPlan = idPlan;
		Value = value;
		Type = type;
		ExpireDate = expireDate;
	}
}