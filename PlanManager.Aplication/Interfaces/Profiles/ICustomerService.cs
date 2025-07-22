using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Interfaces.Profiles;

public interface ICustomerService {
	Task AddCustomer(Customer customer);
	Task<bool> VerifyIfCustomerExists(Id customerId);
}