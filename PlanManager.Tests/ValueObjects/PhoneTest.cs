using PlanManager.Domain.ValueObjects;
using Xunit;
using Xunit.Abstractions;

namespace PlanManager.Tests.ValueObjects;

public class PhoneTest {
	private readonly ITestOutputHelper _testOutputHelper;
	public PhoneTest(ITestOutputHelper testOutputHelper) {
		_testOutputHelper = testOutputHelper;
	}

	[Fact]
	public void ShouldBeTrueWhenIsAValidPhoneNumber() {
		var phone = new Phone("+55", "64", "9 9314-0912");
		Assert.True(phone.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenCountryCodeIsInvalid() {
		var phone = new Phone("6666666", "64", "9 9314-0912");
		_testOutputHelper.WriteLine(phone.NumberWithDigit);
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