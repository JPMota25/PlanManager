using Flunt.Notifications;
using Flunt.Validations;

namespace PlanManager.Domain.ValueObjects;

public class Description : ValueObject {
	public void SetValue(string value) {
		Value = value;
		Validate();
	}

	private void Validate() {
		var contract = new Contract<Notification>().Requires().IsBetween(Value.Length, 0, 150, "Description");
		AddNotifications(contract);
	}

	public Description(string value) {
		Value = value;
	}

	public string Value { get; private set; }
}