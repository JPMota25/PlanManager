using Flunt.Notifications;
using Flunt.Validations;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Domain.Entities.Plan;

public class PlanPermission : Entity {
	private void Validate() {
		var contract = new Contract<Notification>().Requires().IsTrue(Name.IsValid, "PlanPermission.Name");
		AddNotifications(contract);
	}

	public Name Name { get; private set; }
	public PermissionCode Code { get; private set; }
	public Person? Company { get; set; }
	public Id IdCompany { get; private set; }
	public IList<PlanPermissionRelation> Plans { get; private set; }

	public PlanPermission(Name name, Id idCompany, IList<PlanPermissionRelation> plans) {
		Name = name;
		Code = new PermissionCode();
		IdCompany = idCompany;
		Plans = plans;
		Validate();
	}

	public PlanPermission() { }
}