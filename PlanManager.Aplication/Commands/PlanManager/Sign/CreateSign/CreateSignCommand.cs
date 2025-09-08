using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response.PlanManager.Sign;
using PlanManager.Domain.Commands;

namespace PlanManager.Aplication.Commands.PlanManager.Sign.CreateSign;

public class CreateSignCommand : Notifiable<Notification>, IRequest<ResultDto<ResponseSignCreated>>, ICommand
{
    public void Validate()
    {
        var contract = new Contract<Notification>().Requires();
        AddNotifications(contract);
    }

    public CreateSignCommand(string idCustomer, string idCompany)
    {
        IdCustomer = idCustomer;
        IdCompany = idCompany;
        Validate();
    }

    public string IdCustomer { get; private set; }
    public string IdCompany { get; private set; }
    public string IdPlan { get; private set; }
}