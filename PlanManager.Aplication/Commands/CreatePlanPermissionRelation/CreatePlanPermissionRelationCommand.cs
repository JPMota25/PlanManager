using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Request;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Domain.Commands;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Commands.CreatePlanPermissionRelation;

public class CreatePlanPermissionRelationCommand : Notifiable<Notification>, IRequest<ResultDto<PlanPermissionRelationCreatedDto>>, ICommand {
	public void Validate() {
		var contract = new Contract<Notification>().Requires();
		AddNotifications(contract);
	}

	public CreatePlanPermissionRelationCommand(Id plan, Id planPermission) {
		Plan = plan;
		PlanPermission = planPermission;
		Validate();
	}

	public Id Plan { get; private set; }
	public Id PlanPermission { get; private set; }
}