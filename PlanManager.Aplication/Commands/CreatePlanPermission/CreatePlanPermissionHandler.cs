using Flunt.Notifications;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Aplication.Interfaces.PlanManager;
using PlanManager.Aplication.Interfaces.Profiles;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.Enums;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Commands.CreatePlanPermission;

public class CreatePlanPermissionHandler : IRequestHandler<CreatePlanPermissionCommand, ResultDto<PlanPermissionCreatedDto>> {
	private readonly IPlanPermissionService _planPermissionService;
	private readonly IPersonService _personService;
	private readonly ILogActivityService _logActivityService;

	public CreatePlanPermissionHandler(IPlanPermissionService planPermissionService, IPersonService personService, ILogActivityService logActivityService) {
		_planPermissionService = planPermissionService;
		_personService = personService;
		_logActivityService = logActivityService;
	}

	public async Task<ResultDto<PlanPermissionCreatedDto>> Handle(CreatePlanPermissionCommand request, CancellationToken cancellationToken) {
		if (!request.IsValid)
			return ResultDto<PlanPermissionCreatedDto>.Fail(request.Notifications);

		var planPermission = new PlanPermission(request.Name, request.IdCompany);
		if (!await _planPermissionService.VerifyIfPlanPermissionIsUniqueByName(planPermission.Name))
			return ResultDto<PlanPermissionCreatedDto>.Fail(new Notification("PlanPermission.IsUnique", "PlanPermission.Name already exists"));

		if (await _personService.GetById(planPermission.IdCompany) == null)
			return ResultDto<PlanPermissionCreatedDto>.Fail(new Notification("PlanPermission.CompanyId", "Company not found"));

		await _planPermissionService.AddPlanPermission(planPermission);
		await _logActivityService.CreateLog(ELogType.Success, EAction.Created, ELogCode.CreatePlanPermission, planPermission.Id,
			new Description("Creation of a new Plan permission"));

		return ResultDto<PlanPermissionCreatedDto>.Ok(new PlanPermissionCreatedDto(planPermission.Name.Value, planPermission.Code.Code));
	}
}