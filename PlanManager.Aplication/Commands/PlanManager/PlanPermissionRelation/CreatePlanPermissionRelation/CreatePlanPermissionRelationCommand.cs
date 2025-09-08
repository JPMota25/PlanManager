using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Domain.Commands;

namespace PlanManager.Aplication.Commands.PlanManager.PlanPermissionRelation.CreatePlanPermissionRelation;

public class CreatePlanPermissionRelationCommand : Notifiable<Notification>, IRequest<ResultDto<PlanPermissionRelationCreatedDto>>, ICommand
{
    public void Validate()
    {
        var contract = new Contract<Notification>().Requires();
        AddNotifications(contract);
    }

    public CreatePlanPermissionRelationCommand(string idPlan, string idPlanPermission, string idCompany)
    {
        IdPlan = idPlan;
        IdPlanPermission = idPlanPermission;
        IdCompany = idCompany;
        Validate();
    }

    public string IdPlan { get; private set; }
    public string IdPlanPermission { get; private set; }
    public string IdCompany { get; private set; }
}