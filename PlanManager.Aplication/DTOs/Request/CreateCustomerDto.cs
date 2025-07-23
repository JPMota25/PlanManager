namespace PlanManager.Aplication.DTOs.Request;

public class CreateCustomerDto {
	public CreateCustomerDto(FullNameDto fullName, EmailDto email, DocumentDto document, PhoneDto phone, AddressDto address) {
		FullName = fullName;
		Email = email;
		Document = document;
		Phone = phone;
		Address = address;
	}

	public FullNameDto FullName { get; set; }
	public EmailDto Email { get; set; }
	public DocumentDto Document { get; set; }
	public PhoneDto Phone { get; set; }
	public AddressDto Address { get; set; }

	public CreateCustomerDto() { }
}