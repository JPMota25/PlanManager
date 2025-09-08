using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response.Profiles.Person;
using PlanManager.Domain.Commands;
using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Aplication.Commands.Profiles.Customer.CreateCustomer;

public class CreateCustomerCommand : Notifiable<Notification>, IRequest<ResultDto<ResponsePersonCreated>>, ICommand
{
    public CreateCustomerCommand(Person person)
    {
        Person = person;
        Validate();
    }

    public void Validate()
    {
        var contract = new Contract<Notification>().Requires();
        AddNotifications(Person.Notifications);
        AddNotifications(contract);
    }

    public Person Person { get; private set; }
    public string IdCompany { get; private set; }
}