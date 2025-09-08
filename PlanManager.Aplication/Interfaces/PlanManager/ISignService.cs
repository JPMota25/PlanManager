using PlanManager.Domain.Entities.PlanManager;

namespace PlanManager.Aplication.Interfaces.PlanManager;

public interface ISignService
{
    Task<bool> VerifyIfSignExists(Sign sign);
    Task AddSign(Sign sign);
    Task VerifyLicensesToUpdateSignStatus(string identification);
    Task<IList<PlanPermission>> GetPlanPermissionBySignIdentification(string signIdentification);
    Task<string> GetPlanIdentificationBySignIdentification(string signIdentification);
}