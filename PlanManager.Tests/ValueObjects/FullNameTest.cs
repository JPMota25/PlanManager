using PlanManager.Domain.ValueObjects;
using Xunit;

namespace PlanManager.Tests.ValueObjects;

public class FullNameTest {
	[Fact]
	public void ShouldBeTrueWhenFullNameIsValid() {
		var fullName = new FullName("Joao", "Pedro");
		Assert.True(fullName.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenFirstNameHasMoreThan30Characters() {
		var fullName = new FullName("Joaodnajdnaldjnajnbsdjanbddakjdna", "Pedro");
		Assert.False(fullName.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenFirstNameHasLessThan3Characters() {
		var fullName = new FullName("Jo", "Pedro");
		Assert.False(fullName.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenLastNameHasMoreThan50Characters() {
		var fullName = new FullName("Joao", "Pedrodajdnakjndsjdnjanbkdbaskdbashddiasdljaildsjaldhadhakdhaksdhakudabk");
		Assert.False(fullName.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenLastNameHasLessThan3Characters() {
		var fullName = new FullName("Joao", "Pe");
		Assert.False(fullName.IsValid);
	}
}