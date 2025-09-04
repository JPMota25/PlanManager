using AutoMapper;
using PlanManager.Aplication.Commands.PlanManager.PlanPermission.CreatePlanPermission;
using PlanManager.Aplication.DTOs.Request.PlanManager;

namespace PlanManager.Aplication.Mappings.PlanManager
{
    public class PlanPermissionProfile : Profile
    {
        public PlanPermissionProfile()
        {
            // DTO -> Command
            CreateMap<PlanPermissionDto, CreatePlanPermissionCommand>()
                .ConstructUsing(src => new CreatePlanPermissionCommand(
                    src.Name,
                    src.IdCompany
                ));
        }
    }
}