namespace PlanManager.Aplication.DTOs.Request.ValueObjects;

public class ExpireDateDto {
	public DateOnly Expire { get; set; }
	public int ProlongationInDays { get; set; }
}