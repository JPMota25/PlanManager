using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Aplication.Interfaces.Profiles;

public interface ICustomerService
{
    Task AddCustomer(Customer customer);
    Task<bool> VerifyIfCustomerExists(Customer costumer);
    Task<Customer?> GetCustomerByIdentification(string identification);
}