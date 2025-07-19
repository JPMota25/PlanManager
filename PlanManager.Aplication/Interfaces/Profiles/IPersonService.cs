using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Interfaces.Profiles;

public interface IPersonService {
	Task<bool> VerifyPerson(Document document);
	Task AddPerson(Person person);
	Task UpdatePerson(Person person);
}