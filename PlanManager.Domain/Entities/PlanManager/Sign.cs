using Flunt.Notifications;
using Flunt.Validations;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Enums;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Domain.Entities.PlanManager;

public class Sign : Entity {
	public Sign(Id idCustomer, Id idCompany) {
		IdCustomer = idCustomer;
		IdCompany = idCompany;
		InitialTime = DateTime.UtcNow;
		Status = ESignStatus.PendingApproval;
		Validate();
	}

	private void Validate() {
		var contract = new Contract<Notification>().IsTrue(IdCustomer.IsValid, "Sign.IdCustomer").IsTrue(IdCompany.IsValid, "Sign.IdCompany");
		AddNotifications(contract);
	}

	public void SetStatus(ESignStatus status) {
		Status = status;
	}

	public Id IdCustomer { get; private set; }
	public Person? Customer { get; set; }
	public Id IdCompany { get; private set; }
	public Person? Company { get; private set; }
	public DateTime? InitialTime { get; init; }
	public ESignStatus Status { get; private set; }

	public Sign() { }
}