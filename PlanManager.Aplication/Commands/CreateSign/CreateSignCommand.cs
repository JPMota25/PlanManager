using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Domain.Commands;
using PlanManager.Domain.Enums;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Commands.CreateSign;

public class CreateSignCommand : Notifiable<Notification>, IRequest<ResultDto<SignCreatedDto>>, ICommand {
	public void Validate() {
		var contract = new Contract<Notification>().Requires();
		AddNotifications(contract);
	}

	public CreateSignCommand(Id idCustomer, Id idCompany, ESignStatus status) {
		IdCustomer = idCustomer;
		IdCompany = idCompany;
		Status = status;
		Validate();
	}

	public Id IdCustomer { get; private set; }
	public Id IdCompany { get; private set; }
	public ESignStatus Status { get; private set; }
}