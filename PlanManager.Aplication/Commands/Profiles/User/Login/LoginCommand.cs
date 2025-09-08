using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Domain.Commands;

namespace PlanManager.Aplication.Commands.Profiles.User.Login;

public class LoginCommand : Notifiable<Notification>, IRequest<ResultDto<JwtDto>>, ICommand
{
    public void Validate()
    {
        var contract = new Contract<Notification>().Requires();
        AddNotifications(contract);
    }

    public LoginCommand(string username, string password)
    {
        Username = username;
        Password = password;
        Validate();
    }

    public string Username { get; private set; }
    public string Password { get; private set; }
}