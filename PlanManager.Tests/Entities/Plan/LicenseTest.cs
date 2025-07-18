using System.Diagnostics;
using PlanManager.Domain.Entities.Plan;
using PlanManager.Domain.Enums;
using PlanManager.Domain.ValueObjects;
using Xunit;

namespace PlanManager.Tests.Entities.Plan;

public class LicenseTest {
	[Fact]
	public void ShouldBeTrueWithAForeverLicenseAndExpireDateNull() {
		var license = new License(Id.New(), Id.New(), ELicenseType.Forever, null, new Value(10));
		Assert.True(license.IsValid);
	}

	[Fact]
	public void ShouldBeTrueWithAMonthlyLicenseAndExpireDateValid() {
		var license = new License(Id.New(), Id.New(), ELicenseType.Month, null, new Value(10));
		Assert.True(license.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWithAMonthlyLicenseAndExpireDateInvalid() {
		var license = new License(Id.New(), Id.New(), ELicenseType.Month, new ExpireDate(new DateOnly(2024, 05, 01), 1), new Value(10));
		Assert.False(license.IsValid);
	}

	[Fact]
	public void ShouldBeTrueWithAYearLicenseAndExpireDateValid() {
		var license = new License(Id.New(), Id.New(), ELicenseType.Year, null, new Value(10));
		license.ActivateLicense(10);
		Assert.True(license.IsValid);
	}

	[Fact]
	public void ShouldBeActiveWithALicenseAlterationToForeverType() {
		var license = new License(Id.New(), Id.New(), ELicenseType.Year, null, new Value(10));
		license.ActivateLicense(10);
		license.SetLicenseType(ELicenseType.Forever);
		license.ValidateStatus();
		Assert.Equal(ELicenseStatus.Active, license.Status);
	}

	[Fact]
	public void ShouldBePendingActivationWhenCreated() {
		var license = new License(Id.New(), Id.New(), ELicenseType.Year, null, new Value(10));
		Assert.Equal(ELicenseStatus.PendingInitiation, license.Status);
	}

	[Fact]
	public void ShouldBeActivatedAndExpireDate1YearWithAYearLicense() {
		var license = new License(Id.New(), Id.New(), ELicenseType.Year, null, new Value(10));
		license.ActivateLicense(10);
		Debug.Assert(license.ExpireDate != null);
		Assert.Equal(DateOnly.FromDateTime(DateTime.UtcNow.AddYears(1)), license.ExpireDate.Expire);
		Assert.Equal(ELicenseStatus.Active, license.Status);
	}

	[Fact]
	public void ShouldBeActivatedAndExpireDate1MonthWithAMonthLicense() {
		var license = new License(Id.New(), Id.New(), ELicenseType.Month, null, new Value(10));
		license.ActivateLicense(10);
		Debug.Assert(license.ExpireDate != null);
		Assert.Equal(DateOnly.FromDateTime(DateTime.UtcNow.AddMonths(1)), license.ExpireDate.Expire);
		Assert.Equal(ELicenseStatus.Active, license.Status);
	}
}