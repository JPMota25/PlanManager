namespace PlanManager.Aplication.DTOs.Request.Profiles;

public class CreateCustomerDto {
	public CreatePersonDto Person { get; set; }

	public CreateCustomerDto(CreatePersonDto person) {
		Person = person;
	}
}