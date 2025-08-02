using Flunt.Notifications;
using Flunt.Validations;

namespace PlanManager.Domain.Entities.Profiles;

public class Customer : Entity {
	public Customer(string idPerson) : base(true) {
		IdPerson = idPerson;
		Validate();
	}

	private void Validate() {
		var contract = new Contract<Notification>();
		AddNotifications(contract);
	}

	public string IdPerson { get; private set; }
	public Person? Person { get; set; }

	public Customer() { }
}