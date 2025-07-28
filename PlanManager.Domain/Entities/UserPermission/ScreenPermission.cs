using PlanManager.Domain.Enums;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Domain.Entities.UserPermission;

public class ScreenPermission : Entity {
	public EScreenPermission Screen { get; init; }
	public Id Permission { get; private set; }
	protected ScreenPermission(EScreenPermission screen, Id permission) {
		Screen = screen;
		Permission = permission;
		Validate();
	}
	private void Validate() {}
}