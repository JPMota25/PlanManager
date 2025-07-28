using PlanManager.Domain.Entities.PlanManager;

namespace PlanManager.Aplication.Interfaces.PlanManager;

public interface ILicenseService {
	Task<bool> VerifyIfLicenseExists(License license);
	Task AddLicense(License license);
}