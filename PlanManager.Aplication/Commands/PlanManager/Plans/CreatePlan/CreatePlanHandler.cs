using Flunt.Notifications;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response.PlanManager.Plan;
using PlanManager.Aplication.Interfaces.PlanManager;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.Enums;
using PlanManager.Domain.Repositories;

namespace PlanManager.Aplication.Commands.PlanManager.Plans.CreatePlan;

public class CreatePlanHandler : Notifiable<Notification>, IRequestHandler<CreatePlanCommand, ResultDto<PlanCreatedDto>> {
	private readonly IPlanService _planService;
	private readonly ILogActivityService _logActivityService;
	private readonly IUnitOfWork _unitOfWork;

	public CreatePlanHandler(IPlanService planService, ILogActivityService logActivityService, IUnitOfWork unitOfWork) {
		_planService = planService;
		_logActivityService = logActivityService;
		_unitOfWork = unitOfWork;
	}

	public async Task<ResultDto<PlanCreatedDto>> Handle(CreatePlanCommand request, CancellationToken cancellationToken) {
		if (!request.IsValid)
			return ResultDto<PlanCreatedDto>.Fail(request.Notifications);

		var plan = new Plan(request.Name, request.Value, request.IdCompany);
		if (await _planService.GetPlanByNameAndCompany(plan.Name, plan.IdCompany) != null)
			return ResultDto<PlanCreatedDto>.Fail(new Notification("PlanHandler.Plan", "Plan name already exists"));

		await _planService.AddPlan(plan);
		await _logActivityService.CreateLog(ELogType.Success, EAction.Created, ELogCode.CreatePlan, plan.Id, "Plan created succesfully.");
		await _unitOfWork.CommitAsync();

		return ResultDto<PlanCreatedDto>.Ok(new PlanCreatedDto(plan.Id, plan.Name, plan.Value, plan.IdCompany));
	}
}