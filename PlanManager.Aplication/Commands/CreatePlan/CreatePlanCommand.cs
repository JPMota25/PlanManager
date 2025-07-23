using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Domain.ValueObjects;
using ICommand = PlanManager.Domain.Commands.ICommand;

namespace PlanManager.Aplication.Commands.CreatePlan;

public class CreatePlanCommand : Notifiable<Notification>, IRequest<ResultDto<PlanCreatedDto>>, ICommand {
	public void Validate() {
		var contract = new Contract<Notification>().Requires().IsTrue(Name.IsValid, "PlanCommand.Name", "Name is invalid");
		AddNotifications(Name.Notifications);
		contract.IsTrue(Value.IsValid, "PlanCommand.Value", "Value is invalid");
		AddNotifications(Value.Notifications);
		AddNotifications(contract);
	}

	public CreatePlanCommand(Name name, Value value, Id idCompany) {
		Name = name;
		Value = value;
		IdCompany = idCompany;
		Validate();
	}

	public Name Name { get; private set; }
	public Value Value { get; private set; }
	public Id IdCompany { get; private set; }
}