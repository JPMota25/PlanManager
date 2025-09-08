using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Domain.Commands;

namespace PlanManager.Aplication.Commands.Profiles.User.ChangePassword;

public class ChangePasswordCommand : Notifiable<Notification>, ICommand, IRequest<ResultDto<string>>
{
    public void Validate()
    {
        var contract = new Contract<Notification>().Requires()
            .IsBetween(NewPassword.Length, 6, 20, "NewPassword", "New password needs to have beetween 6 and 20 characters");
        AddNotifications(contract);
    }

    public ChangePasswordCommand(string password, string newPassword)
    {
        Password = password;
        NewPassword = newPassword;
        Validate();
    }

    public string Password { get; private set; }
    public string NewPassword { get; private set; }
}