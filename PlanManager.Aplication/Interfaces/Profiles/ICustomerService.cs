using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Aplication.Interfaces.Profiles;

public interface ICustomerService {
	Task AddCustomer(Customer customer);
	Task<bool> VerifyIfCustomerExists(string customerIdVo);
}