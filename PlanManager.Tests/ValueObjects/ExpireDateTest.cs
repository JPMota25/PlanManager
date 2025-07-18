using PlanManager.Domain.ValueObjects;
using Xunit;

namespace PlanManager.Tests.ValueObjects;

public class ExpireDateTest {
	[Fact]
	public void ShouldBeAValidExpireDateWhenExpireIsAfterNow() {
		var expireDate = new ExpireDate(DateOnly.FromDateTime(DateTime.UtcNow), 10);
		Assert.True(expireDate.IsValid);
	}

	[Fact]
	public void ShouldBeAInvalidExpireDateWhenExpireWithProlongationTimeIsBeforeNow() {
		var expireDate = new ExpireDate(new DateOnly(2025, 01, 01), 10);
		Assert.False(expireDate.IsValid);
	}

	[Fact]
	public void ShouldBeAInvalidExpireDateWhenProlongationTimeIsGreaterThan1Month() {
		var expireDate = new ExpireDate(DateOnly.FromDateTime(DateTime.UtcNow), 32);
		Assert.False(expireDate.IsValid);
	}

	[Fact]
	public void ShouldBeAInvalidExpireDateWhenProlongationTimeIsNegative() {
		var expireDate = new ExpireDate(DateOnly.FromDateTime(DateTime.UtcNow), -1);
		Assert.False(expireDate.IsValid);
	}
}