using PlanManager.Domain.ValueObjects;
using Xunit;

namespace PlanManager.Tests.ValueObjects;

public class EmailTest {
	[Fact]
	public void ShouldBeTrueWhenEmailIsValid() {
		var email = new Email("joao.pedro.69461@gmail.com");
		Assert.True(email.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenEmailIsInvalid() {
		var email = new Email("joao.pedro.69461mail.com");
		Assert.False(email.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenEmailIsEmptyOrNull() {
		var email = new Email("");
		Assert.False(email.IsValid);
	}
}