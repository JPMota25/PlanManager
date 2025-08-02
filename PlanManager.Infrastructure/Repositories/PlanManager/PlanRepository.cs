using Microsoft.EntityFrameworkCore;
using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.Repositories.PlanManager;
using PlanManager.Infrastructure.Data;

namespace PlanManager.Infrastructure.Repositories.PlanManager;

public class PlanRepository : Repository<Plan>, IPlanRepository {
	private readonly PlanManagerDbContext _context;

	public PlanRepository(PlanManagerDbContext context) : base(context) {
		_context = context;
	}

	public async Task<Plan?> GetByName(string name, string idCompany) {
		return await _context.Plans.FirstOrDefaultAsync(x => x.Name == name && x.IdCompany == idCompany);
	}
}