using AutoMapper;
using PlanManager.Aplication.Commands.Profiles.Customer.CreateCustomer;
using PlanManager.Aplication.DTOs.Request.Profiles;

namespace PlanManager.Aplication.Mappins;

public class CustomerProfile : Profile {
	public CustomerProfile() {
		CreateMap<CreateCustomerDto, CreateCustomerCommand>()
			.ForMember(x => x.Person, y => y.MapFrom(x => x.Person));
	}
}