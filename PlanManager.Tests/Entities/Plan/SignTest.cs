using PlanManager.Domain.Entities.Plan;
using PlanManager.Domain.Enums;
using PlanManager.Domain.ValueObjects;
using Xunit;

namespace PlanManager.Tests.Entities.Plan;

public class SignTest {
	[Fact]
	public void ShouldBePendingApprovalStatusWhenCreated() {
		var sign = new Sign(Id.New(), Id.New());
		Assert.Equal(ESignStatus.PendingApproval, sign.Status);
	}
}