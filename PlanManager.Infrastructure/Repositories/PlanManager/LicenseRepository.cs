using Microsoft.EntityFrameworkCore;
using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.Repositories.PlanManager;
using PlanManager.Infrastructure.Data;

namespace PlanManager.Infrastructure.Repositories.PlanManager;

public class LicenseRepository : Repository<License>, ILicenseRepository {
	private readonly PlanManagerDbContext _context;

	public LicenseRepository(PlanManagerDbContext context) : base(context) {
		_context = context;
	}


	public async Task<License?> GetLicense(License license) {
		return await _context.Licenses.FirstOrDefaultAsync(x=>x.IdPlan == license.IdPlan && x.IdSign == license.IdSign);
	}
}