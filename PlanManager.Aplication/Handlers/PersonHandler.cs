using PlanManager.Aplication.Commands;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.Interfaces;
using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Aplication.Handlers;

public class PersonHandler : IHandler<CreatePersonCommand, Person> {
	public ResultDto<Person> Handle(CreatePersonCommand command) {
		throw new NotImplementedException();
	}
}