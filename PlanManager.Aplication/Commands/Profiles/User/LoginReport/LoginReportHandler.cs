using Flunt.Notifications;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Aplication.Interfaces.Profiles;

namespace PlanManager.Aplication.Commands.Profiles.User.LoginReport;

public class LoginReportHandler : Notifiable<Notification>, IRequestHandler<LoginReportCommand, ResultDto<LoginReportDto>> {
	private readonly IUserService _userService;
	public LoginReportHandler(IUserService userService) {
		_userService = userService;
	}

	public async Task<ResultDto<LoginReportDto>> Handle(LoginReportCommand request, CancellationToken cancellationToken) {
		if (!request.IsValid)
			return ResultDto<LoginReportDto>.Fail(request.Notifications);


		return ResultDto<LoginReportDto>.Ok(new LoginReportDto());
	}
}