using Flunt.Notifications;
using Flunt.Validations;

namespace PlanManager.Domain.Entities.UserPermission;

public class GroupPermission : Entity {
	public void SetStatus(bool isActive) {
		IsActive = isActive;
	}

    public string Name { get; private set; }
	public bool IsActive { get; private set; }
	protected GroupPermission() { }

	public GroupPermission(string name) : base(true) {
		Name = name;
		IsActive = true;
		Validate();
	}

	private void Validate() {
		var contract = new Contract<Notification>().Requires();
		AddNotifications(contract);
	}
}