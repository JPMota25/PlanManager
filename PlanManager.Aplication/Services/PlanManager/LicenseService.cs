using Microsoft.IdentityModel.Tokens;
using PlanManager.Aplication.Interfaces.PlanManager;
using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Repositories.PlanManager;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace PlanManager.Aplication.Services.PlanManager;

public class LicenseService : ILicenseService
{
    private readonly ILicenseRepository _licenseRepository;
    private readonly ISignService _signService;

    public LicenseService(ILicenseRepository licenseRepository, ISignService signService)
    {
        _licenseRepository = licenseRepository;
        _signService = signService;
    }

    //true = exists, false = not exists
    public async Task<bool> VerifyIfAlreadyHasActiveLicense(string idSign)
    {
        return await _licenseRepository.VerifyIfAlreadyHasActiveLicense(idSign);
    }

    public async Task AddLicense(License license)
    {
        await _licenseRepository.AddAsync(license);
    }

    public async Task<string> GenerateJwt(Customer customer, IList<PlanPermission> permissions, string signIdentification)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(customer.SecretToken);

        DateOnly? licenseExpDb = await GetActiveLicenseExpiration(signIdentification);
        string licenseExpString = (licenseExpDb != null ? licenseExpDb.ToString() : string.Empty)!;

        var permissionsJson = JsonSerializer.Serialize(permissions);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim("CustomerIdentification", customer.Identification),
                new Claim( "PlanPermissions", permissionsJson),
                new Claim("PlanIdentification", await _signService.GetPlanIdentificationBySignIdentification(signIdentification)),
                new Claim("LicenseExpiration", licenseExpString)
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