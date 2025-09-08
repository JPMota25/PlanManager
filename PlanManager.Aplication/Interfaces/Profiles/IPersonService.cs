using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Aplication.Interfaces.Profiles;

public interface IPersonService
{
    Task<bool> VerifyPersonUniqueKeys(Person person);
    Task<Person?> GetById(string id);
    Task AddPerson(Person person);
    Task UpdatePerson(Person person);
}