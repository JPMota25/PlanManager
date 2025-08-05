using Microsoft.EntityFrameworkCore;
using PlanManager.Domain.DTOs.Response;
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

	public async Task<IList<PlanDto>> ListPlans(string? id, string? name, string idCompany, int skip, int take) {
		var context = _context.Plans.AsQueryable();
		if (!string.IsNullOrEmpty(id))
			context = context.Where(x => x.Id == id);
		if (!string.IsNullOrEmpty(name))
			context = context.Where(x => x.Name == name);

		return await context.Where(x => x.IdCompany == idCompany).Skip(skip).Take(take).Select(x=>new PlanDto {
			Id = x.Id,
			Name = x.Name,
			Value = x.Value
		}).ToListAsync();
	}
}