using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Interfaces.Profiles;

public interface IPersonService {
	Task<bool> VerifyPersonByDocument(Document document);
	Task<Person?> GetById(Id id);
	Task AddPerson(Person person);
	Task UpdatePerson(Person person);
}