using Flunt.Notifications;
using Flunt.Validations;

namespace PlanManager.Domain.ValueObjects;

public class ExpireDate : ValueObject {
	public void SetProlongationInDays(int prolongationInDays) {
		ProlongationInDays = prolongationInDays;
	}

	public DateOnly Expire { get; init; }
	public int ProlongationInDays { get; private set; }

	public ExpireDate() { }

	public ExpireDate(DateOnly expire, int prolongationInDays) {
		Expire = expire;
		ProlongationInDays = prolongationInDays;
		Validate();
	}

	private void Validate() {
		var contract = new Contract<Notification>().Requires()
			.IsBetween(ProlongationInDays, 0, DateTime.DaysInMonth(Expire.Year, Expire.Month), "ExpireDate.Prolongation")
			.IsTrue(IsExpired(Expire, ProlongationInDays), "ExpireDate.Expired");
		AddNotifications(contract);
	}

	private bool IsExpired(DateOnly expire, int prolongationInDays) {
		return !(expire.AddDays(prolongationInDays) < DateOnly.FromDateTime(DateTime.UtcNow));
	}
}