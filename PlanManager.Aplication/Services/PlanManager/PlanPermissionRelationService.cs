using PlanManager.Aplication.Interfaces.PlanManager;
using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.Repositories.PlanManager;

namespace PlanManager.Aplication.Services.PlanManager;

public class PlanPermissionRelationService : IPlanPermissionRelationService
{
    private readonly IPlanPermissionRelationRepository _planPermissionRelationRepository;

    public PlanPermissionRelationService(IPlanPermissionRelationRepository planPermissionRelationRepository)
    {
        _planPermissionRelationRepository = planPermissionRelationRepository;
    }

    public async Task<bool> VerifyPlanPermissionRelationIfExists(PlanPermissionRelation planPermissionRelation)
    {
        var result = await _planPermissionRelationRepository.VerifyPlanPermissionRelation(planPermissionRelation);
        return result != null;
    }

    public async Task AddPlanPermissionRelation(PlanPermissionRelation planPermissionRelation)
    {
        await _planPermissionRelationRepository.AddAsync(planPermissionRelation);
    }
}