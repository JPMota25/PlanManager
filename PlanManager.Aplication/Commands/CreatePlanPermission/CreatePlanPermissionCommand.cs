using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Domain.Commands;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Commands.CreatePlanPermission;

public class CreatePlanPermissionCommand : Notifiable<Notification>, IRequest<ResultDto<PlanPermissionCreatedDto>>, ICommand {
	public void Validate() {
		var contract = new Contract<Notification>().Requires().IsTrue(Name.IsValid, "PlanPermission.Name");
		AddNotifications(Name.Notifications);
		AddNotifications(contract);
	}

	public Name Name { get; private set; }
	public Id IdCompany { get; private set; }

	public CreatePlanPermissionCommand(Name name, Id idCompany) {
		Name = name;
		IdCompany = idCompany;
		Validate();
	}
}