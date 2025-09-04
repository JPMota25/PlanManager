using Flunt.Notifications;
using MediatR;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Response;
using PlanManager.Aplication.Interfaces.Profiles;
using PlanManager.Aplication.Interfaces.Utils;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Repositories;

namespace PlanManager.Aplication.Commands.Profiles.User.CreateUser;

public class CreateUserHandler : Notifiable<Notification>, IRequestHandler<CreateUserCommand, ResultDto<UserCreatedDto>> {
	private readonly IPersonService _personService;
	private readonly IPasswordHashService _passwordHashService;
	private readonly IUserService _userService;
	private readonly IUnitOfWork _unitOfWork;

	public CreateUserHandler(IPersonService personService, IPasswordHashService passwordHashService, IUserService userService, IUnitOfWork unitOfWork) {
		_personService = personService;
		_passwordHashService = passwordHashService;
		_userService = userService;
		_unitOfWork = unitOfWork;
	}

	public async Task<ResultDto<UserCreatedDto>> Handle(CreateUserCommand command, CancellationToken cancellationToken) {
		Person request = command.Person;
		if (!request.IsValid)
			return ResultDto<UserCreatedDto>.Fail(request.Notifications);

		Person person = new Person(request.FirstName, request.LastName, request.Email, request.Document, request.Type, request.CountryCode, request.DDD,
			request.NumberWithDigit, request.Neighboorhood, request.HouseNumber, request.HasHouseNumber, request.Complement, request.Street, request.City,
			request.State, request.Country, request.Zipcode);
		if (!person.IsValid || await _personService.VerifyPersonUniqueKeys(person))
			return ResultDto<UserCreatedDto>.Fail(person.Notifications);

		var user = new Domain.Entities.Profiles.User(person.Id, command.Username, _passwordHashService.HashPassword(command.Password));
		await _personService.AddPerson(person);
		await _userService.AddUser(user);
		await _unitOfWork.CommitAsync();
		return ResultDto<UserCreatedDto>.Ok(new UserCreatedDto(user.Id, user.Username));
	}
}