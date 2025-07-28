using PlanManager.Aplication.DTOs.Request.ValueObjects;
using PlanManager.Domain.Enums;

namespace PlanManager.Aplication.DTOs.Request.PlanManager;

public class CreateSignDto {
	public IdDto IdCustomer { get;  set; }
	public IdDto IdCompany { get;  set; }
	public ESignStatus Status { get; set; }
	public CreateSignDto(IdDto idCustomer, IdDto idCompany, ESignStatus status) {
		IdCustomer = idCustomer;
		IdCompany = idCompany;
		Status = status;
	}
}