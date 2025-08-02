using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Enums;
using Xunit;

namespace PlanManager.Tests.Entities;

public class PersonTest {
	private readonly string _firstName;
	private readonly string _lastName;
	private readonly string _email;
	private readonly string _document;
	private readonly EDocumentType _type;
	private readonly string _countryCode;
	private readonly string _ddd;
	private readonly string _numberWithDigit;
	private readonly string _neighboorhood;
	private readonly string _houseNumber;
	private readonly bool _hasHouseNumber;
	private readonly string _complement;
	private readonly string _street;
	private readonly string _city;
	private readonly string _state;
	private readonly string _country;
	private readonly string _zipCode;

	public PersonTest() {
		_firstName = "firstName";
		_lastName = "lastName";
		_email = "joao.pedro.69461@gmail.com";
		_document = "042.581.811-02";
		_type = EDocumentType.Person;
		_countryCode = "+55";
		_ddd = "64";
		_numberWithDigit = "9 9314-0912";
		_neighboorhood = "itaici";
		_houseNumber = "103c";
		_hasHouseNumber = true;
		_complement = "Edificio San Remo";
		_street = "Rua 7";
		_city = "Caldas Novas";
		_state = "Goias";
		_country = "Brasil";
		_zipCode = "75620-000";
	}

	[Fact]
	public void ShouldBeEmptyWhenAddressIsValid() {
		var person = new Person(_firstName, _lastName, _email, _document, _type, _countryCode, _ddd, _numberWithDigit, _neighboorhood, _houseNumber,
			_hasHouseNumber, _complement, _street, _city, _state, _country, _zipCode);
		Assert.Empty(person.Notifications);
	}

	[Fact]
	public void ShouldBeNotEmptyWhenNeighboorhoodIsNotInformed() {
		var person = new Person(_firstName, _lastName, _email, _document, _type, _countryCode, _ddd, _numberWithDigit, "", _houseNumber, _hasHouseNumber,
			_complement, _street, _city, _state, _country, _zipCode);
		Assert.NotEmpty(person.Notifications);
	}

	[Fact]
	public void ShouldBeNotEmptyWhenNeighboorhoodLengthIsNotBeetween3And30Characters() {
		var person = new Person(_firstName, _lastName, _email, _document, _type, _countryCode, _ddd, _numberWithDigit, "ds", _houseNumber, _hasHouseNumber,
			_complement, _street, _city, _state, _country, _zipCode);
		Assert.NotEmpty(person.Notifications);
	}

	[Fact]
	public void ShouldBeNotEmptyWhenHasHouseNumberIsTrueAndHouseNumberIsNotInformed() {
		var person = new Person(_firstName, _lastName, _email, _document, _type, _countryCode, _ddd, _numberWithDigit, _neighboorhood, "", _hasHouseNumber,
			_complement, _street, _city, _state, _country, _zipCode);
		Assert.NotEmpty(person.Notifications);
	}

	[Fact]
	public void ShouldBeEmptyWhenHasHouseNumberIsFalseAndHouseNumberIsNotInformed() {
		var person = new Person(_firstName, _lastName, _email, _document, _type, _countryCode, _ddd, _numberWithDigit, _neighboorhood, "", false, _complement,
			_street, _city, _state, _country, _zipCode);
		Assert.Empty(person.Notifications);
	}

	[Fact]
	public void ShouldBeNotEmtyWhenComplementHasMoreCharactersThan150() {
		var person = new Person(_firstName, _lastName, _email, _document, _type, _countryCode, _ddd, _numberWithDigit, _neighboorhood, _houseNumber,
			_hasHouseNumber,
			"sdnjondkandlsanjdkbahdbaskbdkasnkdnkdnkndkadnkashndklaskdlhalhjdlakjsnkjasndkbsaihdbsajnbdkamjbdkjasndkjandqniouehqjlkejqlkndandkljakdhqiukwehksbadnuqnelqnwlndeklasdhuiwqhedansdnwiqhjeosakdjlnaknjwk",
			_street, _city, _state, _country, _zipCode);
		Assert.NotEmpty(person.Notifications);
	}

	[Fact]
	public void ShouldBeEmptyWhenComplementIsNotInformed() {
		var person = new Person(_firstName, _lastName, _email, _document, _type, _countryCode, _ddd, _numberWithDigit, _neighboorhood, _houseNumber,
			_hasHouseNumber, "", _street, _city, _state, _country, _zipCode);
		Assert.Empty(person.Notifications);
	}

	[Fact]
	public void ShouldBeFalseWhenStreetIsNotInformed() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeFalseWhenStreetLengthIsNotBeetween1And100Characters() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeFalseWhenCityIsNotInformed() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeFalseWhenCityLengthIsNotBeetween5And50Characters() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeFalseWhenStateLengthIsNotBeetween3And50Characters() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeFalseWhenStateIsNotInformed() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeFalseWhenCountryIsNotInformed() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeFalseWhenCountryLengthIsNotBeetween4And50Characters() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeFalseWhenZipcodeIsNotInformed() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeFalseWhenZipcodeLengthIsNot8Characters() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeTrueWhenDocumentIsAPersonAndHasElevenCharacters() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeFalseWhenDocumentIsAPersonAndHasADifferentLenghtThanElevenCharacters() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeTrueWhenDocumentIsACompanyAndHasFourteenCharacters() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeFalseWhenDocumentIsACompanyAndHasADifferentLenghtThanFourteenCharacters() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeTrueWhenEmailIsValid() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeFalseWhenEmailIsInvalid() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeFalseWhenEmailIsEmptyOrNull() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeTrueWhenFullNameIsValid() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeFalseWhenFirstNameHasMoreThan30Characters() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeFalseWhenFirstNameHasLessThan3Characters() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeFalseWhenLastNameHasMoreThan50Characters() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeFalseWhenLastNameHasLessThan3Characters() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeTrueWhenIsAValidPhoneNumber() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeFalseWhenCountryCodeIsInvalid() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeFalseWhenDddIsInvalid() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeFalseWhenPhoneNumberWithDigitIsInvalid() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeTrueWhenIsAValidPerson() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeFalseWhenPersonDocumentIsNotAValidDocument() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeFalseWhenPersonPhoneIsNotValid() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeFalseWhenPersonAddressIsNotValid() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeFalseWhenPersonEmailIsNotValid() {
		Assert.Fail();
	}

	[Fact]
	public void ShouldBeFalseWhenPersonFullNameIsNotValid() {
		Assert.Fail();
	}
}