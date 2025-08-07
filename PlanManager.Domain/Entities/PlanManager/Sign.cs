using System.Security.AccessControl;
using System.Text;
using Flunt.Notifications;
using Flunt.Validations;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Enums;

namespace PlanManager.Domain.Entities.PlanManager;

public class Sign : Entity {

	public void Approve() {
		Status = ESignStatus.Approved;
		Validate();
	}

	public void ActivateLicense() {
		Status = ESignStatus.Active;
		Validate();
	}

	public void GenerateToken() {
		if (Token != null) return;
		var bytes = Encoding.UTF8.GetBytes(Guid.NewGuid().ToString().Replace("-", "")[..32]);
		Token = Convert.ToBase64String(bytes);
	}

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
	public string? Token { get; private set; }
	public Person? Company { get;  set; }
	public DateTime? InitialTime { get; init; }
	public ESignStatus Status { get; private set; }

	public Sign() { }
}