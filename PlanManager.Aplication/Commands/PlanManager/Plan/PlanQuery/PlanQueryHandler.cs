using Flunt.Notifications;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.Interfaces.PlanManager;
using PlanManager.Domain.DTOs.Response;

namespace PlanManager.Aplication.Commands.PlanManager.Plan.PlanQuery;

public class PlanQueryHandler : Notifiable<Notification>, IRequestHandler<PlanQueryCommand, ResultDto<ListPlanDto>> {
	private readonly IPlanService _planService;
	public PlanQueryHandler(IPlanService planService) {
		_planService = planService;
	}
	public async Task<ResultDto<ListPlanDto>> Handle(PlanQueryCommand request, CancellationToken cancellationToken) {
		if(!request.IsValid)
			return ResultDto<ListPlanDto>.Fail(new Notification("Query", "Query could not be validated."));
		return ResultDto<ListPlanDto>.Ok(new ListPlanDto(await _planService.ListPlans(request)));
	}
}