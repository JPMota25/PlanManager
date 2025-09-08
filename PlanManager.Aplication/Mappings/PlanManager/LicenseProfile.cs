using AutoMapper;
using PlanManager.Aplication.Commands.PlanManager.License.CreateLicense;
using PlanManager.Aplication.Commands.PlanManager.License.VerifyLicenseAuthencity;
using PlanManager.Aplication.DTOs.Request.PlanManager;
using PlanManager.Aplication.DTOs.Request.PlanManager.License;

namespace PlanManager.Aplication.Mappings.PlanManager
{
    public class LicenseProfile : Profile
    {
        public LicenseProfile()
        {
            CreateMap<GenerateJwt, GenerateLicenseCommand>()
                .ForMember(dest => dest.CustomerIdentification, sender => sender.MapFrom(dest => dest.CustomerIdentification))
                .ForMember(dest => dest.SignIdentification, sender => sender.MapFrom(dest => dest.SignIdentification));

            CreateMap<CreateLicenseDto, CreateLicenseCommand>()
                .ConstructUsing(src => new CreateLicenseCommand(
                    src.IdSign,
                    src.IdPlan,
                    src.Value,
                    src.Type,
                    src.Expire,
                    src.ProlongationInDays ?? 0 // se null, vira 0
                ));
        }
    }
}
