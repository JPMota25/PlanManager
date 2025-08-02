using PlanManager.Domain.Enums;

namespace PlanManager.Aplication.DTOs.Request.Profiles;

public class CreatePersonDto {
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }
	public string Document { get; set; }
	public EDocumentType Type { get; set; }
	public string CountryCode { get; set; }
	public string DDD { get; set; }
	public string NumberWithDigit { get; set; }
	public string Neighboorhood { get; set; }
	public string? HouseNumber { get; set; }
	public bool HasHouseNumber { get; set; }
	public string Complement { get; set; }
	public string Street { get; set; }
	public string City { get; set; }
	public string State { get; set; }
	public string Country { get; set; }
	public string Zipcode { get; set; }

	public CreatePersonDto(string firstName, string lastName, string email, string document, EDocumentType type, string countryCode, string ddd,
		string numberWithDigit, string neighboorhood, string? houseNumber, bool hasHouseNumber, string complement, string street, string city, string state,
		string country, string zipcode) {
		FirstName = firstName;
		LastName = lastName;
		Email = email;
		Document = document;
		Type = type;
		CountryCode = countryCode;
		DDD = ddd;
		NumberWithDigit = numberWithDigit;
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
}