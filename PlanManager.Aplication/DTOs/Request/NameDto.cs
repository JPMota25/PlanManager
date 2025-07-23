namespace PlanManager.Aplication.DTOs.Request;

public class NameDto {
	public string Name { get; set; }

	public NameDto(string name) {
		Name = name;
	}
}