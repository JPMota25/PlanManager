using System;
using System.Collections.Generic;
using System.Text;
using PlanManager.Aplication.Interfaces.Profiles;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Repositories.Profiles;

namespace PlanManager.Aplication.Services.Profiles
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task AddCompany(Company company)
        {
            await _companyRepository.AddAsync(company);
        }

        public async Task<Company?> GetById(string idCompany)
        {
            return await _companyRepository.GetByIdAsync(idCompany);
        }
    }
}
