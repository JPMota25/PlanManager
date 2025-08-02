using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Domain.Commands;
using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Aplication.Commands.Profiles.Customer.CreateCustomer;

public class CreateCustomerCommand : Notifiable<Notification>, IRequest<ResultDto<PersonCreatedDto>>, ICommand {
	public CreateCustomerCommand(Person person) {
		Person = person;
		Validate();
	}

	public void Validate() {
		var contract = new Contract<Notification>().Requires();
		AddNotifications(contract);
	}

	public Person Person { get; private set; }
}