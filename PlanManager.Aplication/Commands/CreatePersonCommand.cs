using Flunt.Notifications;
using Flunt.Validations;
using PlanManager.Domain.Commands;
using PlanManager.Domain.Enums;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Commands;

public class CreatePersonCommand : Notifiable<Notification>, ICommand {
	public EPersonStatus Status { get; set; }
	public FullName FullName { get; set; }
	public Email Email { get; set; }
	public Document Document { get; set; }
	public Phone Phone { get; set; }
	public Address Address { get; set; }

	public void Validate() {
		var contract = new Contract<Notification>();
		AddNotifications(contract);
	}
}