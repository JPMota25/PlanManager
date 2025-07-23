namespace PlanManager.Aplication.DTOs.Request;

public class EmailDto {
	public EmailDto(string emailAddress) {
		EmailAddress = emailAddress;
	}

	public EmailDto() { }
	public string EmailAddress { get; set; }
}