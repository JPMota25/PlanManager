namespace PlanManager.Aplication.DTOs.Request.ValueObjects;

public class NameDto {
	public string Name { get; set; }

	public NameDto(string name) {
		Name = name;
	}
}