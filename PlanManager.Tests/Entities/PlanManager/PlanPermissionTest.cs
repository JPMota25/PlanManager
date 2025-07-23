using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.ValueObjects;
using Xunit;

namespace PlanManager.Tests.Entities.PlanManager;

public class PlanPermissionTest {
	[Fact]
	public void ShouldBeTrueWhenIsAValidPermissionName() {
		var planPermission = new PlanPermission(new Name("Teste"), Id.New());
		Assert.True(planPermission.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenIsAInvalidPermissionName() {
		var planPermission = new PlanPermission(new Name("djaiodhakjdjsaçdijuhiaghyjbjdnoiuytfdfghio09876tresdfuiopuytredsjhgfdiuytfdsdfghjiopoiuyfd"),
			Id.New());
		Assert.False(planPermission.IsValid);
	}
}