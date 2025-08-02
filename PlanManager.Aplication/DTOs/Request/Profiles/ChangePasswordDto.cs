namespace PlanManager.Aplication.DTOs.Request.Profiles;

public class ChangePasswordDto {
	public string Password { get; set; }
	public string NewPassword { get; set; }
	public ChangePasswordDto(string password, string newPassword) {
		Password = password;
		NewPassword = newPassword;
	}
}