using PlanManager.Domain.Entities.PlanManager;

namespace PlanManager.Aplication.Interfaces.PlanManager;

public interface ISignService {
	Task<bool> VerifyIfSignExists(Sign sign);
	Task AddSign(Sign sign);
}