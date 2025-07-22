using Flunt.Validations;

namespace PlanManager.Domain.ValueObjects;

public class FullName : ValueObject {
	public void SetFirstName(string firstName) {
		FirstName = firstName;
		Validate();
	}

	public void SetLastName(string lastName) {
		LastName = lastName;
		Validate();
	}

	public string FirstName { get; private set; }
	public string LastName { get; private set; }

	public FullName(string firstName, string lastName) {
		FirstName = firstName;
		LastName = lastName;
		Validate();
	}

	public FullName() { }

	private void Validate() {
		var contract = new Contract<FullName>().Requires().IsBetween(FirstName.Length, 3, 30, "firstName", "FirstName has to be beetween 3 and 30 characters")
			.IsBetween(LastName.Length, 3, 50, "lastName", "LastName has to be beetween 5 and 50 characters");
		AddNotifications(contract);
	}
}