using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response.Profiles.Person;
using PlanManager.Aplication.Interfaces.Profiles;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Enums;
using PlanManager.Domain.Repositories;

namespace PlanManager.Aplication.Commands.Profiles.Customer.CreateCustomer;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, ResultDto<ResponsePersonCreated>>
{
    private readonly IPersonService _personService;
    private readonly ILogActivityService _logActivityService;
    private readonly ICustomerService _customerService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCustomerHandler(IPersonService personService, ILogActivityService logActivityService, ICustomerService customerService,
        IUnitOfWork unitOfWork)
    {
        _personService = personService;
        _logActivityService = logActivityService;
        _customerService = customerService;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultDto<ResponsePersonCreated>> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        if (!command.Person.IsValid)
            return ResultDto<ResponsePersonCreated>.Fail(command.Person.Notifications);

        Person person = new Person(command.Person.FirstName, command.Person.LastName, command.Person.Email, command.Person.Document, command.Person.Type, command.Person.CountryCode, command.Person.DDD,
            command.Person.NumberWithDigit, command.Person.Neighboorhood, command.Person.HouseNumber, command.Person.HasHouseNumber, command.Person.Complement, command.Person.Street, command.Person.City,
            command.Person.State, command.Person.Country, command.Person.Zipcode);
        if (await _personService.VerifyPersonUniqueKeys(person))
        {
            person.AddNotification("Person.Create", "Person already exists");
            return ResultDto<ResponsePersonCreated>.Fail(person.Notifications);
        }

        Domain.Entities.Profiles.Customer customer = new Domain.Entities.Profiles.Customer(person.Id, command.IdCompany);
        if (await _customerService.VerifyIfCustomerExists(customer))
        {
            customer.AddNotification("Customer.Create", "Customer already exists");
            return ResultDto<ResponsePersonCreated>.Fail(customer.Notifications);
        }

        await _personService.AddPerson(person);
        await _customerService.AddCustomer(customer);
        await _logActivityService.CreateLog(ELogType.Success, EAction.Created, ELogCode.CreateCustomer, customer.Id, "Customer created successfully.");
        await _unitOfWork.CommitAsync();

        return ResultDto<ResponsePersonCreated>.Ok(new ResponsePersonCreated(customer.Id, person.FirstName + person.LastName, person.Email));
    }
}