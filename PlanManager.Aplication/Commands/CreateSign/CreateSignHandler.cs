using Flunt.Notifications;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Aplication.Interfaces.PlanManager;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.Enums;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Commands.CreateSign;

public class CreateSignHandler : Notifiable<Notification>, IRequestHandler<CreateSignCommand, ResultDto<SignCreatedDto>> {
	private readonly ISignService _signService;
	private readonly ILogActivityService _logActivityService;

	public CreateSignHandler(ISignService signService, ILogActivityService logActivityService) {
		_signService = signService;
		_logActivityService = logActivityService;
	}

	public async Task<ResultDto<SignCreatedDto>> Handle(CreateSignCommand request, CancellationToken cancellationToken) {
		if (!request.IsValid)
			return ResultDto<SignCreatedDto>.Fail(request.Notifications);
		var sign = new Sign(request.IdCustomer, request.IdCompany);
		if (await _signService.VerifyIfSignExists(sign))
			return ResultDto<SignCreatedDto>.Fail(new Notification("Sign.Handler", "Sign already exists"));

		await _signService.AddSign(sign);
		await _logActivityService.CreateLog(ELogType.Success, EAction.Created, ELogCode.CreateSign, sign.Id, new Description("Sign Created successfully"));

		return ResultDto<SignCreatedDto>.Ok(new SignCreatedDto());
	}
}