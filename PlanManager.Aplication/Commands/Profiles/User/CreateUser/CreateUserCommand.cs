using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Domain.Commands;
using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Aplication.Commands.Profiles.User.CreateUser;

public class CreateUserCommand : Notifiable<Notification>, IRequest<ResultDto<UserCreatedDto>>, ICommand
{
    public void Validate()
    {
        var contract = new Contract<Notification>().Requires();
        AddNotifications(contract);
    }

    public CreateUserCommand(Person person, string username, string password)
    {
        Person = person;
        Username = username;
        Password = password;
        Validate();
    }

    public Person Person { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
}