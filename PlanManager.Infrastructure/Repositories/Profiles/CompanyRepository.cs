using System;
using System.Collections.Generic;
using System.Text;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Repositories.Profiles;
using PlanManager.Infrastructure.Data;

namespace PlanManager.Infrastructure.Repositories.Profiles
{
    public class CompanyRepository: Repository<Company>, ICompanyRepository
    {
        private readonly PlanManagerDbContext _context;
        public CompanyRepository(PlanManagerDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
