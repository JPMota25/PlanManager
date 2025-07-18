using PlanManager.Domain.ValueObjects;
using Xunit;

namespace PlanManager.Tests.ValueObjects;

public class UsernameTest {
	[Fact]
	public void ShouldBeTrueWhenUsernameIsValid() {
		var username = new Username("joao.pedro");
		Assert.True(username.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenUsernameHasMoreCharactersThanFifty() {
		var username = new Username("dkajdiauhdjsidasdasdadasdadasdaksahgdiuahsduiahgdiuashndoaus");
		Assert.False(username.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenUsernameHasLessCharactersThanFive() {
		var username = new Username("addw");
		Assert.False(username.IsValid);
	}
}