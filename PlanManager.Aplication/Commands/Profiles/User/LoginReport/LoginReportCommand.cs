using Flunt.Notifications;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Domain.Commands;
using PlanManager.Domain.DTOs.Response;

namespace PlanManager.Aplication.Commands.Profiles.User.LoginReport;

public class LoginReportCommand : Notifiable<Notification>, ICommand, IRequest<ResultDto<ListLoginReportDto>>
{
    public void Validate()
    {
        throw new NotImplementedException();
    }

    public LoginReportCommand(string? email, string? document, DateTime initialTime, DateTime finalTime, int skip, int take)
    {
        Email = email;
        Document = document;
        InitialTime = initialTime;
        FinalTime = finalTime;
        Skip = skip;
        Take = take;
    }

    public string? Email { get; private set; }
    public string? Document { get; private set; }
    public DateTime InitialTime { get; private set; }
    public DateTime? FinalTime { get; private set; }
    public int Skip { get; private set; }
    public int Take { get; private set; }
}