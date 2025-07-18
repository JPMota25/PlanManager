using PlanManager.Domain.ValueObjects;
using Xunit;

namespace PlanManager.Tests.ValueObjects;

public class NameTest {
	[Fact]
	public void ShouldBeTrueWhenLengthIsBeetween4And30Characters() {
		var name = new Name("abcd");
		Assert.True(name.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenLengthIsNotBeetween4And30Characters() {
		var name = new Name("abc");
		Assert.False(name.IsValid);
	}
}