using System.Text.Json.Serialization;
using Flunt.Validations;

namespace PlanManager.Domain.ValueObjects;

public class Phone : ValueObject {
	public string CountryCode { get; private set; }
	public string DDD { get; private set; }
	public string NumberWithDigit { get; private set; }

	[JsonConstructor]
	public Phone(string countryCode, string ddd, string numberWithDigit) {
		CountryCode = Format(countryCode);
		DDD = Format(ddd);
		NumberWithDigit = Format(numberWithDigit);
		Validate();
	}

	private void Validate() {
		AddNotifications(new Contract<Phone>().IsBetween(CountryCode.Length, 1, 6, "Phone.CountryCode", "Should be a Valid Country Code")
			.IsBetween(DDD.Length, 2, 6, "Phone.DDD", "Should be a Valid DDD")
			.AreEquals(NumberWithDigit.Length, 9, "Phone.NumberWithDigit", "Should be a Valid Number with digit"));
	}

	private static string Format(string removeSpecialCharacters) {
		return removeSpecialCharacters.Replace("/", "").Replace(".", "").Replace("-", "").Replace(",", "").Replace(" ", "");
	}
}