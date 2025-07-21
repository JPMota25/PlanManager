using Flunt.Notifications;
using Flunt.Validations;
using PlanManager.Domain.Commands;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Commands.CreatePerson;

public class CreatePersonCommand : Notifiable<Notification>, ICommand {
	public FullName FullName { get; set; }
	public Email Email { get; set; }
	public Document Document { get; set; }
	public Phone Phone { get; set; }
	public Address Address { get; set; }

	public CreatePersonCommand(FullName fullName, Email email, Document document, Phone phone, Address address) {
		FullName = fullName;
		Email = email;
		Document = document;
		Phone = phone;
		Address = address;
		Validate();
	}

	public void Validate() {
		var contract = new Contract<Notification>();
		AddNotifications(contract);
	}
}