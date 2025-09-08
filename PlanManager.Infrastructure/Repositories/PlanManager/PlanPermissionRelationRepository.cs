using Microsoft.EntityFrameworkCore;
using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.Repositories.PlanManager;
using PlanManager.Infrastructure.Data;

namespace PlanManager.Infrastructure.Repositories.PlanManager;

public class PlanPermissionRelationRepository : Repository<PlanPermissionRelation>, IPlanPermissionRelationRepository
{
    private readonly PlanManagerDbContext _context;

    public PlanPermissionRelationRepository(PlanManagerDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<PlanPermissionRelation?> VerifyPlanPermissionRelation(PlanPermissionRelation permissionRelation)
    {
        return await _context.PlanPermissionRelations.FirstOrDefaultAsync(x =>
            x.IdPlan == permissionRelation.IdPlan && x.IdPlanPermission == permissionRelation.IdPlanPermission);
    }
}