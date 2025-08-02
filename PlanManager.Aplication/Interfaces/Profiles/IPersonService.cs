using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Aplication.Interfaces.Profiles;

public interface IPersonService {
	Task<bool> VerifyPersonByDocument(string document);
	Task<Person?> GetById(string id);
	Task AddPerson(Person person);
	Task UpdatePerson(Person person);
}