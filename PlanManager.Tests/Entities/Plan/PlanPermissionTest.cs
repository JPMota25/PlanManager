using PlanManager.Domain.Entities.Plan;
using PlanManager.Domain.ValueObjects;
using Xunit;

namespace PlanManager.Tests.Entities.Plan;

public class PlanPermissionTest {
	[Fact]
	public void ShouldBeTrueWhenIsAValidPermissionName() {
		var planPermission = new PlanPermission(new Name("Teste"), Id.New(), new List<PlanPermissionRelation>());
		Assert.True(planPermission.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenIsAInvalidPermissionName() {
		var planPermission = new PlanPermission(new Name("djaiodhakjdjsaçdijuhiaghyjbjdnoiuytfdfghio09876tresdfuiopuytredsjhgfdiuytfdsdfghjiopoiuyfd"),
			Id.New(), new List<PlanPermissionRelation>());
		Assert.False(planPermission.IsValid);
	}
}