using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Domain.Commands;
using PlanManager.Domain.Enums;

namespace PlanManager.Aplication.Commands.PlanManager.License.CreateLicense;

public class CreateLicenseCommand : Notifiable<Notification>, IRequest<ResultDto<LicenseCreatedDto>>, ICommand {
	public void Validate()
    {
        var contract = new Contract<Notification>().Requires();
		AddNotifications(contract);
    }

	public CreateLicenseCommand(string idSign, string idPlan, decimal value, ELicenseType type, DateOnly? expire, int prolongationInDays) {
		IdSign = idSign;
		IdPlan = idPlan;
		Value = value;
		Type = type;
		Expire = expire;
		ProlongationInDays = prolongationInDays;
		Validate();
	}

	public string IdSign { get; private set; }
	public string IdPlan { get; init; }
	public decimal Value { get; private set; }
	public ELicenseType Type { get; private set; }
	public DateOnly? Expire { get; private set; }
	public int ProlongationInDays { get; private set; }
}