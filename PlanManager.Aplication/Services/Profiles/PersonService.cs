using PlanManager.Aplication.Commands;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.Interfaces.Profiles;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Repositories.Profiles;

namespace PlanManager.Aplication.Services.Profiles;

public class PersonService : IPersonService {
	private readonly IPersonRepository _personRepository;
	private readonly ILogActivityService _logActivityService;

	public PersonService(IPersonRepository personRepository, ILogActivityService logActivityService) {
		_personRepository = personRepository;
		_logActivityService = logActivityService;
	}

	public Task<Person> HandleCreatePerson(CreatePersonCommand model) {
		throw new NotImplementedException();
	}

	public Task<IList<Person>> HandleListPerson() {
		throw new NotImplementedException();
	}

	public Task<ResultDto<Person>> HandleSavePerson(Person person) {
		throw new NotImplementedException();
	}
}