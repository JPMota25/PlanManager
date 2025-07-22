using Microsoft.EntityFrameworkCore;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Repositories.Profiles;
using PlanManager.Domain.ValueObjects;
using PlanManager.Infrastructure.Data;

namespace PlanManager.Infrastructure.Repositories.Profiles;

public class CustomerRepository : Repository<Customer>, ICustomerRepository {
	private readonly PlanManagerDbContext _context;

	public CustomerRepository(PlanManagerDbContext context) : base(context) {
		_context = context;
	}

	public async Task<bool> VerifyIfCustomerExists(Id customerId) {
		var customer = await _context.Customers.FirstOrDefaultAsync(x=>x.Id == customerId);
		return customer != null;
	}
}