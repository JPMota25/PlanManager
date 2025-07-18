using Flunt.Notifications;
using PlanManager.Domain.Commands;

namespace PlanManager.Aplication.Commands;

public class CreateUserCommand : Notifiable<Notification>, ICommand {
	public void Validate() {
		throw new NotImplementedException();
	}
}