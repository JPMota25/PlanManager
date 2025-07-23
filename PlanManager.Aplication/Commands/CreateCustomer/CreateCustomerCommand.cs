using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Domain.Commands;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Commands.CreateCustomer;

public class CreateCustomerCommand : Notifiable<Notification>, IRequest<ResultDto<PersonCreatedDto>>, ICommand {
	public CreateCustomerCommand(FullName fullName, Email email, Document document, Phone phone, Address address) {
		FullName = fullName;
		Email = email;
		Document = document;
		Phone = phone;
		Address = address;
		Validate();
	}

	public void Validate() {
		var contract = new Contract<Notification>().Requires().IsTrue(FullName.IsValid, "Customer.FullName", "Customer full name Invalid");
		AddNotifications(FullName.Notifications);
		contract.IsTrue(Email.IsValid, "Customer.Email", "Customer email Invalid");
		AddNotifications(Email.Notifications);
		contract.IsTrue(Document.IsValid, "Costumer.Document", "Customer document is invalid");
		AddNotifications(Document.Notifications);
		contract.IsTrue(Phone.IsValid, "Customer.Phone", "Customer phone invalid");
		AddNotifications(Phone.Notifications);
		contract.IsTrue(Address.IsValid, "Customer.Address", "Customer address invalid");
		AddNotifications(Address.Notifications);
		AddNotifications(contract);
	}

	public FullName FullName { get; private set; }
	public Email Email { get; private set; }
	public Document Document { get; private set; }
	public Phone Phone { get; private set; }
	public Address Address { get; private set; }
}