using Flunt.Notifications;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Aplication.Interfaces.PlanManager;
using PlanManager.Aplication.Interfaces.Profiles;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Enums;
using PlanManager.Domain.Repositories;

namespace PlanManager.Aplication.Commands.PlanManager.PlanPermission.CreatePlanPermission;

public class CreatePlanPermissionHandler : Notifiable<Notification>, IRequestHandler<CreatePlanPermissionCommand, ResultDto<PlanPermissionCreatedDto>> {
	private readonly IPlanPermissionService _planPermissionService;
    private readonly ICompanyService _companyService;
	private readonly ILogActivityService _logActivityService;
	private readonly IUnitOfWork _unitOfWork;

	public CreatePlanPermissionHandler(IPlanPermissionService planPermissionService, ICompanyService companyService, ILogActivityService logActivityService,
		IUnitOfWork unitOfWork) {
		_planPermissionService = planPermissionService;
        _companyService = companyService;
		_logActivityService = logActivityService;
		_unitOfWork = unitOfWork;
	}

	public async Task<ResultDto<PlanPermissionCreatedDto>> Handle(CreatePlanPermissionCommand request, CancellationToken cancellationToken) {
		if (!request.IsValid)
			return ResultDto<PlanPermissionCreatedDto>.Fail(request.Notifications);

		var planPermission = new Domain.Entities.PlanManager.PlanPermission(request.Name, request.IdCompany);
		if (!await _planPermissionService.VerifyIfPlanPermissionIsUniqueByName(planPermission.Name))
			return ResultDto<PlanPermissionCreatedDto>.Fail(new Notification("PlanPermission.IsUnique", "PlanPermission.Name already exists"));

		if (await _companyService.GetById(planPermission.IdCompany) == null)
			return ResultDto<PlanPermissionCreatedDto>.Fail(new Notification("PlanPermission.CompanyId", "Company not found"));

		await _planPermissionService.AddPlanPermission(planPermission);
		await _logActivityService.CreateLog(ELogType.Success, EAction.Created, ELogCode.CreatePlanPermission, planPermission.Id,
			"Creation of a new Plan permission");
		await _unitOfWork.CommitAsync();

		return ResultDto<PlanPermissionCreatedDto>.Ok(new PlanPermissionCreatedDto(planPermission.Name, planPermission.Code));
	}
}