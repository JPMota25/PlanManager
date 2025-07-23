using Microsoft.EntityFrameworkCore;
using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.Repositories.PlanManager;
using PlanManager.Domain.ValueObjects;
using PlanManager.Infrastructure.Data;

namespace PlanManager.Infrastructure.Repositories.PlanManager;

public class PlanRepository : Repository<Plan>, IPlanRepository {
	private readonly PlanManagerDbContext _context;

	public PlanRepository(PlanManagerDbContext context) : base(context) {
		_context = context;
	}

	public async Task<Plan?> GetByName(Name name) {
		return await _context.Plans.FirstOrDefaultAsync(x => x.Name.Value == name.Value);
	}
}