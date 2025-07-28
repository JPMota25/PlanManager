namespace PlanManager.Aplication.DTOs.Request.ValueObjects;

public class EmailDto {
	public EmailDto(string emailAddress) {
		EmailAddress = emailAddress;
	}

	public EmailDto() { }
	public string EmailAddress { get; set; }
}