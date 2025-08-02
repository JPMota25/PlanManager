namespace PlanManager.Aplication.DTOs.Request.PlanManager;

public class PlanPermissionDto {
	public PlanPermissionDto(string name, string idCompany) {
		Name = name;
		IdCompany = idCompany;
	}

	public string Name { get; set; }
	public string IdCompany { get; set; }

	public PlanPermissionDto() { }
}