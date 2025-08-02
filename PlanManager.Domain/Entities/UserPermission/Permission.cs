using Flunt.Notifications;
using Flunt.Validations;

namespace PlanManager.Domain.Entities.UserPermission;

public class Permission : Entity {
	public void SetStatus(bool isActive) {
		IsActive = isActive;
	}

	public IList<ScreenPermission?> Screen { get; set; }
	public IList<ActionPermission?> Action { get; set; }
	public bool IsActive { get; private set; }

	protected Permission() { }

	public Permission(IList<ScreenPermission?> screen, IList<ActionPermission?> action) : base(true) {
		IsActive = true;
		Screen = screen;
		Action = action;
		Validate();
	}

	private void Validate() {
		var contract = new Contract<Notification>().Requires();
		AddNotifications(contract);
	}
}