using Microsoft.EntityFrameworkCore;
using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.Enums;
using PlanManager.Domain.Repositories.PlanManager;
using PlanManager.Infrastructure.Data;

namespace PlanManager.Infrastructure.Repositories.PlanManager;

public class LicenseRepository : Repository<License>, ILicenseRepository
{
    private readonly PlanManagerDbContext _context;

    public LicenseRepository(PlanManagerDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> VerifyIfAlreadyHasActiveLicense(string idSign)
    {
        License license = await _context.Licenses.Where(x => x.IdSign == idSign && x.Status == ELicenseStatus.Active)
            .FirstOrDefaultAsync();
        return license != null;
    }

    public async Task<DateOnly?> GetActiveLicenseExpiration(string signIdentification)
    {
        return await _context.Licenses.Include(x => x.Sign).Where(x => x.Sign.Identification == signIdentification)
            .Select(obj => obj.Expire).FirstOrDefaultAsync();
    }

    public async Task<IList<License>> GetLicensesBySignIdentification(string signIdentification)
    {
        return await _context.Licenses.Include(x => x.Sign).Where(x => x.Sign.Identification == signIdentification)
            .ToListAsync();
    }
}