using PlanManager.Domain.ValueObjects;
using Xunit;

namespace PlanManager.Tests.ValueObjects;

public class ValueTest {
	[Fact]
	public void ShouldBeTrueWhenIsAPositiveNumber() {
		var value = new Value(10);
		Assert.True(value.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenIsANegativeNumber() {
		var value = new Value(-10);
		Assert.False(value.IsValid);
	}
}