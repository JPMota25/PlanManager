using PlanManager.Domain.Entities.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanManager.Aplication.Interfaces.Profiles
{
    public interface ICompanyService
    {
        Task AddCompany(Company company);
        Task<Company?> GetById(string idCompany);
    }
}
