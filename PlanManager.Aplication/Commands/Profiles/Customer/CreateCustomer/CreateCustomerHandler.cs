using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Aplication.Interfaces.Profiles;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Enums;
using PlanManager.Domain.Repositories;

namespace PlanManager.Aplication.Commands.Profiles.Customer.CreateCustomer;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, ResultDto<PersonCreatedDto>> {
	private readonly IPersonService _personService;
	private readonly ILogActivityService _logActivityService;
	private readonly ICustomerService _customerService;
	private readonly IUnitOfWork _unitOfWork;

	public CreateCustomerHandler(IPersonService personService, ILogActivityService logActivityService, ICustomerService customerService,
		IUnitOfWork unitOfWork) {
		_personService = personService;
		_logActivityService = logActivityService;
		_customerService = customerService;
		_unitOfWork = unitOfWork;
	}

	public async Task<ResultDto<PersonCreatedDto>> Handle(CreateCustomerCommand command, CancellationToken cancellationToken) {
		var request = command.Person;
		if (!request.IsValid)
			return ResultDto<PersonCreatedDto>.Fail(command.Notifications);

		var person = new Person(request.FirstName, request.LastName, request.Email, request.Document, request.Type, request.CountryCode, request.DDD,
			request.NumberWithDigit, request.Neighboorhood, request.HouseNumber, request.HasHouseNumber, request.Complement, request.Street, request.City,
			request.State, request.Country, request.Zipcode);
		if (await _personService.VerifyPersonByDocument(person.Document)) {
			person.AddNotification("Person.Create", "Person already exists");
			return ResultDto<PersonCreatedDto>.Fail(person.Notifications);
		}

		var customer = new Domain.Entities.Profiles.Customer(person.Id);
		if (await _customerService.VerifyIfCustomerExists(customer.IdPerson)) {
			customer.AddNotification("Customer.Create", "Customer already exists");
			return ResultDto<PersonCreatedDto>.Fail(customer.Notifications);
		}

		await _personService.AddPerson(person);
		await _customerService.AddCustomer(customer);
		await _logActivityService.CreateLog(ELogType.Success, EAction.Created, ELogCode.CreateCustomer, customer.Id, "Customer created successfully.");
		await _unitOfWork.CommitAsync();

		return ResultDto<PersonCreatedDto>.Ok(new PersonCreatedDto(customer.Id, person.FirstName + person.LastName, person.Email));
	}
}