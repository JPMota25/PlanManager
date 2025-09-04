using Microsoft.IdentityModel.Tokens;
using PlanManager.Aplication.Interfaces.PlanManager;
using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Repositories.PlanManager;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PlanManager.Aplication.Services.PlanManager;

public class LicenseService : ILicenseService {
	private readonly ILicenseRepository _licenseRepository;
    private readonly ISignService _signService;

    public LicenseService(ILicenseRepository licenseRepository, ISignService signService)
    {
        _licenseRepository = licenseRepository;
        _signService = signService;
    }

    //true = exists, false = not exists
    public async Task<bool> VerifyIfAlreadyHasActiveLicense(string idSign) {
		var result = await _licenseRepository.VerifyIfAlreadyHasActiveLicense(idSign);
		return result != null;
	}

	public async Task AddLicense(License license) {
		await _licenseRepository.AddAsync(license);
	}

    public async Task<string> GenerateJwt(Customer customer, IList<PlanPermission> permissions, string signIdentification)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(customer.Identification);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim("CustomerIdentification", customer.Identification),
                new Claim( "PlanPermissions", permissions.ToString()),
                new Claim("PlanIdentification", await _signService.GetPlanIdentificationBySignIdentification(signIdentification)),
                new Claim("LicenseExpiration", GetActiveLicenseExpiration(signIdentification).ToString())
            ]),
            Expires = DateTime.UtcNow.AddHours(360),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenResult = tokenHandler.WriteToken(token);
        return tokenResult;
    }

    public async Task<DateOnly?> GetActiveLicenseExpiration(string signIdentification)
    {
        return await _licenseRepository.GetActiveLicenseExpiration(signIdentification);
    }

    public async Task<IList<License>> GetLicensesBySignIdentification(string signIdentification)
    {
        return await _licenseRepository.GetLicensesBySignIdentification(signIdentification);
    }
}