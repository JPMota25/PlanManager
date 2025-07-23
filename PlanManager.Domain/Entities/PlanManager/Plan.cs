using Flunt.Notifications;
using Flunt.Validations;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Domain.Entities.PlanManager;

public class Plan : Entity {
	public void SetName(Name name) {
		Name = name;
		Validate();
	}

	public void SetValue(Value value) {
		Value = value;
		Validate();
	}

	public Name Name { get; private set; }
	public Value Value { get; private set; }
	public Person? Company { get; set; }
	public Id IdCompany { get; init; }
	public IList<PlanPermissionRelation> Permissions { get; private set; } = new List<PlanPermissionRelation>();
	public Plan() { }

	public Plan(Name name, Value value, Id idCompany) {
		Name = name;
		Value = value;
		IdCompany = idCompany;
		Validate();
	}

	private void Validate() {
		var contract = new Contract<Notification>().Requires().IsTrue(Value.IsValid, "Value.IsValid");
		AddNotifications(contract);
	}
}