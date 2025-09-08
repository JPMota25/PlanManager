using AutoMapper;
using PlanManager.Aplication.Commands.Profiles.Company.CreateCompany;
using PlanManager.Aplication.DTOs.Request.Profiles.Company;

namespace PlanManager.Aplication.Mappings.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CreateCompanyDto, CreateCompanyCommand>().ForMember(x => x.Person, y => y.MapFrom(x => x.Person));
        }
    }
}
