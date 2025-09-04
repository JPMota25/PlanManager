using PlanManager.Aplication.Interfaces.Profiles;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Repositories.Profiles;

namespace PlanManager.Aplication.Services.Profiles;

public class CustomerService : ICustomerService {
	private readonly ICustomerRepository _customerRepository;

	public CustomerService(ICustomerRepository customerRepository) {
		_customerRepository = customerRepository;
	}

	public async Task AddCustomer(Customer customer) {
		await _customerRepository.AddAsync(customer);
	}

	public async Task<bool> VerifyIfCustomerExists(Customer customer) {
		return await _customerRepository.VerifyIfCustomerExists(customer);
	}

    public async Task<Customer?> GetCustomerByIdentification(string identification)
    {
        return await _customerRepository.GetCustomerByIdentification(identification);
    }
}