using Flunt.Notifications;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Domain.Commands;
using PlanManager.Domain.DTOs.Response;

namespace PlanManager.Aplication.Commands.PlanManager.Plans.PlanQuery;

public class PlanQueryCommand : Notifiable<Notification>, IRequest<ResultDto<ListPlanDto>>, ICommand
{
    public void Validate()
    {
        throw new NotImplementedException();
    }

    public PlanQueryCommand(string? id, string? name, string idCompany, int skip, int take)
    {
        Id = id;
        Name = name;
        Skip = skip;
        Take = take;
        IdCompany = idCompany;
    }

    public string? Id { get; private set; }
    public string? Name { get; private set; }
    public string IdCompany { get; private set; }
    public int Skip { get; private set; }
    public int Take { get; private set; }
}