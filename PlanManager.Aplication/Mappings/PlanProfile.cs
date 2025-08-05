using AutoMapper;
using PlanManager.Aplication.Commands.PlanManager.Plan.PlanQuery;
using PlanManager.Aplication.DTOs.Request.PlanManager.Plan;

namespace PlanManager.Aplication.Mappings;

public class PlanProfile : Profile {
	public PlanProfile() {
		CreateMap<PlanQueryDto, PlanQueryCommand>().ForMember(x => x.Id, y => y.MapFrom(z => z.Id)).ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
			.ForMember(x => x.IdCompany, y => y.MapFrom(z => z.IdCompany)).ForMember(x => x.Skip, y => y.MapFrom(z => z.Skip))
			.ForMember(x => x.Take, y => y.MapFrom(z => z.Take));
	}
}