using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Enums;
using PlanManager.Domain.ValueObjects;
using Xunit;

namespace PlanManager.Tests.Entities;

public class PersonTest {
	private readonly FullName _fullName;
	private readonly Email _email;
	private readonly Document _document;
	private readonly Phone _phone;
	private readonly Address _address;

	public PersonTest() {
		_fullName = new FullName("Joao Pedro", "Mota e Silva");
		_email = new Email("joao.pedro.69461@gmail.com");
		_document = new Document("04258181102", EDocumentType.Person);
		_phone = new Phone("+55", "64", "9 9314-0912");
		_address = new Address("Itaici 2", "103c", true, "", "rua 7", "caldas novas", "Goias", "Brasil", "75680000");
	}

	[Fact]
	public void ShouldBeTrueWhenIsAValidPerson() {
		var person = new Person(_fullName, _email, _document, _phone, _address);
		Assert.True(person.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenPersonDocumentIsNotAValidDocument() {
		var person = new Person(_fullName, _email, new Document("042", EDocumentType.Person), _phone, _address);
		Assert.False(person.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenPersonPhoneIsNotValid() {
		var person = new Person(_fullName, _email, _document, new Phone("", "", ""), _address);
		Assert.False(person.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenPersonAddressIsNotValid() {
		var person = new Person(_fullName, _email, _document, _phone, new Address("", "", true, "", "", "", "", "", ""));
		Assert.False(person.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenPersonEmailIsNotValid() {
		var person = new Person(_fullName, new Email("joao.com"), _document, _phone, _address);
		Assert.False(person.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenPersonFullNameIsNotValid() {
		var person = new Person(new FullName("jo", "m"), _email, _document, _phone, _address);
		Assert.False(person.IsValid);
	}
}