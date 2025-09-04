using AutoMapper;
using PlanManager.Aplication.Commands.PlanManager.PlanPermissionRelation.CreatePlanPermissionRelation;
using PlanManager.Aplication.DTOs.Request.PlanManager;

namespace PlanManager.Aplication.Mappings.PlanManager
{
    public class PlanPermissionRelationProfile : Profile
    {
        public PlanPermissionRelationProfile()
        {
            CreateMap<CreatePlanPermissionRelationDto, CreatePlanPermissionRelationCommand>()
                .ConstructUsing(src => new CreatePlanPermissionRelationCommand(
                    src.IdPlan,
                    src.IdPlanPermission,
                    src.IdCompany
                ));
        }
    }
}
