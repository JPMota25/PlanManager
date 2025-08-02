using PlanManager.Domain.Enums;

namespace PlanManager.Aplication.DTOs.Request.Profiles;

public class CreateUserDto {
	public CreatePersonDto Person { get; set; }
	public string Username { get; set; }
	public string Password { get; set; }

	public CreateUserDto(CreatePersonDto person, string username, string password) {
		Person = person;
		Username = username;
		Password = password;
	}
}