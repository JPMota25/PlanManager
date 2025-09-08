using PlanManager.Aplication.Interfaces.PlanManager;
using PlanManager.Domain.Entities.PlanManager;
using PlanManager.Domain.Enums;
using PlanManager.Domain.Repositories.PlanManager;

namespace PlanManager.Aplication.Services.PlanManager;

public class SignService : ISignService
{
    private readonly ISignRepository _signRepository;
    private readonly ILicenseRepository _licenseRepository;

    public SignService(ISignRepository signRepository, ILicenseRepository licenseRepository)
    {
        _signRepository = signRepository;
        _licenseRepository = licenseRepository;
    }


    public async Task<bool> VerifyIfSignExists(Sign sign)
    {
        var result = await _signRepository.GetSign(sign);
        return result != null;
    }

    public async Task AddSign(Sign sign)
    {
        await _signRepository.AddAsync(sign);
    }

    public async Task<Sign> GetSignByIdentification(string identification)
    {
        return await _signRepository.GetSignByIdentification(identification);
    }

    public async Task VerifyLicensesToUpdateSignStatus(string identification)
    {
        //Devo pegar uma lista de Licenças vinculadas a essa assinatura, antigas e novas licenças

        Sign sign = await _signRepository.GetSignByIdentification(identification);
        IList<License> licenses = await _licenseRepository.GetLicensesBySignIdentification(identification);

        //Após isso devo verificar uma por uma se tudo ocorreu bem, se a ultima licença estiver passado da validade, e nao tiver sido renovada, inativar assinatura
        foreach (License license in licenses)
        {
            license.ValidateStatus();
            if (license.Status is ELicenseStatus.Expired or ELicenseStatus.Paused)
                sign.SetStatus(ESignStatus.Inactive);
        }
    }

    public async Task<IList<PlanPermission>> GetPlanPermissionBySignIdentification(string signIdentification)
    {
        return await _signRepository.GetPlanPermissionBySignIdentification(signIdentification);
    }

    public async Task<string> GetPlanIdentificationBySignIdentification(string signIdentification)
    {
        return await _signRepository.GetPlanIdentificationBySignIdentification(signIdentification);
    }
}