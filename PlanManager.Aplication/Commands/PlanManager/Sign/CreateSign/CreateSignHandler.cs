using Flunt.Notifications;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Aplication.Interfaces.PlanManager;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Enums;
using PlanManager.Domain.Repositories;

namespace PlanManager.Aplication.Commands.PlanManager.Sign.CreateSign;

public class CreateSignHandler : Notifiable<Notification>, IRequestHandler<CreateSignCommand, ResultDto<SignCreatedDto>>
{
    private readonly ISignService _signService;
    private readonly ILogActivityService _logActivityService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSignHandler(ISignService signService, ILogActivityService logActivityService, IUnitOfWork unitOfWork)
    {
        _signService = signService;
        _logActivityService = logActivityService;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultDto<SignCreatedDto>> Handle(CreateSignCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid)
            return ResultDto<SignCreatedDto>.Fail(request.Notifications);
        var sign = new Domain.Entities.PlanManager.Sign(request.IdCustomer, request.IdCompany, request.IdPlan);
        if (await _signService.VerifyIfSignExists(sign))
            return ResultDto<SignCreatedDto>.Fail(new Notification("Sign.Handler", "Sign already exists"));

        await _signService.AddSign(sign);
        await _logActivityService.CreateLog(ELogType.Success, EAction.Created, ELogCode.CreateSign, sign.Id, "Sign Created successfully");
        await _unitOfWork.CommitAsync();

        return ResultDto<SignCreatedDto>.Ok(new SignCreatedDto());
    }
}