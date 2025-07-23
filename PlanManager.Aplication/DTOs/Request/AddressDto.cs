namespace PlanManager.Aplication.DTOs.Request;

public class AddressDto {
	public AddressDto(string neighboorhood, string? houseNumber, bool hasHouseNumber, string complement, string street, string city, string state,
		string country, string zipcode) {
		Neighboorhood = neighboorhood;
		HouseNumber = houseNumber;
		HasHouseNumber = hasHouseNumber;
		Complement = complement;
		Street = street;
		City = city;
		State = state;
		Country = country;
		Zipcode = zipcode;
	}

	public AddressDto() { }
	public string Neighboorhood { get; set; }
	public string? HouseNumber { get; set; }
	public bool HasHouseNumber { get; set; }
	public string Complement { get; set; }
	public string Street { get; set; }
	public string City { get; set; }
	public string State { get; set; }
	public string Country { get; set; }
	public string Zipcode { get; set; }
}