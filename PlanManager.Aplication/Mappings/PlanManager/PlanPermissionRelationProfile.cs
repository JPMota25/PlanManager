using AutoMapper;
using PlanManager.Aplication.Commands.CreatePlanPermissionRelation;
using PlanManager.Aplication.DTOs.Request;
using PlanManager.Aplication.DTOs.Request.ValueObjects;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Mappings.PlanManager;

public class PlanPermissionRelationProfile : Profile {
	public PlanPermissionRelationProfile() {
		CreateMap<IdDto, Id>().ConvertUsing(x => new Id(x.Id));
		CreateMap<CreatePlanPermissionRelationDto, CreatePlanPermissionRelationCommand>().ForMember(x => x.Plan, y => y.MapFrom(x => x.Plan))
			.ForMember(x => x.PlanPermission, y => y.MapFrom(x => x.PlanPermission));
	}
}