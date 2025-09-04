using Flunt.Notifications;
using Flunt.Validations;
using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Domain.Entities.PlanManager;

public class PlanPermission : Entity {
	public void SetPlans(IList<PlanPermissionRelation> plans) {
		Plans = plans;
	}

	public void AddPlan(PlanPermissionRelation plan) {
		Plans.Add(plan);
	}

	private void Validate() {
		var contract = new Contract<Notification>().Requires();
		AddNotifications(contract);
	}

	public string Name { get; private set; }
	public string Code { get; private set; }
	public Company? Company { get; set; }
	public string IdCompany { get; private set; }
	public IList<PlanPermissionRelation> Plans { get; private set; } = new List<PlanPermissionRelation>();

	public PlanPermission(string name, string idCompany) : base(true) {
		Name = name;
		Code = Guid.NewGuid().ToString().Replace("-", "")[..28];
		IdCompany = idCompany;
		Validate();
	}

	public PlanPermission() { }
}