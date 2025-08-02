using Flunt.Notifications;
using Flunt.Validations;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Enums;

namespace PlanManager.Domain.Entities.PlanManager;

public class Sign : Entity {
	public Sign(string idCustomer, string idCompany) : base(true) {
		IdCustomer = idCustomer;
		IdCompany = idCompany;
		InitialTime = DateTime.UtcNow;
		Status = ESignStatus.PendingApproval;
		Validate();
	}

	private void Validate() {
		var contract = new Contract<Notification>();
		AddNotifications(contract);
	}

	public void SetStatus(ESignStatus status) {
		Status = status;
	}

	public string IdCustomer { get; private set; }
	public Person? Customer { get; set; }
	public string IdCompany { get; private set; }
	public Person? Company { get; private set; }
	public DateTime? InitialTime { get; init; }
	public ESignStatus Status { get; private set; }

	public Sign() { }
}