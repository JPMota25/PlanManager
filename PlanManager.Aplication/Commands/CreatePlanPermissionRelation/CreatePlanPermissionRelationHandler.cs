using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Aplication.Interfaces.PlanManager;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.Enums;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Commands.CreatePlanPermissionRelation;

public class CreatePlanPermissionRelationHandler : IRequestHandler<CreatePlanPermissionRelationCommand, ResultDto<PlanPermissionRelationCreatedDto>> {
	private readonly IPlanPermissionRelationService _planPermissionRelationService;
	private readonly ILogActivityService _logActivityService;

	public CreatePlanPermissionRelationHandler(IPlanPermissionRelationService planPermissionRelationService, ILogActivityService logActivityService) {
		_planPermissionRelationService = planPermissionRelationService;
		_logActivityService = logActivityService;
	}
	public async Task<ResultDto<PlanPermissionRelationCreatedDto>> Handle(CreatePlanPermissionRelationCommand request, CancellationToken cancellationToken) {
		if (!request.IsValid)
			return ResultDto<PlanPermissionRelationCreatedDto>.Fail(request.Notifications);

		var planPermissionRelation = new PlanPermissionRelation(request.PlanPermission, request.Plan);
		if (await _planPermissionRelationService.VerifyPlanPermissionRelationIfExists(planPermissionRelation))
			return ResultDto<PlanPermissionRelationCreatedDto>.Fail(planPermissionRelation.Notifications);

		await _planPermissionRelationService.AddPlanPermissionRelation(planPermissionRelation);
		await _logActivityService.CreateLog(ELogType.Success, EAction.Created, ELogCode.CreatePlanPermissionRelation, planPermissionRelation.Id,
			new Description("PlanPermissionRelation Created successfully."));

		return ResultDto<PlanPermissionRelationCreatedDto>.Ok(new PlanPermissionRelationCreatedDto(planPermissionRelation.Id.Identifier,
			planPermissionRelation.IdPlan.Identifier, planPermissionRelation.IdPlanPermission.Identifier, planPermissionRelation.CreatedAt));
	}
}