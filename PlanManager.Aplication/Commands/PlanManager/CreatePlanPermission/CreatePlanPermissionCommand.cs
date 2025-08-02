using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Domain.Commands;

namespace PlanManager.Aplication.Commands.PlanManager.CreatePlanPermission;

public class CreatePlanPermissionCommand : Notifiable<Notification>, IRequest<ResultDto<PlanPermissionCreatedDto>>, ICommand {
	public void Validate() {
		var contract = new Contract<Notification>().Requires();
		AddNotifications(contract);
	}


	public string Name { get; private set; }
	public string IdCompany { get; private set; }
}