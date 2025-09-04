using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Domain.Repositories.Profiles;

public interface IPersonRepository : IRepository<Person> {
	Task<bool> VerifyPersonUniqueKeys(Person person);
}