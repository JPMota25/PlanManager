using Flunt.Notifications;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Aplication.Interfaces.PlanManager;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.Enums;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Commands.CreateLicense;

public class CreateLicenseHandler : Notifiable<Notification>, IRequestHandler<CreateLicenseCommand, ResultDto<LicenseCreatedDto>> {
	private readonly ILicenseService _licenseService;
	private readonly ILogActivityService _logActivityService;

	public CreateLicenseHandler(ILicenseService licenseService, ILogActivityService logActivityService) {
		_licenseService = licenseService;
		_logActivityService = logActivityService;
	}

	public async Task<ResultDto<LicenseCreatedDto>> Handle(CreateLicenseCommand request, CancellationToken cancellationToken) {
		if (!request.IsValid)
			return ResultDto<LicenseCreatedDto>.Fail(request.Notifications);
		var license = new License(request.IdSign, request.IdPlan, request.Type, request.ExpireDate, request.Value);
		if (await _licenseService.VerifyIfLicenseExists(license))
			return ResultDto<LicenseCreatedDto>.Fail(new Notification("License.Handler", "License is already created"));

		await _licenseService.AddLicense(license);
		await _logActivityService.CreateLog(ELogType.Success, EAction.Created, ELogCode.CreateLicense, license.Id,
			new Description("License created successfully."));
		return ResultDto<LicenseCreatedDto>.Ok(new LicenseCreatedDto(license.Id.Identifier, license.IdSign.Identifier, license.IdPlan.Identifier,
			license.Value.ValueWith2Digits, license.Type.ToString(), license.Status.ToString()));
	}
}