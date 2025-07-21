using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.DTOs.Response;

public class PersonCreatedDto {
	public Id Id { get; set; }
	public FullName Name { get; set; }
	public Email Email { get; set; }

	public PersonCreatedDto(Id id, FullName name, Email email) {
		Id = id;
		Name = name;
		Email = email;
	}
}