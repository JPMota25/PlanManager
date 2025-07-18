using Flunt.Validations;

namespace PlanManager.Domain.ValueObjects;

public class Address : ValueObject {
	public string Neighboorhood { get; private set; }
	public string? HouseNumber { get; private set; }
	public bool HasHouseNumber { get; private set; }
	public string Complement { get; private set; }
	public string Street { get; private set; }
	public string City { get; private set; }
	public string State { get; private set; }
	public string Country { get; private set; }
	public string Zipcode { get; private set; }

	public Address(string neighboorhood, string houseNumber, bool hasHouseNumber, string complement, string street, string city, string state, string country,
		string zipcode) {
		Neighboorhood = neighboorhood;
		HouseNumber = houseNumber;
		HasHouseNumber = hasHouseNumber;
		Complement = complement;
		Street = street;
		City = city;
		State = state;
		Country = country;
		Zipcode = zipcode;

		Validate();
	}

	private void Validate() {
		var contract = new Contract<Address>()
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
}