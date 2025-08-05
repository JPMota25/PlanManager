namespace PlanManager.Domain.DTOs.Response;

public class PlanDto {
	public string Id { get; set; }
	public string Name { get; set; }
	public decimal Value { get; set; }
}

public class ListPlanDto {
	public IList<PlanDto> Plans { get; set; }
	public ListPlanDto(IList<PlanDto> plans) {
		Plans = plans;
	}
}