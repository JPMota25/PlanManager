using Flunt.Notifications;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Domain.Commands;
using PlanManager.Domain.Enums;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Commands.CreateLicense;

public class CreateLicenseCommand : Notifiable<Notification>, IRequest<ResultDto<LicenseCreatedDto>>, ICommand {
	public void Validate() {
		throw new NotImplementedException();
	}

	public CreateLicenseCommand(Id idSign, Id idPlan, Value value, ELicenseType type) {
		IdSign = idSign;
		IdPlan = idPlan;
		Value = value;
		Type = type;
		Validate();
	}

	public Id IdSign { get; private set; }
	public Id IdPlan { get; init; }
	public Value Value { get; private set; }
	public ELicenseType Type { get; private set; }
	public ExpireDate? ExpireDate { get; private set; }
}