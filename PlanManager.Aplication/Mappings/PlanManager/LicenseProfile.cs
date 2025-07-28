using AutoMapper;
using PlanManager.Aplication.Commands.CreateLicense;
using PlanManager.Aplication.DTOs.Request.PlanManager;
using PlanManager.Aplication.DTOs.Request.ValueObjects;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Mappings.PlanManager;

public class LicenseProfile : Profile{
	public LicenseProfile() {
		CreateMap<IdDto, Id>().ConvertUsing(x=> new Id(x.Id));
		CreateMap<ValueDto, Value>().ConvertUsing(x=> new Value(x.ValueWith2Digit));
		CreateMap<ExpireDateDto, ExpireDate>().ConvertUsing(x=> new ExpireDate(x.Expire, x.ProlongationInDays));
		CreateMap<CreateLicenseDto, CreateLicenseCommand>().ForMember(x => x.IdPlan, y => y.MapFrom(x => x.IdPlan))
			.ForMember(x => x.IdSign, y => y.MapFrom(x => x.IdSign)).ForMember(x => x.Type, y => y.MapFrom(x => x.Type))
			.ForMember(x => x.Value, y => y.MapFrom(x => x.Value))
			.ForMember(x=>x.ExpireDate, y=>y.MapFrom(x=>x.ExpireDate));
	}
}