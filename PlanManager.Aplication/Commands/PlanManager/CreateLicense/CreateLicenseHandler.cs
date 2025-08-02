using Flunt.Notifications;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Aplication.Interfaces.PlanManager;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.Enums;
using PlanManager.Domain.Repositories;

namespace PlanManager.Aplication.Commands.PlanManager.CreateLicense;

public class CreateLicenseHandler : Notifiable<Notification>, IRequestHandler<CreateLicenseCommand, ResultDto<LicenseCreatedDto>> {
	private readonly ILicenseService _licenseService;
	private readonly ILogActivityService _logActivityService;
	private readonly IUnitOfWork _unitOfWork;

	public CreateLicenseHandler(ILicenseService licenseService, ILogActivityService logActivityService, IUnitOfWork unitOfWork) {
		_licenseService = licenseService;
		_logActivityService = logActivityService;
		_unitOfWork = unitOfWork;
	}

	public async Task<ResultDto<LicenseCreatedDto>> Handle(CreateLicenseCommand request, CancellationToken cancellationToken) {
		if (!request.IsValid)
			return ResultDto<LicenseCreatedDto>.Fail(request.Notifications);
		var license = new License(request.IdSign, request.IdPlan, request.Type, request.Expire, request.ProlongationInDays, request.Value);
		if (await _licenseService.VerifyIfLicenseExists(license))
			return ResultDto<LicenseCreatedDto>.Fail(new Notification("License.Handler", "License is already created"));

		await _licenseService.AddLicense(license);
		await _logActivityService.CreateLog(ELogType.Success, EAction.Created, ELogCode.CreateLicense, license.Id, "License created successfully.");
		await _unitOfWork.CommitAsync();

		return ResultDto<LicenseCreatedDto>.Ok(new LicenseCreatedDto(license.Id, license.IdSign, license.IdPlan, license.Value, license.Type.ToString(),
			license.Status.ToString()));
	}
}