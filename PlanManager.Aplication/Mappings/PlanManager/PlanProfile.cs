using AutoMapper;
using PlanManager.Aplication.Commands.PlanManager.Plans.CreatePlan;
using PlanManager.Aplication.Commands.PlanManager.Plans.PlanQuery;
using PlanManager.Aplication.DTOs.Request.PlanManager.Plan;

namespace PlanManager.Aplication.Mappings.PlanManager;

public class PlanProfile : Profile
{
    public PlanProfile()
    {
        CreateMap<RequestPlanReport, PlanQueryCommand>().ForMember(x => x.Id, y => y.MapFrom(z => z.Id)).ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.IdCompany, y => y.MapFrom(z => z.IdCompany)).ForMember(x => x.Skip, y => y.MapFrom(z => z.Skip))
            .ForMember(x => x.Take, y => y.MapFrom(z => z.Take));

        CreateMap<RequestCreatePlan, CreatePlanCommand>()
            .ConstructUsing(src => new CreatePlanCommand(
                src.Name,
                src.Value,
                src.IdCompany
            ));
    }
}