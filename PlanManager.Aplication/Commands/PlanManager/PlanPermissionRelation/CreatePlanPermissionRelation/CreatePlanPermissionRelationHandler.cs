using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Aplication.Interfaces.PlanManager;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Enums;
using PlanManager.Domain.Repositories;

namespace PlanManager.Aplication.Commands.PlanManager.PlanPermissionRelation.CreatePlanPermissionRelation;

public class CreatePlanPermissionRelationHandler : IRequestHandler<CreatePlanPermissionRelationCommand, ResultDto<PlanPermissionRelationCreatedDto>>
{
    private readonly IPlanPermissionRelationService _planPermissionRelationService;
    private readonly ILogActivityService _logActivityService;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePlanPermissionRelationHandler(IPlanPermissionRelationService planPermissionRelationService, ILogActivityService logActivityService,
        IUnitOfWork unitOfWork)
    {
        _planPermissionRelationService = planPermissionRelationService;
        _logActivityService = logActivityService;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultDto<PlanPermissionRelationCreatedDto>> Handle(CreatePlanPermissionRelationCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid)
            return ResultDto<PlanPermissionRelationCreatedDto>.Fail(request.Notifications);

        var planPermissionRelation = new Domain.Entities.PlanManager.PlanPermissionRelation(request.IdPlanPermission, request.IdPlan, request.IdCompany);
        if (await _planPermissionRelationService.VerifyPlanPermissionRelationIfExists(planPermissionRelation))
            return ResultDto<PlanPermissionRelationCreatedDto>.Fail(planPermissionRelation.Notifications);

        await _planPermissionRelationService.AddPlanPermissionRelation(planPermissionRelation);
        await _logActivityService.CreateLog(ELogType.Success, EAction.Created, ELogCode.CreatePlanPermissionRelation, planPermissionRelation.Id,
            "PlanPermissionRelation Created successfully.");
        await _unitOfWork.CommitAsync();

        return ResultDto<PlanPermissionRelationCreatedDto>.Ok(new PlanPermissionRelationCreatedDto(planPermissionRelation.Id, planPermissionRelation.IdPlan,
            planPermissionRelation.IdPlanPermission, planPermissionRelation.CreatedAt));
    }
}