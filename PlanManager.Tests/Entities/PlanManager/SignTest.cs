using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.Enums;
using PlanManager.Domain.ValueObjects;
using Xunit;

namespace PlanManager.Tests.Entities.PlanManager;

public class SignTest {
	[Fact]
	public void ShouldBePendingApprovalStatusWhenCreated() {
		var sign = new Sign(Id.New(), Id.New());
		Assert.Equal(ESignStatus.PendingApproval, sign.Status);
	}
}