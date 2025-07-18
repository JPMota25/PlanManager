namespace PlanManager.Domain.ValueObjects;

public class PermissionCode : ValueObject {
	public void SetCode(string code) {
		Code = code;
	}

	public string Code { get; private set; }

	public PermissionCode() {
		Code = Guid.NewGuid().ToString().Replace("-", "")[..28];
	}
}