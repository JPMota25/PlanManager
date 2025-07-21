using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Domain.Repositories.Profiles;

public interface ICustomerRepository : IRepository<Customer> {
	Task<bool> VerifyIfCustomerExists(string customerId);
}