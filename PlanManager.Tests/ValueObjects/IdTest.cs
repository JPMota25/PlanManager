using PlanManager.Domain.ValueObjects;
using Xunit;

namespace PlanManager.Tests.ValueObjects;

public class IdTest {
	[Fact]
	public void ShouldBeTrueWhenIdLenghtIs11Characters() {
		var id = Id.New();
		Assert.Equal(11, id.ToString().Length);
	}

	[Fact]
	public void ShouldBeTrueWhenIdEmptyIsEmpty() {
		var id = Id.Empty;
		Assert.Equal("00000000000", id.ToString());
	}
}