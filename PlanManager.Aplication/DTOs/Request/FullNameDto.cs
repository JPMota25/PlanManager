namespace PlanManager.Aplication.DTOs.Request;

public class FullNameDto {
	public FullNameDto(string firstName, string lastName) {
		FirstName = firstName;
		LastName = lastName;
	}

	public FullNameDto() {

	}
	public string FirstName { get; set; }
	public string LastName { get; set; }
}