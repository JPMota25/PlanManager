using Flunt.Validations;
using PlanManager.Domain.Enums;

namespace PlanManager.Domain.Entities.Profiles;

public class Person : Entity {
	public Person(string firstName, string lastName, string email, string document, EDocumentType type, string countryCode, string ddd, string numberWithDigit,
		string neighboorhood, string? houseNumber, bool hasHouseNumber, string complement, string street, string city, string state, string country,
		string zipcode) : base(true) {
		Status = EPersonStatus.Active;
		FirstName = firstName;
		LastName = lastName;
		Email = email;
		Document = RemoveSpecialCharacters(document);
		Type = type;
		CountryCode = RemoveSpecialCharacters(countryCode);
		DDD = RemoveSpecialCharacters(ddd);
		NumberWithDigit = RemoveSpecialCharacters(numberWithDigit);
		Neighboorhood = neighboorhood;
		HouseNumber = houseNumber;
		HasHouseNumber = hasHouseNumber;
		Complement = complement;
		Street = street;
		City = city;
		State = state;
		Country = country;
		Zipcode = RemoveSpecialCharacters(zipcode);
		Validate();
	}

	private void Validate() {
		var contract = new Contract<Person>().Requires().IsBetween(FirstName.Length, 3, 30, "firstName", "FirstName has to be beetween 3 and 30 characters")
			.IsBetween(LastName.Length, 3, 50, "lastName", "LastName has to be beetween 5 and 50 characters")
			.IsNotNullOrWhiteSpace(Document, "Identification needs to be provided").IsTrue(IsValidDocument(Document, Type), "Invalid document")
			.IsNotNullOrWhiteSpace(Email, "Email needs to be provided").IsEmail(Email, "Invalid email address!")
			.IsBetween(Neighboorhood.Length, 3, 30, "Address.Neighboorhood", "Neighboorhood should have beetween 3 and thirty characters")
			.IsNotNullOrWhiteSpace(Neighboorhood, "Neighboorhood", "Neighboorhood not informed")
			.IsBetween(Street.Length, 1, 100, "Address.Street", "Street should have beetween 1 and 100 characters")
			.IsNotNullOrWhiteSpace(Street, "street", "Street not informed")
			.IsBetween(City.Length, 5, 50, "Address.City", "City should have beetween 5 and 50 characters")
			.IsNotNullOrWhiteSpace(City, "city", "City not informed")
			.IsBetween(State.Length, 3, 50, "Address.State", "State should have beetween 3 and 50 characters")
			.IsNotNullOrWhiteSpace(State, "state", "State not informed")
			.IsBetween(Country.Length, 4, 50, "Address.Country", "Country should have beetween 4 and 50 characters")
			.IsNotNullOrWhiteSpace(Country, "country", "Country not informed")
			.AreEquals(Zipcode.Length, 8, "Address.Zipcode", "Zipcode should have 8 characters")
			.IsNotNullOrWhiteSpace(Zipcode, "zipcode", "Zipcode not informed")
			.IsBetween(Complement.Length, 0, 150, "complement", "Complement has a max of 100 characters");
		if (HasHouseNumber)
			contract.IsNotNullOrWhiteSpace(HouseNumber, "house", "Insert a house number");
		AddNotifications(contract);
	}

	private static bool IsValidDocument(string identification, EDocumentType type) {
		switch (type) {
			case EDocumentType.Person when identification.Length == 11:
			case EDocumentType.Company when identification.Length == 14:
				return true;
			default:
				return false;
		}
	}

	private static string RemoveSpecialCharacters(string removeSpecialCharacters) {
		return removeSpecialCharacters.Replace("/", "").Replace(".", "").Replace("-", "").Replace(",", "").Replace(" ", "");
	}

	public void SetPersonStatus(EPersonStatus status) {
		Status = status;
	}

	public void SetName(string firstName, string lastName) {
		FirstName = firstName;
		LastName = lastName;
		Validate();
	}

	public void SetEmail(string email) {
		Email = email;
		Validate();
	}

	public void SetPhone(string countryCode, string ddd, string numberWithDigit) {
		CountryCode = countryCode;
		DDD = ddd;
		NumberWithDigit = numberWithDigit;
		Validate();
	}

	public void SetAddress(string neighboorhood, string? houseNumber, bool hasHouseNumber, string complement, string street, string city, string state,
		string country, string zipcode) {
		Neighboorhood = neighboorhood;
		HouseNumber = houseNumber;
		HasHouseNumber = hasHouseNumber;
		Complement = complement;
		Street = street;
		City = city;
		State = state;
		Country = country;
		Zipcode = RemoveSpecialCharacters(zipcode);
		Validate();
	}

	public EPersonStatus Status { get; private set; }
	public string FirstName { get; private set; }
	public string LastName { get; private set; }
	public string Email { get; private set; }
	public string Document { get; private set; }
	public EDocumentType Type { get; private set; }
	public string CountryCode { get; private set; }
	public string DDD { get; private set; }
	public string NumberWithDigit { get; private set; }
	public string Neighboorhood { get; private set; }
	public string? HouseNumber { get; private set; }
	public bool HasHouseNumber { get; private set; }
	public string Complement { get; private set; }
	public string Street { get; private set; }
	public string City { get; private set; }
	public string State { get; private set; }
	public string Country { get; private set; }
	public string Zipcode { get; private set; }
	public Person() { }
}