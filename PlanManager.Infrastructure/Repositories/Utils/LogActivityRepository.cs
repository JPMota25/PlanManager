using PlanManager.Domain.Entities.Utils;
using PlanManager.Domain.Repositories.Utils;
using PlanManager.Infrastructure.Data;

namespace PlanManager.Infrastructure.Repositories.Utils;

public class LogActivityRepository : Repository<LogActivity>, ILogActivityRepository
{
    private readonly PlanManagerDbContext _context;

    public LogActivityRepository(PlanManagerDbContext context) : base(context)
    {
        _context = context;
    }
}