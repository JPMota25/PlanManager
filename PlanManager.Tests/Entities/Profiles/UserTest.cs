using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Enums;
using PlanManager.Domain.ValueObjects;
using Xunit;

namespace PlanManager.Tests.Entities.Profiles;

public class UserTest {
	private Person _person;
	private Username _username;
	private readonly string _password;

	public UserTest() {
		_person = new Person(new FullName("joao", "pedro"), new Email("joao.pedro@gmail.com"), new Document("04258181102", EDocumentType.Person),
			new Phone("55", "64", "9 9314-0912"), new Address("Itaici", "", false, "", "rua 7", "Caldas", "Goias", "Brasil", "75680000"));
		_username = new Username("joao.pedro");
		_password = "152369";
	}

	[Fact]
	public void ShouldBeTrueWhenUserIsValid() {
		var user = new User(_person.Id, _username, _password);
		Assert.True(user.IsValid);
	}

	[Fact]
	public void ShouldBeFalseWhenUserNameIsInvalid() {
		var user = new User(_person.Id, new Username("joa"), _password);
		Assert.False(user.IsValid);
	}

	[Fact]
	public void ShouldBeTrueWhenPasswordIsNotInformed() {
		var user = new User(_person.Id, _username, "");
		Assert.False(user.IsValid);
	}
}