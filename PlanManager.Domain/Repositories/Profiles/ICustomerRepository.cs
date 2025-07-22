using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Domain.Repositories.Profiles;

public interface ICustomerRepository : IRepository<Customer> {
	Task<bool> VerifyIfCustomerExists(Id customerId);
}