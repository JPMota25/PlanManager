using PlanManager.Domain.ValueObjects;
using Xunit;

namespace PlanManager.Tests.ValueObjects;

public class AddressTest {
	[Fact]
	public void ShouldBeTrueWhenAddressIsValid() {
		var address = new Address("itaici 2", "103c", true, "", "Rua 7", "Caldas Novas", "Goias", "Brasil", "75680000");
		Assert.True(address.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenNeighboorhoodIsNotInformed() {
		var address = new Address("", "103c", true, "", "Rua 7", "Caldas Novas", "Goias", "Brasil", "75680000");
		Assert.False(address.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenNeighboorhoodLengthIsNotBeetween3And30Characters() {
		var address = new Address("itaicidçajikodnbqm, kabdikndjandkjassnaidkna", "103c", true, "", "Rua 7", "Caldas Novas", "Goias", "Brasil", "75680000");
		Assert.False(address.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenHasHouseNumberIsTrueAndHouseNumberIsNotInformed() {
		var address = new Address("itaici 2", "", true, "", "Rua 7", "Caldas Novas", "Goias", "Brasil", "75680000");
		Assert.False(address.IsValid);
	}

	[Fact]
	public void ShouldBeTrueWhenHasHouseNumberIsFalseAndHouseNumberIsNotInformed() {
		var address = new Address("itaici 2", "", false, "", "Rua 7", "Caldas Novas", "Goias", "Brasil", "75680000");
		Assert.True(address.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenComplementHasMoreCharactersThan150() {
		var address = new Address("itaici 2", "103c", true,
			"dadasdasdadadasdaadjodadikaohduiahuidahuidahuidaidhadsnkjdanndaiusjdhbnisauhbdiushisduhaidahdhaiohdiadhaoidadhaiuohdusahdaskiuhbdkbaksdhjbnsabdiuahdiuhjkkhgiduhikhaiuksbdkjah",
			"Rua 7", "Caldas Novas", "Goias", "Brasil", "75680000");
		Assert.False(address.IsValid);
	}

	[Fact]
	public void ShouldBeTrueWhenComplementIsNotInformed() {
		var address = new Address("itaici 2", "103c", true, "", "Rua 7", "Caldas Novas", "Goias", "Brasil", "75680000");
		Assert.True(address.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenStreetIsNotInformed() {
		var address = new Address("itaici 2", "103c", true, "", "", "Caldas Novas", "Goias", "Brasil", "75680000");
		Assert.False(address.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenStreetLengthIsNotBeetween1And100Characters() {
		var address = new Address("itaici 2", "103c", true, "",
			"Rua dsjidjlanjsdlidjnosiadnjsjdnhadsnadjasjdlnasdniwqjolksdlksjaldjlksdklkdljalfdjlajladaldjajdjjoljdoaomalmlalfja0doia7", "Caldas Novas", "Goias",
			"Brasil", "75680000");
		Assert.False(address.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenCityIsNotInformed() {
		var address = new Address("itaici 2", "103c", true, "", "Rua 7", "", "Goias", "Brasil", "75680000");
		Assert.False(address.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenCityLengthIsNotBeetween5And50Characters() {
		var address = new Address("itaici 2", "103c", true, "", "Rua 7",
			"Caldas adkl,çsdasndkasbndksanbkdnsakdnasdlsankldnasldsandkljsasdamlkdmnaskdmanmdçlaNovas", "Goias", "Brasil", "75680000");
		Assert.False(address.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenStateLengthIsNotBeetween3And50Characters() {
		var address = new Address("itaici 2", "103c", true, "", "Rua 7", "Caldas Novas",
			"Goiadkaspdmalksmdklamsdklmaskldasmdlsandkabfdhafjksnjkfandkna kdjsan kjdn aflaçfmalfalkçfmkafdqowemqlkmnaslkflas", "Brasil", "75680000");
		Assert.False(address.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenStateIsNotInformed() {
		var address = new Address("itaici 2", "103c", true, "", "Rua 7", "Caldas Novas", "", "Brasil", "75680000");
		Assert.False(address.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenCountryIsNotInformed() {
		var address = new Address("itaici 2", "103c", true, "", "Rua 7", "Caldas Novas", "Goias", "", "75680000");
		Assert.False(address.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenCountryLengthIsNotBeetween4And50Characters() {
		var address = new Address("itaici 2", "103c", true, "", "Rua 7", "Caldas Novas", "Goias",
			"Bradlkmçamdçlasmkdmlkamdlasnklsankfnakfkndksjndksaflanljalflanflaolfajloeqlemlaiodnaosil", "75680000");
		Assert.False(address.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenZipcodeIsNotInformed() {
		var address = new Address("itaici 2", "103c", true, "", "Rua 7", "Caldas Novas", "Goias", "Brasil", "");
		Assert.False(address.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenZipcodeLengthIsNot8Characters() {
		var address = new Address("itaici 2", "103c", true, "", "Rua 7", "Caldas Novas", "Goias", "Brasil", "7568000");
		Assert.False(address.IsValid);
	}
}