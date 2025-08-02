using PlanManager.Domain.Enums;

namespace PlanManager.Aplication.DTOs.Request.PlanManager;

public class CreateSignDto {
	public string IdCustomer { get; set; }
	public string IdCompany { get; set; }
	public ESignStatus Status { get; set; }

	public CreateSignDto(string idCustomer, string idCompany, ESignStatus status) {
		IdCustomer = idCustomer;
		IdCompany = idCompany;
		Status = status;
	}
}