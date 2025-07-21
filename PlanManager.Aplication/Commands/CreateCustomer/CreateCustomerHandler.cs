using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Aplication.Interfaces;
using PlanManager.Aplication.Interfaces.Profiles;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.ValueObjects;
using SlotMe.Domain.Enums;

namespace PlanManager.Aplication.Commands.CreateCustomer;

public class CreateCustomerHandler : IHandler<CreateCustomerCommand, PersonCreatedDto> {
	private readonly IPersonService _personService;
	private readonly ILogActivityService _logActivityService;
	private readonly ICustomerService _customerService;

	public CreateCustomerHandler(IPersonService personService, ILogActivityService logActivityService, ICustomerService customerService) {
		_personService = personService;
		_logActivityService = logActivityService;
		_customerService = customerService;
	}

	public async Task<ResultDto<PersonCreatedDto>> Handle(CreateCustomerCommand command) {
		if (!command.IsValid)
			return ResultDto<PersonCreatedDto>.Fail(command.Notifications);

		var person = new Person(command.FullName, command.Email, command.Document, command.Phone, command.Address);
		if (await _personService.VerifyPerson(person.Document)) {
			person.AddNotification("Person.Create", "Person already exists");
			return ResultDto<PersonCreatedDto>.Fail(person.Notifications);
		}

		var customer = new Customer(person.Id);
		if (!await _customerService.VerifyIfCustomerExists(customer.IdPerson.Identifier)) {
			customer.AddNotification("Customer.Create", "Customer already exists");
			return ResultDto<PersonCreatedDto>.Fail(customer.Notifications);
		}

		await _personService.AddPerson(person);
		await _customerService.AddCustomer(customer);
		await _logActivityService.CreateLog(ELogType.Success, EAction.Created, ELogCode.CreateCustomer, customer.Id,
			new Description("Customer created successfully."));

		return ResultDto<PersonCreatedDto>.Ok(new PersonCreatedDto(customer.Id, person.FullName, person.Email));
	}
}