using Flunt.Notifications;
using Flunt.Validations;
using PlanManager.Domain.Enums;

namespace PlanManager.Domain.Entities.PlanManager;

public class License : Entity {
	public License(string idSign, string idPlan, ELicenseType type, DateOnly? expire, int prolongationInDays, decimal value) : base(true) {
		IdSign = idSign;
		IdPlan = idPlan;
		Type = type;
		Expire = expire;
		ProlongationInDays = prolongationInDays;
		Status = ELicenseStatus.PendingInitiation;
		Value = value;
		Validate();
	}

	private void Validate() {
		var contract = new Contract<Notification>().Requires()
			.IsBetween(ProlongationInDays, 0, DateTime.DaysInMonth(Expire.GetValueOrDefault().Year, Expire.GetValueOrDefault().Month),
				"ExpireDate.Prolongation").IsTrue(IsExpired(Expire, ProlongationInDays), "ExpireDate.Expired");
		AddNotifications(contract);
	}

	private bool IsExpired(DateOnly? expire, int prolongationInDays) {
		if (expire == null)
			return true;
		return !(expire.GetValueOrDefault().AddDays(prolongationInDays) < DateOnly.FromDateTime(DateTime.UtcNow));
	}

	public void ActivateLicense(int prolongationInDays) {
		switch (Type) {
			case ELicenseType.Forever:
				SetStatus(ELicenseStatus.Active);
				break;
			case ELicenseType.Month:
			case ELicenseType.Trial1Month:
				SetStatus(ELicenseStatus.Active);
				SetExpireDate(DateOnly.FromDateTime(DateTime.UtcNow.AddMonths(1)), prolongationInDays);
				break;
			case ELicenseType.Year:
				SetStatus(ELicenseStatus.Active);
				SetExpireDate(DateOnly.FromDateTime(DateTime.UtcNow.AddYears(1)), prolongationInDays);
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}

		Validate();
	}

	public void ValidateStatus() {
		switch (Type) {
			case ELicenseType.Forever:
				SetStatus(ELicenseStatus.Active);
				SetExpireDate(null, 0);
				break;
			case ELicenseType.Month:
			case ELicenseType.Year:
			case ELicenseType.Trial1Month:
				if (Expire != null && Expire.Value.AddDays(ProlongationInDays) <= DateOnly.FromDateTime(DateTime.UtcNow))
					SetStatus(ELicenseStatus.Expired);
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	private void SetExpireDate(DateOnly? expire, int prolongationInDays) {
		Expire = expire;
		ProlongationInDays = prolongationInDays;
		Validate();
	}

	public void SetLicenseType(ELicenseType type) {
		Type = type;
		Validate();
	}

	private void SetStatus(ELicenseStatus status) {
		Status = status;
		Validate();
	}

	public void SetValue(decimal value) {
		Value = value;
		Validate();
	}

	public void SetLastDaySynced(DateOnly lastDaySynced) {
		LastDaySynced = lastDaySynced;
	}

	public string IdSign { get; private set; }
	public Sign? Sign { get; set; }
	public Plan? Plan { get; set; }
	public string IdPlan { get; private set; }
	public decimal Value { get; private set; }
	public ELicenseType Type { get; private set; }
	public DateOnly? Expire { get; private set; }
	public int ProlongationInDays { get; private set; }
	public DateOnly? LastDaySynced { get; private set; }
	public ELicenseStatus Status { get; private set; }
	public License() { }
}