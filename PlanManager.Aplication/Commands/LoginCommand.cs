using System.Diagnostics.Contracts;
using Flunt.Notifications;
using Flunt.Validations;
using PlanManager.Domain.Commands;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Commands;

public class LoginCommand : Notifiable<Notification>, ICommand {
	public Username Username { get; set; }
	public string Password { get; set; }

	public void Validate() {
		var contract = new Contract<Notification>();
		AddNotifications(contract);
	}
}