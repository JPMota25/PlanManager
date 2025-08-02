using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Domain.Commands;
using PlanManager.Domain.Enums;

namespace PlanManager.Aplication.Commands.PlanManager.CreateSign;

public class CreateSignCommand : Notifiable<Notification>, IRequest<ResultDto<SignCreatedDto>>, ICommand {
	public void Validate() {
		var contract = new Contract<Notification>().Requires();
		AddNotifications(contract);
	}

	public CreateSignCommand(string idCustomer, string idCompany, ESignStatus status) {
		IdCustomer = idCustomer;
		IdCompany = idCompany;
		Status = status;
		Validate();
	}

	public string IdCustomer { get; private set; }
	public string IdCompany { get; private set; }
	public ESignStatus Status { get; private set; }
}