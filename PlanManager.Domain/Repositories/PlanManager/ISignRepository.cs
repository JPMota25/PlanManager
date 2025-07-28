using PlanManager.Domain.Entities.PlanManager;

namespace PlanManager.Domain.Repositories.PlanManager;

public interface ISignRepository : IRepository<Sign> {
	Task<Sign?> GetSign(Sign sign);
}