using Flunt.Notifications;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response.PlanManager.License;
using PlanManager.Aplication.Interfaces.PlanManager;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Enums;
using PlanManager.Domain.Repositories;

namespace PlanManager.Aplication.Commands.PlanManager.License.CreateLicense;

public class CreateLicenseHandler : Notifiable<Notification>, IRequestHandler<CreateLicenseCommand, ResultDto<ResponseLicenseCreated>>
{
    private readonly ILicenseService _licenseService;
    private readonly ILogActivityService _logActivityService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateLicenseHandler(ILicenseService licenseService, ILogActivityService logActivityService, IUnitOfWork unitOfWork)
    {
        _licenseService = licenseService;
        _logActivityService = logActivityService;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultDto<ResponseLicenseCreated>> Handle(CreateLicenseCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid)
            return ResultDto<ResponseLicenseCreated>.Fail(request.Notifications);
        var license = new Domain.Entities.PlanManager.License(request.IdSign, request.Type, request.Expire, request.ProlongationInDays,
            request.Value);
        if (await _licenseService.VerifyIfAlreadyHasActiveLicense(license.IdSign))
            return ResultDto<ResponseLicenseCreated>.Fail(new Notification("License.Handler", "Already has a Active license."));

        await _licenseService.AddLicense(license);
        await _logActivityService.CreateLog(ELogType.Success, EAction.Created, ELogCode.CreateLicense, license.Id, "License created successfully.");
        await _unitOfWork.CommitAsync();

        return ResultDto<ResponseLicenseCreated>.Ok(new ResponseLicenseCreated(license.Id, license.IdSign, license.Value, license.Type.ToString(),
            license.Status.ToString()));
    }
}