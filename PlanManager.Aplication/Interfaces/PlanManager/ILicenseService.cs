using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Aplication.Interfaces.PlanManager;

public interface ILicenseService {
	Task<bool> VerifyIfAlreadyHasActiveLicense(string idSign);
	Task AddLicense(License license);
    Task<DateOnly?> GetActiveLicenseExpiration(string signIdentification);
    Task<IList<License>> GetLicensesBySignIdentification(string signIdentification);
    Task<string> GenerateJwt(Customer customer, IList<PlanPermission> permissions, string signIdentification);
}