using PlanManager.Domain.Entities.PlanManager;

namespace PlanManager.Domain.Repositories.PlanManager;

public interface ILicenseRepository : IRepository<License> {
	Task<License?> GetLicense(License license);
}