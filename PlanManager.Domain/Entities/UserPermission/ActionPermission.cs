using PlanManager.Domain.Enums;

namespace PlanManager.Domain.Entities.UserPermission;

public class ActionPermission : Entity {
	public ActionPermission() { }
	public EActionPermission Action { get; private set; }
	public string Permission { get; private set; }

	public ActionPermission(EActionPermission action, string permission) : base(true) {
		Action = action;
		Permission = permission;
		Validate();
	}

	private void Validate() { }
}