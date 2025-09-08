using AutoMapper;
using PlanManager.Aplication.Commands.PlanManager.Sign.CreateSign;
using PlanManager.Aplication.DTOs.Request.PlanManager;

namespace PlanManager.Aplication.Mappings.PlanManager
{
    public class SignProfile : Profile
    {
        public SignProfile()
        {
            CreateMap<CreateSignDto, CreateSignCommand>()
                .ConstructUsing(src => new CreateSignCommand(
                    src.IdCustomer,
                    src.IdCompany
                ))
                .ForMember(dest => dest.IdPlan, opt => opt.MapFrom(src => src.IdPlan));
        }
    }
}
