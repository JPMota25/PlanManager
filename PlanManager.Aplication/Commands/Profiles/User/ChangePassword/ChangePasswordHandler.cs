using System.Security.Claims;
using Flunt.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.Interfaces.Profiles;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Enums;
using PlanManager.Domain.Repositories;

namespace PlanManager.Aplication.Commands.Profiles.User.ChangePassword;

public class ChangePasswordHandler : Notifiable<Notification>, IRequestHandler<ChangePasswordCommand, ResultDto<string>> {
	private readonly IHttpContextAccessor _httpContextAccessor;
	private readonly ILogActivityService _logActivityService;
	private readonly IUserService _userService;
	private readonly IPasswordHashService _passwordHashService;
	private readonly IUnitOfWork _unitOfWork;

	public ChangePasswordHandler(IHttpContextAccessor httpContextAccessor, ILogActivityService logActivityService, IUserService userService,
		IPasswordHashService passwordHashService, IUnitOfWork unitOfWork) {
		_httpContextAccessor = httpContextAccessor;
		_logActivityService = logActivityService;
		_userService = userService;
		_passwordHashService = passwordHashService;
		_unitOfWork = unitOfWork;
	}

	public async Task<ResultDto<string>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken) {
		if (!request.IsValid)
			return ResultDto<string>.Fail(request.Notifications);

		var username = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (username == null)
			throw new InvalidOperationException("No username provided");

		var user = await _userService.AuthenticateAndReturnUser(username, request.Password);
		if (user == null)
			return ResultDto<string>.Fail(new Notification("Password", "Incorrect password."));

		user.SetPassword(_passwordHashService.HashPassword(request.NewPassword));
		await _logActivityService.CreateLog(ELogType.Success, EAction.Updated, ELogCode.PasswordUpdate, user.Id, "Password updated successfully");
		await _unitOfWork.CommitAsync();

		return ResultDto<string>.Ok("Password changed successfully.");
	}
}