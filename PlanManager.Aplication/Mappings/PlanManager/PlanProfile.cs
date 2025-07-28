using AutoMapper;
using PlanManager.Aplication.Commands.CreatePlan;
using PlanManager.Aplication.DTOs.Request;
using PlanManager.Aplication.DTOs.Request.ValueObjects;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Mappings.PlanManager;

public class PlanProfile : Profile {
	public PlanProfile() {
		CreateMap<NameDto, Name>().ConvertUsing(x => new Name(x.Name));
		CreateMap<ValueDto, Value>().ConvertUsing(x => new Value(x.ValueWith2Digit));
		CreateMap<IdDto, Id>().ConvertUsing(x => new Id(x.Id));
		CreateMap<CreatePlanDto, CreatePlanCommand>().ForMember(x => x.Name, y => y.MapFrom(x => x.Name)).ForMember(x => x.Value, y => y.MapFrom(x => x.Value))
			.ForMember(x => x.IdCompany, y => y.MapFrom(x => x.IdCompany));
	}
}