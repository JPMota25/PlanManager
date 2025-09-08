using PlanManager.Domain.Entities.PlanManager;

namespace PlanManager.Domain.Repositories.PlanManager;

public interface ISignRepository : IRepository<Sign>
{
    Task<Sign?> GetSign(Sign sign);
    Task<Sign?> GetSignByIdentification(string identification);
    Task<IList<PlanPermission>> GetPlanPermissionBySignIdentification(string signIdentification);
    Task<string> GetPlanIdentificationBySignIdentification(string signIdentification);
}