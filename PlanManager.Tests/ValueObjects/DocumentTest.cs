using PlanManager.Domain.Enums;
using PlanManager.Domain.ValueObjects;
using Xunit;

namespace PlanManager.Tests.ValueObjects;

public class DocumentTest {
	[Fact]
	public void ShouldBeTrueWhenDocumentIsAPersonAndHasElevenCharacters() {
		var document = new Document("042.581.811-02", EDocumentType.Person);
		Assert.True(document.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenDocumentIsAPersonAndHasADifferentLenghtThanElevenCharacters() {
		var document = new Document("042.581.811-0", EDocumentType.Person);
		Assert.False(document.IsValid);
	}

	[Fact]
	public void ShouldBeTrueWhenDocumentIsACompanyAndHasFourteenCharacters() {
		var document = new Document("18.135.935/0001-02", EDocumentType.Company);
		Assert.True(document.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenDocumentIsACompanyAndHasADifferentLenghtThanFourteenCharacters() {
		var document = new Document("18.135.935/0001-0", EDocumentType.Company);
		Assert.False(document.IsValid);
	}
}