using Flunt.Notifications;
using Flunt.Validations;

namespace PlanManager.Domain.ValueObjects;

public class Name : ValueObject {
	public void SetValue(string value) {
		Value = value;
	}

	public string Value { get; private set; }

	public Name(string value) {
		Value = value;
		Validate();
	}

	public Name() { }

	private void Validate() {
		var contract = new Contract<Notification>().Requires().IsBetween(Value.Length, 4, 30, "Name.Value", "Name should have beetween 4 and 30 characters");
		AddNotifications(contract);
	}
}