using PlanManager.Domain.Enums;

namespace PlanManager.Domain.Entities.UserPermission;

public class ScreenPermission : Entity {
	public EScreenPermission Screen { get; init; }
	public string Permission { get; private set; }

	protected ScreenPermission(EScreenPermission screen, string permission) : base(true) {
		Screen = screen;
		Permission = permission;
		Validate();
	}

	public ScreenPermission() { }

	private void Validate() { }
}