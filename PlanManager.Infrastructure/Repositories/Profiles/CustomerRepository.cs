using Microsoft.EntityFrameworkCore;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Repositories.Profiles;
using PlanManager.Infrastructure.Data;

namespace PlanManager.Infrastructure.Repositories.Profiles;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    private readonly PlanManagerDbContext _context;

    public CustomerRepository(PlanManagerDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> VerifyIfCustomerExists(Customer customer)
    {
        var customerDb = await _context.Customers.FirstOrDefaultAsync(x => x.Id == customer.Id && x.IdCompany == customer.IdCompany);
        return customerDb != null;
    }

    public async Task<Customer?> GetCustomerByIdentification(string identification)
    {
        return await _context.Customers.FirstOrDefaultAsync(c => c.Identification == identification);
    }
}