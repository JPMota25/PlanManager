using Flunt.Notifications;
using Flunt.Validations;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Domain.Entities.PlanManager;

public class PlanPermission : Entity {
	public void SetPlans(IList<PlanPermissionRelation> plans) {
		Plans = plans;
	}

	public void AddPlan(PlanPermissionRelation plan) {
		Plans.Add(plan);
	}

	private void Validate() {
		var contract = new Contract<Notification>().Requires().IsTrue(Name.IsValid, "PlanPermission.Name");
		AddNotifications(contract);
	}

	public Name Name { get; private set; }
	public PermissionCode Code { get; private set; }
	public Person? Company { get; set; }
	public Id IdCompany { get; private set; }
	public IList<PlanPermissionRelation> Plans { get; private set; } = new List<PlanPermissionRelation>();

	public PlanPermission(Name name, Id idCompany) {
		Name = name;
		Code = new PermissionCode();
		IdCompany = idCompany;
		Validate();
	}

	public PlanPermission() { }
}