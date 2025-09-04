using PlanManager.Domain.Entities.PlanManager;

namespace PlanManager.Domain.Repositories.PlanManager;

public interface ILicenseRepository : IRepository<License> {
	Task<bool> VerifyIfAlreadyHasActiveLicense(string idSign);
    Task<DateOnly?> GetActiveLicenseExpiration(string signIdentification);
    Task<IList<License>> GetLicensesBySignIdentification(string signIdentification);
}