using Flunt.Notifications;
using Flunt.Validations;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Enums;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Domain.Entities.Plan;

public class Sign : Entity {
	public Sign(Id idCustomer, Id idCompany, IList<License> licenses) {
		IdCustomer = idCustomer;
		IdCompany = idCompany;
		InitialTime = DateTime.UtcNow;
		Licenses = licenses;
		Status = ESignStatus.PendingApproval;
		Validate();
	}

	private void Validate() {
		var contract = new Contract<Notification>().IsTrue(IdCustomer.IsValid, "Sign.IdCustomer").IsTrue(IdCompany.IsValid, "Sign.IdCompany");
		AddNotifications(contract);
	}

	public void AddLicense(License license) {
		Licenses.Add(license);
	}

	public void SetStatus(ESignStatus status) {
		Status = status;
	}

	public Id IdCustomer { get; private set; }
	public Person? Customer { get; set; }
	public Id IdCompany { get; private set; }
	public Person? Company { get; private set; }
	public DateTime InitialTime { get; init; }
	public ESignStatus Status { get; private set; }
	public IList<License> Licenses { get; private set; }

	public Sign() { }
}