using Flunt.Notifications;
using Flunt.Validations;

namespace PlanManager.Domain.ValueObjects;

public class Value : ValueObject {
	public void SetValue(decimal value) {
		ValueWith2Digits = value;
		Validate();
	}

	public decimal ValueWith2Digits { get; private set; }

	public Value() { }

	public Value(decimal valueWith2Digits) {
		ValueWith2Digits = valueWith2Digits;
		Validate();
	}

	private void Validate() {
		var contract = new Contract<Notification>().Requires().IsTrue(ValidValueWith2Digits(ValueWith2Digits), "Value.ValueWith2Digits");
		AddNotifications(contract);
	}

	private bool ValidValueWith2Digits(decimal value) {
		return value >= 0;
	}
}