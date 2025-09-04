using AutoMapper;
using PlanManager.Aplication.Commands.Profiles.Customer.CreateCustomer;
using PlanManager.Aplication.DTOs.Request.Profiles;

namespace PlanManager.Aplication.Mappings.Profiles;

public class CustomerProfile : Profile {
	public CustomerProfile() {
		CreateMap<CreateCustomerDto, CreateCustomerCommand>().ForMember(x => x.Person, y => y.MapFrom(x => x.Person))
            .ForMember(x=>x.IdCompany, y=>y.MapFrom(x=>x.IdCompany));
	}
}