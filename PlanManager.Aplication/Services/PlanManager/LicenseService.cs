using PlanManager.Aplication.Interfaces.PlanManager;
using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.Repositories.PlanManager;

namespace PlanManager.Aplication.Services.PlanManager;

public class LicenseService : ILicenseService {
	private readonly ILicenseRepository _licenseRepository;

	public LicenseService(ILicenseRepository licenseRepository) {
		_licenseRepository = licenseRepository;
	}

	public async Task<bool> VerifyIfLicenseExists(License license) {
		var result = await _licenseRepository.GetLicense(license);
		return result != null;
	}

	public async Task AddLicense(License license) {
		await _licenseRepository.AddAsync(license);
	}
}