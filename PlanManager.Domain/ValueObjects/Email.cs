using Flunt.Validations;

namespace PlanManager.Domain.ValueObjects;

public class Email : ValueObject {
	public void SetEmail(string emailAddress) {
		EmailAddress = emailAddress;
		Validate();
	}

	public string EmailAddress { get; private set; }

	public Email(string emailAddress) {
		EmailAddress = emailAddress;
		Validate();
	}

	public Email() { }

	private void Validate() {
		var contract = new Contract<Email>().Requires().IsNotNullOrWhiteSpace(EmailAddress, "Email needs to be provided")
			.IsEmail(EmailAddress, "Invalid email address!");
		AddNotifications(contract);
	}
}