using PlanManager.Aplication.Interfaces.Profiles;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Repositories.Profiles;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Services.Profiles;

public class PersonService : IPersonService {
	private readonly IPersonRepository _personRepository;

	public PersonService(IPersonRepository personRepository) {
		_personRepository = personRepository;
	}

	public async Task<bool> VerifyPersonByDocument(Document document) {
		return await _personRepository.ConfirmUniqueKey(document.Identification);
	}

	public async Task<Person?> GetById(Id id) {
		return await _personRepository.GetByIdAsync(id);
	}

	public async Task AddPerson(Person person) {
		await _personRepository.AddAsync(person);
		await _personRepository.SaveChangesAsync();
	}

	public Task UpdatePerson(Person person) {
		throw new NotImplementedException();
	}
}