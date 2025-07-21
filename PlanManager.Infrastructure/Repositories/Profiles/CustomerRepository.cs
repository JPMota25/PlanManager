using Microsoft.EntityFrameworkCore;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Repositories.Profiles;
using PlanManager.Infrastructure.Data;

namespace PlanManager.Infrastructure.Repositories.Profiles;

public class CustomerRepository : Repository<Customer>, ICustomerRepository {
	private readonly PlanManagerDbContext _context;

	public CustomerRepository(PlanManagerDbContext context) : base(context) {
		_context = context;
	}

	public async Task<bool> VerifyIfCustomerExists(string customerId) {
		var customer = await _context.Customers.FirstOrDefaultAsync(x=>x.IdPerson.Identifier ==  customerId);
		return customer != null;
	}
}