namespace PlanManager.Aplication.DTOs.Request.Profiles;

public class LoginReportQueryDto {
	public string? Email { get; set; }
	public string? Document { get; set; }
	public DateTime InitialTime { get; set; }
	public DateTime? FinalTime { get; set; }
	public int Skip { get; set; }
	public int Take { get; set; }
}