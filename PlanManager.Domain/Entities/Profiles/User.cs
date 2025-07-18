using Flunt.Validations;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Domain.Entities.Profiles;

public class User : Entity {
	public void SetPassword(string password) {
		Password = password;
	}

	public Person? Person { get; set; }
	public Id IdPerson { get; init; }
	public Username Username { get; init; }
	public string Password { get; private set; }

	public User() { }

	public User(Id idPerson, Username username, string password) {
		IdPerson = idPerson;
		Username = username;
		Password = password;
		Validate();
	}

	private void Validate() {
		var contract = new Contract<User>().Requires();
		contract.IsTrue(Username.IsValid, "User.Username", "Username Invalid");
		AddNotifications(Username.Notifications);
		contract.IsNotNullOrWhiteSpace(Password, "User.Password", "Password Invalid");
		AddNotifications(contract);
	}
}