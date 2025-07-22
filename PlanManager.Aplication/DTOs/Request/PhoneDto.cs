namespace PlanManager.Aplication.DTOs.Request;

public class PhoneDto {
	public PhoneDto(string countryCode, string ddd, string numberWithDigit) {
		CountryCode = countryCode;
		DDD = ddd;
		NumberWithDigit = numberWithDigit;
	}

	public PhoneDto() {

	}
	public string CountryCode { get; set; }
	public string DDD { get; set; }
	public string NumberWithDigit { get; set; }
}