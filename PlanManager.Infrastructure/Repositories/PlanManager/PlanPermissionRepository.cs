using Microsoft.EntityFrameworkCore;
using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.Repositories.PlanManager;
using PlanManager.Infrastructure.Data;

namespace PlanManager.Infrastructure.Repositories.PlanManager;

public class PlanPermissionRepository : Repository<PlanPermission>, IPlanPermissionRepository {
	private readonly PlanManagerDbContext _context;

	public PlanPermissionRepository(PlanManagerDbContext context) : base(context) {
		_context = context;
	}

	public async Task<bool> VerifyPlanPermissionIsUniqueByName(string name) {
		var result = await _context.PlanPermissions.FirstOrDefaultAsync(x => x.Name == name);
		return result == null;
	}
}