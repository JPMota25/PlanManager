using Flunt.Notifications;
using Flunt.Validations;
using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Domain.Entities.PlanManager;

public class Plan : Entity {
	public void SetName(string name) {
		Name = name;
		Validate();
	}

	public void SetValue(decimal value) {
		Value = value;
		Validate();
	}

	public string Name { get; private set; }
	public decimal Value { get; private set; }
	public Person? Company { get; set; }
	public string IdCompany { get; init; }
	public IList<PlanPermissionRelation> Permissions { get; private set; } = new List<PlanPermissionRelation>();
	public Plan() { }

	public Plan(string name, decimal value, string idCompany) : base(true) {
		Name = name;
		Value = value;
		IdCompany = idCompany;
		Validate();
	}

	private void Validate() {
		var contract = new Contract<Notification>().Requires();
		AddNotifications(contract);
	}
}