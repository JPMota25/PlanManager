using PlanManager.Aplication.Interfaces.PlanManager;
using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.Repositories.PlanManager;

namespace PlanManager.Aplication.Services.PlanManager;

public class PlanPermissionService : IPlanPermissionService
{
    private readonly IPlanPermissionRepository _planPermissionRepository;

    public PlanPermissionService(IPlanPermissionRepository planPermissionRepository)
    {
        _planPermissionRepository = planPermissionRepository;
    }

    public async Task AddPlanPermission(PlanPermission planPermission)
    {
        await _planPermissionRepository.AddAsync(planPermission);
    }

    public async Task<bool> VerifyIfPlanPermissionIsUniqueByName(string name)
    {
        return await _planPermissionRepository.VerifyPlanPermissionIsUniqueByName(name);
    }
}