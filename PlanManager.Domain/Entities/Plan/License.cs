using Flunt.Notifications;
using Flunt.Validations;
using PlanManager.Domain.Enums;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Domain.Entities.Plan;

public class License : Entity {
	public License(Id idSign, Id idPlan, ELicenseType type, ExpireDate? expireDate, Value value) {
		IdSign = idSign;
		IdPlan = idPlan;
		Type = type;
		ExpireDate = expireDate;
		Status = ELicenseStatus.PendingInitiation;
		Value = value;
		Validate();
	}

	private void Validate() {
		var contract = new Contract<Notification>().Requires().IsTrue(IdSign.IsValid, "License.IdSign").IsTrue(Value.IsValid, "License.Value");
		if (ExpireDate != null)
			contract.IsTrue(ExpireDate.IsValid, "License.ExpireDate");
		AddNotifications(contract);
	}

	public void ActivateLicense(int prolongationInDays) {
		switch (Type) {
			case ELicenseType.Forever:
				SetStatus(ELicenseStatus.Active);
				break;
			case ELicenseType.Month:
			case ELicenseType.Trial1Month:
				SetStatus(ELicenseStatus.Active);
				SetExpireDate(new ExpireDate(DateOnly.FromDateTime(DateTime.UtcNow.AddMonths(1)), prolongationInDays));
				break;
			case ELicenseType.Year:
				SetStatus(ELicenseStatus.Active);
				SetExpireDate(new ExpireDate(DateOnly.FromDateTime(DateTime.UtcNow.AddYears(1)), prolongationInDays));
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
				SetExpireDate(null);
				break;
			case ELicenseType.Month:
			case ELicenseType.Year:
			case ELicenseType.Trial1Month:
				if (ExpireDate is { IsValid: false })
					SetStatus(ELicenseStatus.Expired);
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	private void SetExpireDate(ExpireDate expireDate) {
		ExpireDate = expireDate;
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

	public void SetValue(Value value) {
		Value = value;
		Validate();
	}

	public void SetLastDaySynced(DateOnly lastDaySynced) {
		LastDaySynced = lastDaySynced;
	}

	public Id IdSign { get; private set; }
	public Sign? Sign { get; set; }
	public Plan? Plan { get; set; }
	public Id IdPlan { get; init; }
	public Value Value { get; private set; }
	public ELicenseType Type { get; private set; }
	public ExpireDate? ExpireDate { get; private set; }
	public DateOnly? LastDaySynced { get; private set; }
	public ELicenseStatus Status { get; private set; }
	public License() { }
}