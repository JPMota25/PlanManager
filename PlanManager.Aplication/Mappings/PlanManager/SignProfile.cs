using AutoMapper;
using PlanManager.Aplication.Commands.CreateSign;
using PlanManager.Aplication.DTOs.Request.PlanManager;
using PlanManager.Aplication.DTOs.Request.ValueObjects;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Mappings.PlanManager;

public class SignProfile : Profile {
	public SignProfile() {
		CreateMap<IdDto, Id>().ConvertUsing(x => new Id(x.Id));
		CreateMap<CreateSignDto, CreateSignCommand>()
			.ForMember(x=>x.IdCustomer, y=>y.MapFrom(x=>x.IdCustomer))
			.ForMember(x => x.IdCompany, y=> y.MapFrom(x=>x.IdCompany))
			.ForMember(x=>x.Status, y=> y.MapFrom(x=>x.Status));
	}
}