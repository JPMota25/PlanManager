using PlanManager.Domain.ValueObjects;
using Xunit;

namespace PlanManager.Tests.ValueObjects;

public class PhoneTest {
	[Fact]
	public void ShouldBeTrueWhenIsAValidPhoneNumber() {
		var phone = new Phone("+55", "64", "9 9314-0912");
		Assert.True(phone.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenCountryCodeIsInvalid() {
		var phone = new Phone("6666666", "64", "9 9314-0912");
		Assert.False(phone.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenDddIsInvalid() {
		var phone = new Phone("+55", "641165151", "9 9314-0912");
		Assert.False(phone.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenPhoneNumberWithDigitIsInvalid() {
		var phone = new Phone("+55", "64", "9 29314-0912");
		Assert.False(phone.IsValid);
	}
}