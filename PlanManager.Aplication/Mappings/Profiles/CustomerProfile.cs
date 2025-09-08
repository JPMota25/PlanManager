using AutoMapper;
using PlanManager.Aplication.Commands.Profiles.Customer.CreateCustomer;
using PlanManager.Aplication.DTOs.Request.Profiles.Customer;

namespace PlanManager.Aplication.Mappings.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<RequestCreateCustomer, CreateCustomerCommand>().ForMember(x => x.Person, y => y.MapFrom(x => x.Person))
            .ForMember(x => x.IdCompany, y => y.MapFrom(x => x.IdCompany));
    }
}