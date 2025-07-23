using AutoMapper;
using PlanManager.Aplication.Commands.CreatePlanPermission;
using PlanManager.Aplication.DTOs.Request;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Mappings;

public class PlanPermissionProfile : Profile {
	public PlanPermissionProfile() {
		CreateMap<NameDto, Name>().ConvertUsing(x => new Name(x.Name));
		CreateMap<IdDto, Id>().ConvertUsing(x => new Id(x.Id));
		CreateMap<PlanPermissionDto, CreatePlanPermissionCommand>().ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
			.ForMember(x => x.IdCompany, y => y.MapFrom(x => x.IdCompany));
	}
}