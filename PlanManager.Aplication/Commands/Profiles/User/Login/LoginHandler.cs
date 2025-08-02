using Flunt.Notifications;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.Interfaces.Profiles;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Enums;

namespace PlanManager.Aplication.Commands.Profiles.User.Login;

public class LoginHandler : Notifiable<Notification>, IRequestHandler<LoginCommand, ResultDto<JwtDto>> {
	private readonly ILogActivityService _logActivityService;
	private readonly IUserService _userService;
	private readonly ITokenService _tokenService;

	public LoginHandler(ILogActivityService logActivityService, IUserService userService, ITokenService tokenService) {
		_logActivityService = logActivityService;
		_userService = userService;
		_tokenService = tokenService;
	}

	public async Task<ResultDto<JwtDto>> Handle(LoginCommand request, CancellationToken cancellationToken) {
		if (!request.IsValid)
			return ResultDto<JwtDto>.Fail(request.Notifications);

		var user = await _userService.AuthenticateAndReturnUser(request.Username, request.Password);
		if (user == null)
			return ResultDto<JwtDto>.Fail(new Notification("Authentication.User", "User not found or Password is incorrect"));

		await _logActivityService.CreateLog(ELogType.Success, EAction.Created, ELogCode.Login, user.Id, "User logged successfully.");

		return ResultDto<JwtDto>.Ok(new JwtDto(_tokenService.GenerateToken(user)));
	}
}