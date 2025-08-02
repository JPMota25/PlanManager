namespace PlanManager.Aplication.DTOs.Request.Profiles;

public class LoginReportQueryDto {
	public string? Email { get; set; }
	public string? Document { get; set; }
	public string? Username { get;  set; }
	public DateTime InitialTime { get; set; }
	public DateTime? FinalTime { get; set; }
	public int Skip { get; set; }
	public int Take { get; set; }
	public LoginReportQueryDto(string? email, string? document, string? username, DateTime initialTime, DateTime finalTime, int skip, int take) {
		Email = email;
		Document = document;
		Username = username;
		InitialTime = initialTime;
		FinalTime = finalTime;
		Skip = skip;
		Take = take;
	}
}