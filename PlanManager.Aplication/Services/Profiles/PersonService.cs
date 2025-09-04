using PlanManager.Aplication.Interfaces.Profiles;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Repositories.Profiles;

namespace PlanManager.Aplication.Services.Profiles;

public class PersonService : IPersonService {
	private readonly IPersonRepository _personRepository;

	public PersonService(IPersonRepository personRepository) {
		_personRepository = personRepository;
	}

	public async Task<bool> VerifyPersonUniqueKeys(Person person) {
		return await _personRepository.VerifyPersonUniqueKeys(person);
	}

	public async Task<Person?> GetById(string id) {
		return await _personRepository.GetByIdAsync(id);
	}

	public async Task AddPerson(Person person) {
		await _personRepository.AddAsync(person);
	}

	public Task UpdatePerson(Person person) {
		throw new NotImplementedException();
	}
}