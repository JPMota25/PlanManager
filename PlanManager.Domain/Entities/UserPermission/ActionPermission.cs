using PlanManager.Domain.Enums;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Domain.Entities.UserPermission;

public class ActionPermission : Entity {
	public EActionPermission Action { get; private set; }
	public Id Permission { get; private set; }
	public ActionPermission(EActionPermission action, Id permission) {
		Action = action;
		Permission = permission;
		Validate();
	}
	private void Validate() {}
}