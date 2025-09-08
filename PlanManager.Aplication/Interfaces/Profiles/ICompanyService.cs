using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Aplication.Interfaces.Profiles
{
    public interface ICompanyService
    {
        Task AddCompany(Company company);
        Task<Company?> GetById(string idCompany);
    }
}
