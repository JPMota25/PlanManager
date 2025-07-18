using Flunt.Validations;

namespace PlanManager.Domain.ValueObjects;

public class Username : ValueObject {
	public void SetUsername(string username) {
		Value = username;
	}

	public string Value { get; private set; }

	public Username(string value) {
		Value = value;
		Validate();
	}

	private void Validate() {
		var contract = new Contract<Username>().IsBetween(Value.Length, 6, 50, "User.Username", "Username has a minimum of 6 and maximum of 50");
		AddNotifications(contract);
	}
}