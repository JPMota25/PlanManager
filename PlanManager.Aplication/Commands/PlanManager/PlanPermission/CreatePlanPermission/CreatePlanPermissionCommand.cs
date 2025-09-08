using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response.PlanManager.PlanPermission;
using PlanManager.Domain.Commands;

namespace PlanManager.Aplication.Commands.PlanManager.PlanPermission.CreatePlanPermission;

public class CreatePlanPermissionCommand : Notifiable<Notification>, IRequest<ResultDto<ResponsePlanPermissionCreated>>, ICommand
{
    public void Validate()
    {
        var contract = new Contract<Notification>().Requires();
        AddNotifications(contract);
    }

    public CreatePlanPermissionCommand(string name, string idCompany)
    {
        Name = name;
        IdCompany = idCompany;
        Validate();
    }

    public string Name { get; private set; }
    public string IdCompany { get; private set; }
}