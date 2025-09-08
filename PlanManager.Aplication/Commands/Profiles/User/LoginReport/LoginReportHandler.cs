using Flunt.Notifications;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.Interfaces.Profiles;
using PlanManager.Domain.DTOs.Response;

namespace PlanManager.Aplication.Commands.Profiles.User.LoginReport;

public class LoginReportHandler : Notifiable<Notification>, IRequestHandler<LoginReportCommand, ResultDto<ListLoginReportDto>>
{
    private readonly IUserService _userService;

    public LoginReportHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<ResultDto<ListLoginReportDto>> Handle(LoginReportCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid)
            return ResultDto<ListLoginReportDto>.Fail(request.Notifications);
        var report = await _userService.GenerateLoginReport(request);
        return ResultDto<ListLoginReportDto>.Ok(new ListLoginReportDto(report));
    }
}