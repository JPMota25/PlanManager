using Flunt.Validations;

namespace PlanManager.Domain.Entities.Profiles;

public class User : Entity {
	public void SetPassword(string password) {
		Password = password;
	}

	public Person? Person { get; set; }
	public string IdPerson { get; private set; }
	public string Username { get; private set; }
	public string Password { get; private set; }

	public User() { }

	public User(string idPerson, string username, string password) : base(true) {
		IdPerson = idPerson;
		Username = username;
		Password = password;
		Validate();
	}

	private void Validate() {
		var contract = new Contract<User>().Requires();
		AddNotifications(contract);
	}
}