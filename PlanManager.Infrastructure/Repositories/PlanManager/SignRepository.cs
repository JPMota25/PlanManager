using Microsoft.EntityFrameworkCore;
using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.Repositories.PlanManager;
using PlanManager.Infrastructure.Data;

namespace PlanManager.Infrastructure.Repositories.PlanManager;

public class SignRepository : Repository<Sign>, ISignRepository {
	private readonly PlanManagerDbContext _context;

	public SignRepository(PlanManagerDbContext context) : base(context) {
		_context = context;
	}

	public async Task<Sign?> GetSign(Sign sign) {
		return await _context.Signs.FirstOrDefaultAsync(x => x.IdCompany == sign.IdCompany && x.IdCustomer == sign.IdCustomer);
	}
}