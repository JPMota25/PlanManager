using PlanManager.Aplication.Commands;
using PlanManager.Aplication.DTOs;
using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Aplication.Interfaces.Profiles;

public interface IPersonService {
	Task<Person> HandleCreatePerson(CreatePersonCommand model);
	Task<IList<Person>> HandleListPerson();
	Task<ResultDto<Person>> HandleSavePerson(Person person);
}