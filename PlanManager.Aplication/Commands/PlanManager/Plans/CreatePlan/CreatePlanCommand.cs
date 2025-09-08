using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response.PlanManager.Plan;
using ICommand = PlanManager.Domain.Commands.ICommand;

namespace PlanManager.Aplication.Commands.PlanManager.Plans.CreatePlan;

public class CreatePlanCommand : Notifiable<Notification>, IRequest<ResultDto<ResponsePlanCreated>>, ICommand
{
    public void Validate()
    {
        var contract = new Contract<Notification>().Requires();
        AddNotifications(contract);
    }

    public CreatePlanCommand(string name, decimal value, string idCompany)
    {
        Name = name;
        Value = value;
        IdCompany = idCompany;
        Validate();
    }

    public string Name { get; private set; }
    public decimal Value { get; private set; }
    public string IdCompany { get; private set; }
}