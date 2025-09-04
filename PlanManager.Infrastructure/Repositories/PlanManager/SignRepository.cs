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

    public async Task<Sign?> GetSignByIdentification(string identification)
    {
        return await _context.Signs.Where(x => x.Identification == identification).FirstOrDefaultAsync();
    }

    public async Task<IList<PlanPermission>> GetPlanPermissionBySignIdentification(string signIdentification)
    {
        var query = _context.Signs.Include(x => x.Plan).ThenInclude(x=>x.Permissions).ThenInclude(x=>x.PlanPermission).Where(x => x.Identification == signIdentification);

        return await query.SelectMany(x => x.Plan.Permissions).Select(x => x.PlanPermission).AsNoTracking()
            .ToListAsync();
    }

    public async Task<string> GetPlanIdentificationBySignIdentification(string signIdentification)
    {
        return await _context.Signs.Include(x => x.Plan).Where(x => x.Identification == signIdentification)
            .Select(x => x.Plan.Identification).AsNoTracking().FirstOrDefaultAsync();
    }
}