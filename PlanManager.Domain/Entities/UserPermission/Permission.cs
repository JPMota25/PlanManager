namespace PlanManager.Domain.Entities.UserPermission;

public class Permission : Entity {
	public void SetStatus(bool isActive) {
		IsActive = isActive;
	}
	public IList<ScreenPermission?> Screen { get; set; }
	public IList<ActionPermission?> Action { get; set; }
	public bool IsActive { get; private set; }

	public Permission() {
		IsActive = true;
		Screen = new List<ScreenPermission?>();
		Action = new List<ActionPermission?>();
		Validate();
	}
	private void Validate() {}
}