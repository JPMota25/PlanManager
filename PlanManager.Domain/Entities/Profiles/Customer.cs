using Flunt.Notifications;
using Flunt.Validations;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Domain.Entities.Profiles;

public class Customer : Entity {
	public Customer(Id idPerson) {
		IdPerson = idPerson;
		Validate();
	}

	private void Validate() {
		var contract = new Contract<Notification>();
		AddNotifications(contract);
	}

	public Id IdPerson { get; private set; }
	public Person? Person { get; set; }

	public Customer() { }
}