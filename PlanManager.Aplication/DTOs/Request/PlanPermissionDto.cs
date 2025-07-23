namespace PlanManager.Aplication.DTOs.Request;

public class PlanPermissionDto {
	public PlanPermissionDto(NameDto name, IdDto idCompany) {
		Name = name;
		IdCompany = idCompany;
	}

	public NameDto Name { get; set; }
	public IdDto IdCompany { get; set; }

	public PlanPermissionDto() { }
}