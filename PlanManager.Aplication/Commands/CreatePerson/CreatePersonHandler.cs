using Flunt.Notifications;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Aplication.Interfaces;
using PlanManager.Aplication.Interfaces.Profiles;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Enums;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Commands.CreatePerson;

public class CreatePersonHandler : IHandler<CreatePersonCommand, PersonCreatedDto> {
	private readonly IPersonService _personService;
	private readonly ILogActivityService _logActivityService;

	public CreatePersonHandler(IPersonService personService, ILogActivityService logActivityService) {
		_personService = personService;
		_logActivityService = logActivityService;
	}

	public async Task<ResultDto<PersonCreatedDto>> Handle(CreatePersonCommand command) {
		if (!command.IsValid)
			return ResultDto<PersonCreatedDto>.Fail(command.Notifications);

		var person = new Person(command.FullName, command.Email, command.Document, command.Phone, command.Address);

		if (await _personService.VerifyPerson(person.Document)) {
			person.AddNotification("Person.Create", "Person already exists");
			return ResultDto<PersonCreatedDto>.Fail(person.Notifications);
		}

		await _personService.AddPerson(person);
		await _logActivityService.CreateLog(ELogType.Success, EAction.Created, ELogCode.CreatePerson, person.Id,
			new Description("Person created successfully"));

		return ResultDto<PersonCreatedDto>.Ok(new PersonCreatedDto(person.Id, person.FullName, person.Email));
	}
}